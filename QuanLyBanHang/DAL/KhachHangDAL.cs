using Microsoft.Data.SqlClient;
using QuanLyBanHang.DTO;

namespace QuanLyBanHang.DAL
{
    internal class KhachHangDAL
    {
        internal async Task<List<KhachHangDTO>> GetDanhSachAsync(string tuKhoa)
        {
            const string query = """
                SELECT MaKH, HoTen, SoDienThoai, DiaChi
                FROM KhachHang
                WHERE (@TuKhoa = '' OR HoTen LIKE '%' + @TuKhoa + '%')
                ORDER BY MaKH DESC;
                """;

            var danhSach = new List<KhachHangDTO>();

            await using var connection = await Database.CreateOpenConnectionAsync();
            await using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TuKhoa", tuKhoa);

            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                danhSach.Add(new KhachHangDTO
                {
                    MaKH = reader.GetInt32(reader.GetOrdinal("MaKH")),
                    HoTen = reader["HoTen"]?.ToString() ?? string.Empty,
                    SoDienThoai = reader["SoDienThoai"]?.ToString() ?? string.Empty,
                    DiaChi = reader["DiaChi"]?.ToString() ?? string.Empty
                });
            }

            return danhSach;
        }

        internal async Task ThemAsync(KhachHangDTO khachHang)
        {
            const string query = """
                INSERT INTO KhachHang (HoTen, SoDienThoai, DiaChi)
                VALUES (@HoTen, @SoDienThoai, @DiaChi);
                """;

            await using var connection = await Database.CreateOpenConnectionAsync();
            await using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@HoTen", khachHang.HoTen);
            command.Parameters.AddWithValue("@SoDienThoai", string.IsNullOrWhiteSpace(khachHang.SoDienThoai) ? DBNull.Value : khachHang.SoDienThoai);
            command.Parameters.AddWithValue("@DiaChi", string.IsNullOrWhiteSpace(khachHang.DiaChi) ? DBNull.Value : khachHang.DiaChi);
            await command.ExecuteNonQueryAsync();
        }

        internal async Task CapNhatAsync(KhachHangDTO khachHang)
        {
            const string query = """
                UPDATE KhachHang
                SET HoTen = @HoTen,
                    SoDienThoai = @SoDienThoai,
                    DiaChi = @DiaChi
                WHERE MaKH = @MaKH;
                """;

            await using var connection = await Database.CreateOpenConnectionAsync();
            await using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@HoTen", khachHang.HoTen);
            command.Parameters.AddWithValue("@SoDienThoai", string.IsNullOrWhiteSpace(khachHang.SoDienThoai) ? DBNull.Value : khachHang.SoDienThoai);
            command.Parameters.AddWithValue("@DiaChi", string.IsNullOrWhiteSpace(khachHang.DiaChi) ? DBNull.Value : khachHang.DiaChi);
            command.Parameters.AddWithValue("@MaKH", khachHang.MaKH);
            await command.ExecuteNonQueryAsync();
        }

        internal async Task XoaAsync(int maKH)
        {
            const string query = "DELETE FROM KhachHang WHERE MaKH = @MaKH;";

            await using var connection = await Database.CreateOpenConnectionAsync();
            await using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@MaKH", maKH);
            await command.ExecuteNonQueryAsync();
        }
    }
}
