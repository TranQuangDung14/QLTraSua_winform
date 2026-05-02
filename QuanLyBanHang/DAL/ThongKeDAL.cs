using Microsoft.Data.SqlClient;
using QuanLyBanHang.DTO;

namespace QuanLyBanHang.DAL
{
    internal class ThongKeDAL
    {
        internal async Task<ThongKeDoanhThuDTO> GetTongHopAsync(DateTime tuNgay, DateTime denNgay)
        {
            const string query = """
                SELECT
                    COUNT(*) AS SoHoaDon,
                    ISNULL(SUM(TongTien), 0) AS TongDoanhThu
                FROM HoaDon
                WHERE NgayLap >= @TuNgay AND NgayLap < @DenNgay;
                """;

            await using var connection = await Database.CreateOpenConnectionAsync();
            await using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TuNgay", tuNgay);
            command.Parameters.AddWithValue("@DenNgay", denNgay);

            await using var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                var soHoaDon = Convert.ToInt32(reader["SoHoaDon"]);
                var tongDoanhThu = Convert.ToDecimal(reader["TongDoanhThu"]);

                return new ThongKeDoanhThuDTO
                {
                    TuNgay = tuNgay,
                    DenNgay = denNgay.AddTicks(-1),
                    SoHoaDon = soHoaDon,
                    TongDoanhThu = tongDoanhThu,
                    HoaDonTrungBinh = soHoaDon > 0 ? tongDoanhThu / soHoaDon : 0
                };
            }

            return new ThongKeDoanhThuDTO
            {
                TuNgay = tuNgay,
                DenNgay = denNgay.AddTicks(-1)
            };
        }

        internal async Task<List<HoaDonDTO>> GetHoaDonsAsync(DateTime tuNgay, DateTime denNgay)
        {
            const string query = """
                SELECT
                    hd.MaHD,
                    hd.MaNV,
                    ISNULL(hd.MaKH, 0) AS MaKH,
                    hd.NgayLap,
                    hd.TongTien,
                    ISNULL(nv.HoTen, '') AS HoTenNhanVien,
                    ISNULL(kh.HoTen, 'Khách lẻ') AS HoTenKhachHang
                FROM HoaDon hd
                LEFT JOIN NhanVien nv ON nv.MaNV = hd.MaNV
                LEFT JOIN KhachHang kh ON kh.MaKH = hd.MaKH
                WHERE hd.NgayLap >= @TuNgay AND hd.NgayLap < @DenNgay
                ORDER BY hd.NgayLap DESC, hd.MaHD DESC;
                """;

            var danhSach = new List<HoaDonDTO>();

            await using var connection = await Database.CreateOpenConnectionAsync();
            await using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TuNgay", tuNgay);
            command.Parameters.AddWithValue("@DenNgay", denNgay);

            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                danhSach.Add(new HoaDonDTO
                {
                    MaHD = reader.GetInt32(reader.GetOrdinal("MaHD")),
                    MaNV = reader.GetInt32(reader.GetOrdinal("MaNV")),
                    MaKH = Convert.ToInt32(reader["MaKH"]),
                    NgayLap = Convert.ToDateTime(reader["NgayLap"]),
                    TongTien = Convert.ToDecimal(reader["TongTien"]),
                    HoTenNhanVien = reader["HoTenNhanVien"]?.ToString() ?? string.Empty,
                    HoTenKhachHang = reader["HoTenKhachHang"]?.ToString() ?? string.Empty
                });
            }

            return danhSach;
        }
    }
}
