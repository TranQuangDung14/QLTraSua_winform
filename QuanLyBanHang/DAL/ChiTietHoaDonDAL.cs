using Microsoft.Data.SqlClient;
using QuanLyBanHang.DTO;

namespace QuanLyBanHang.DAL
{
    internal class ChiTietHoaDonDAL
    {
        internal async Task<List<ChiTietHoaDonDTO>> GetDanhSachAsync(string tuKhoa)
        {
            const string query = """
                SELECT
                    cthd.MaCTHD,
                    cthd.MaHD,
                    cthd.MaSP,
                    ISNULL(sp.TenSP, '') AS TenSP,
                    cthd.SoLuong,
                    cthd.DonGia,
                    cthd.ThanhTien,
                    hd.NgayLap,
                    ISNULL(nv.HoTen, '') AS HoTenNhanVien,
                    ISNULL(kh.HoTen, N'Khách lẻ') AS HoTenKhachHang
                FROM ChiTietHoaDon cthd
                INNER JOIN HoaDon hd ON hd.MaHD = cthd.MaHD
                LEFT JOIN SanPham sp ON sp.MaSP = cthd.MaSP
                LEFT JOIN NhanVien nv ON nv.MaNV = hd.MaNV
                LEFT JOIN KhachHang kh ON kh.MaKH = hd.MaKH
                WHERE (@TuKhoa = ''
                    OR CONVERT(VARCHAR(20), cthd.MaHD) LIKE '%' + @TuKhoa + '%'
                    OR ISNULL(sp.TenSP, '') LIKE '%' + @TuKhoa + '%'
                    OR ISNULL(kh.HoTen, N'Khách lẻ') LIKE '%' + @TuKhoa + '%')
                ORDER BY cthd.MaHD DESC, cthd.MaCTHD DESC;
                """;

            var danhSach = new List<ChiTietHoaDonDTO>();

            await using var connection = await Database.CreateOpenConnectionAsync();
            await using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TuKhoa", tuKhoa);

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
                    ThanhTien = Convert.ToDecimal(reader["ThanhTien"]),
                    NgayLap = reader["NgayLap"] == DBNull.Value ? null : Convert.ToDateTime(reader["NgayLap"]),
                    HoTenNhanVien = reader["HoTenNhanVien"]?.ToString() ?? string.Empty,
                    HoTenKhachHang = reader["HoTenKhachHang"]?.ToString() ?? string.Empty
                });
            }

            return danhSach;
        }

        internal async Task XoaAsync(int maCTHD)
        {
            await using var connection = await Database.CreateOpenConnectionAsync();
            await using var transaction = await connection.BeginTransactionAsync();

            try
            {
                const string queryChiTiet = """
                    SELECT TOP 1 MaCTHD, MaHD, MaSP, SoLuong, ThanhTien
                    FROM ChiTietHoaDon
                    WHERE MaCTHD = @MaCTHD;
                    """;

                ChiTietHoaDonDTO? chiTietCanXoa = null;
                await using (var commandChiTiet = new SqlCommand(queryChiTiet, connection, (SqlTransaction)transaction))
                {
                    commandChiTiet.Parameters.AddWithValue("@MaCTHD", maCTHD);
                    await using var reader = await commandChiTiet.ExecuteReaderAsync();
                    if (await reader.ReadAsync())
                    {
                        chiTietCanXoa = new ChiTietHoaDonDTO
                        {
                            MaCTHD = Convert.ToInt32(reader["MaCTHD"]),
                            MaHD = Convert.ToInt32(reader["MaHD"]),
                            MaSP = Convert.ToInt32(reader["MaSP"]),
                            SoLuong = Convert.ToInt32(reader["SoLuong"]),
                            ThanhTien = Convert.ToDecimal(reader["ThanhTien"])
                        };
                    }
                }

                if (chiTietCanXoa is null)
                {
                    throw new InvalidOperationException("Không tìm thấy chi tiết hóa đơn cần xóa.");
                }

                const string queryDem = "SELECT COUNT(*) FROM ChiTietHoaDon WHERE MaHD = @MaHD;";
                await using (var commandDem = new SqlCommand(queryDem, connection, (SqlTransaction)transaction))
                {
                    commandDem.Parameters.AddWithValue("@MaHD", chiTietCanXoa.MaHD);
                    var soDong = Convert.ToInt32(await commandDem.ExecuteScalarAsync());
                    if (soDong <= 1)
                    {
                        throw new InvalidOperationException("Không thể xóa dòng chi tiết cuối cùng của hóa đơn.");
                    }
                }

                await using (var commandCongKho = new SqlCommand(
                    "UPDATE SanPham SET SoLuong = SoLuong + @SoLuong WHERE MaSP = @MaSP;",
                    connection,
                    (SqlTransaction)transaction))
                {
                    commandCongKho.Parameters.AddWithValue("@SoLuong", chiTietCanXoa.SoLuong);
                    commandCongKho.Parameters.AddWithValue("@MaSP", chiTietCanXoa.MaSP);
                    await commandCongKho.ExecuteNonQueryAsync();
                }

                await using (var commandXoa = new SqlCommand(
                    "DELETE FROM ChiTietHoaDon WHERE MaCTHD = @MaCTHD;",
                    connection,
                    (SqlTransaction)transaction))
                {
                    commandXoa.Parameters.AddWithValue("@MaCTHD", maCTHD);
                    await commandXoa.ExecuteNonQueryAsync();
                }

                const string queryCapNhatTongTien = """
                    UPDATE HoaDon
                    SET TongTien = ISNULL((
                        SELECT SUM(ThanhTien)
                        FROM ChiTietHoaDon
                        WHERE MaHD = @MaHD
                    ), 0)
                    WHERE MaHD = @MaHD;
                    """;

                await using (var commandTongTien = new SqlCommand(queryCapNhatTongTien, connection, (SqlTransaction)transaction))
                {
                    commandTongTien.Parameters.AddWithValue("@MaHD", chiTietCanXoa.MaHD);
                    await commandTongTien.ExecuteNonQueryAsync();
                }

                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
