using Microsoft.Data.SqlClient;
using QuanLyBanHang.DTO;

namespace QuanLyBanHang.DAL
{
    internal class HoaDonDAL
    {
        internal async Task<List<HoaDonDTO>> GetDanhSachAsync(string tuKhoa)
        {
            const string query = """
                SELECT
                    hd.MaHD,
                    hd.MaNV,
                    ISNULL(hd.MaKH, 0) AS MaKH,
                    hd.NgayLap,
                    hd.TongTien,
                    ISNULL(nv.HoTen, '') AS HoTenNhanVien,
                    ISNULL(kh.HoTen, N'Khách lẻ') AS HoTenKhachHang
                FROM HoaDon hd
                LEFT JOIN NhanVien nv ON nv.MaNV = hd.MaNV
                LEFT JOIN KhachHang kh ON kh.MaKH = hd.MaKH
                WHERE (@TuKhoa = ''
                    OR CONVERT(VARCHAR(20), hd.MaHD) LIKE '%' + @TuKhoa + '%'
                    OR ISNULL(kh.HoTen, N'Khách lẻ') LIKE '%' + @TuKhoa + '%')
                ORDER BY hd.MaHD DESC;
                """;

            var danhSach = new List<HoaDonDTO>();

            await using var connection = await Database.CreateOpenConnectionAsync();
            await using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TuKhoa", tuKhoa);

            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                danhSach.Add(new HoaDonDTO
                {
                    MaHD = reader.GetInt32(reader.GetOrdinal("MaHD")),
                    MaNV = reader.GetInt32(reader.GetOrdinal("MaNV")),
                    MaKH = Convert.ToInt32(reader["MaKH"]),
                    NgayLap = Convert.ToDateTime(reader["NgayLap"]),
                    TongTien = reader["TongTien"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["TongTien"]),
                    HoTenNhanVien = reader["HoTenNhanVien"]?.ToString() ?? string.Empty,
                    HoTenKhachHang = reader["HoTenKhachHang"]?.ToString() ?? string.Empty
                });
            }

            return danhSach;
        }

        internal async Task<List<ChiTietHoaDonDTO>> GetChiTietAsync(int maHD)
        {
            const string query = """
                SELECT
                    cthd.MaCTHD,
                    cthd.MaHD,
                    cthd.MaSP,
                    ISNULL(sp.TenSP, '') AS TenSP,
                    cthd.SoLuong,
                    cthd.DonGia,
                    cthd.ThanhTien
                FROM ChiTietHoaDon cthd
                LEFT JOIN SanPham sp ON sp.MaSP = cthd.MaSP
                WHERE cthd.MaHD = @MaHD
                ORDER BY cthd.MaCTHD;
                """;

            var danhSach = new List<ChiTietHoaDonDTO>();

            await using var connection = await Database.CreateOpenConnectionAsync();
            await using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@MaHD", maHD);

            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                danhSach.Add(new ChiTietHoaDonDTO
                {
                    MaCTHD = reader.GetInt32(reader.GetOrdinal("MaCTHD")),
                    MaHD = reader.GetInt32(reader.GetOrdinal("MaHD")),
                    MaSP = reader.GetInt32(reader.GetOrdinal("MaSP")),
                    TenSP = reader["TenSP"]?.ToString() ?? string.Empty,
                    SoLuong = Convert.ToInt32(reader["SoLuong"]),
                    DonGia = Convert.ToDecimal(reader["DonGia"]),
                    ThanhTien = Convert.ToDecimal(reader["ThanhTien"])
                });
            }

            return danhSach;
        }

        internal async Task<int> ThemHoaDonAsync(HoaDonDTO hoaDon, List<ChiTietHoaDonDTO> chiTietHoaDons)
        {
            await using var connection = await Database.CreateOpenConnectionAsync();
            await using var transaction = await connection.BeginTransactionAsync();

            try
            {
                const string insertHoaDon = """
                    INSERT INTO HoaDon (MaNV, MaKH, NgayLap, TongTien)
                    OUTPUT INSERTED.MaHD
                    VALUES (@MaNV, @MaKH, @NgayLap, @TongTien);
                    """;

                await using var commandHoaDon = new SqlCommand(insertHoaDon, connection, (SqlTransaction)transaction);
                commandHoaDon.Parameters.AddWithValue("@MaNV", hoaDon.MaNV);
                commandHoaDon.Parameters.AddWithValue("@MaKH", hoaDon.MaKH > 0 ? hoaDon.MaKH : DBNull.Value);
                commandHoaDon.Parameters.AddWithValue("@NgayLap", hoaDon.NgayLap);
                commandHoaDon.Parameters.AddWithValue("@TongTien", hoaDon.TongTien);

                var maHD = Convert.ToInt32(await commandHoaDon.ExecuteScalarAsync());

                foreach (var chiTiet in chiTietHoaDons)
                {
                    await TrinhKhoAsync(connection, (SqlTransaction)transaction, chiTiet.MaSP, chiTiet.SoLuong);
                    await ThemChiTietAsync(connection, (SqlTransaction)transaction, maHD, chiTiet);
                }

                await transaction.CommitAsync();
                return maHD;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        internal async Task XoaHoaDonAsync(int maHD)
        {
            await using var connection = await Database.CreateOpenConnectionAsync();
            await using var transaction = await connection.BeginTransactionAsync();

            try
            {
                var chiTiets = await GetChiTietNoTransactionAsync(connection, (SqlTransaction)transaction, maHD);
                foreach (var chiTiet in chiTiets)
                {
                    await using var commandCongKho = new SqlCommand(
                        "UPDATE SanPham SET SoLuong = SoLuong + @SoLuong WHERE MaSP = @MaSP;",
                        connection,
                        (SqlTransaction)transaction);
                    commandCongKho.Parameters.AddWithValue("@SoLuong", chiTiet.SoLuong);
                    commandCongKho.Parameters.AddWithValue("@MaSP", chiTiet.MaSP);
                    await commandCongKho.ExecuteNonQueryAsync();
                }

                await using (var commandDeleteChiTiet = new SqlCommand("DELETE FROM ChiTietHoaDon WHERE MaHD = @MaHD;", connection, (SqlTransaction)transaction))
                {
                    commandDeleteChiTiet.Parameters.AddWithValue("@MaHD", maHD);
                    await commandDeleteChiTiet.ExecuteNonQueryAsync();
                }

                await using (var commandDeleteHoaDon = new SqlCommand("DELETE FROM HoaDon WHERE MaHD = @MaHD;", connection, (SqlTransaction)transaction))
                {
                    commandDeleteHoaDon.Parameters.AddWithValue("@MaHD", maHD);
                    await commandDeleteHoaDon.ExecuteNonQueryAsync();
                }

                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        private static async Task TrinhKhoAsync(SqlConnection connection, SqlTransaction transaction, int maSP, int soLuong)
        {
            const string query = """
                UPDATE SanPham
                SET SoLuong = SoLuong - @SoLuong
                WHERE MaSP = @MaSP AND SoLuong >= @SoLuong;
                """;

            await using var command = new SqlCommand(query, connection, transaction);
            command.Parameters.AddWithValue("@SoLuong", soLuong);
            command.Parameters.AddWithValue("@MaSP", maSP);
            var affected = await command.ExecuteNonQueryAsync();
            if (affected == 0)
            {
                throw new InvalidOperationException("Số lượng tồn kho không đủ để lập hóa đơn.");
            }
        }

        private static async Task ThemChiTietAsync(SqlConnection connection, SqlTransaction transaction, int maHD, ChiTietHoaDonDTO chiTiet)
        {
            const string query = """
                INSERT INTO ChiTietHoaDon (MaHD, MaSP, SoLuong, DonGia, ThanhTien)
                VALUES (@MaHD, @MaSP, @SoLuong, @DonGia, @ThanhTien);
                """;

            await using var command = new SqlCommand(query, connection, transaction);
            command.Parameters.AddWithValue("@MaHD", maHD);
            command.Parameters.AddWithValue("@MaSP", chiTiet.MaSP);
            command.Parameters.AddWithValue("@SoLuong", chiTiet.SoLuong);
            command.Parameters.AddWithValue("@DonGia", chiTiet.DonGia);
            command.Parameters.AddWithValue("@ThanhTien", chiTiet.ThanhTien);
            await command.ExecuteNonQueryAsync();
        }

        private static async Task<List<ChiTietHoaDonDTO>> GetChiTietNoTransactionAsync(SqlConnection connection, SqlTransaction transaction, int maHD)
        {
            var danhSach = new List<ChiTietHoaDonDTO>();
            const string query = "SELECT MaSP, SoLuong FROM ChiTietHoaDon WHERE MaHD = @MaHD;";

            await using var command = new SqlCommand(query, connection, transaction);
            command.Parameters.AddWithValue("@MaHD", maHD);

            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                danhSach.Add(new ChiTietHoaDonDTO
                {
                    MaSP = Convert.ToInt32(reader["MaSP"]),
                    SoLuong = Convert.ToInt32(reader["SoLuong"])
                });
            }

            return danhSach;
        }
    }
}
