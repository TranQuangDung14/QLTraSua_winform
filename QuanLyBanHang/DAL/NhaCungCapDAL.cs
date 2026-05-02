using Microsoft.Data.SqlClient;
using QuanLyBanHang.DTO;

namespace QuanLyBanHang.DAL
{
    internal class NhaCungCapDAL
    {
        internal async Task<List<NhaCungCapDTO>> GetDanhSachAsync(string tuKhoa)
        {
            const string query = """
                SELECT MaNCC, TenNCC, DiaChi, SoDienThoai, Email
                FROM NhaCungCap
                WHERE (@TuKhoa = '' OR TenNCC LIKE '%' + @TuKhoa + '%')
                ORDER BY MaNCC DESC;
                """;

            var danhSach = new List<NhaCungCapDTO>();

            await using var connection = await Database.CreateOpenConnectionAsync();
            await using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TuKhoa", tuKhoa);

            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                danhSach.Add(new NhaCungCapDTO
                {
                    MaNCC = reader.GetInt32(reader.GetOrdinal("MaNCC")),
                    TenNCC = reader["TenNCC"]?.ToString() ?? string.Empty,
                    DiaChi = reader["DiaChi"]?.ToString() ?? string.Empty,
                    SoDienThoai = reader["SoDienThoai"]?.ToString() ?? string.Empty,
                    Email = reader["Email"]?.ToString() ?? string.Empty
                });
            }

            return danhSach;
        }

        internal async Task ThemAsync(NhaCungCapDTO nhaCungCap)
        {
            const string query = """
                INSERT INTO NhaCungCap (TenNCC, DiaChi, SoDienThoai, Email)
                VALUES (@TenNCC, @DiaChi, @SoDienThoai, @Email);
                """;

            await using var connection = await Database.CreateOpenConnectionAsync();
            await using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TenNCC", nhaCungCap.TenNCC);
            command.Parameters.AddWithValue("@DiaChi", nhaCungCap.DiaChi);
            command.Parameters.AddWithValue("@SoDienThoai", nhaCungCap.SoDienThoai);
            command.Parameters.AddWithValue("@Email", nhaCungCap.Email);
            await command.ExecuteNonQueryAsync();
        }

        internal async Task CapNhatAsync(NhaCungCapDTO nhaCungCap)
        {
            const string query = """
                UPDATE NhaCungCap
                SET TenNCC = @TenNCC,
                    DiaChi = @DiaChi,
                    SoDienThoai = @SoDienThoai,
                    Email = @Email
                WHERE MaNCC = @MaNCC;
                """;

            await using var connection = await Database.CreateOpenConnectionAsync();
            await using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TenNCC", nhaCungCap.TenNCC);
            command.Parameters.AddWithValue("@DiaChi", nhaCungCap.DiaChi);
            command.Parameters.AddWithValue("@SoDienThoai", nhaCungCap.SoDienThoai);
            command.Parameters.AddWithValue("@Email", nhaCungCap.Email);
            command.Parameters.AddWithValue("@MaNCC", nhaCungCap.MaNCC);
            await command.ExecuteNonQueryAsync();
        }

        internal async Task XoaAsync(int maNCC)
        {
            const string query = "DELETE FROM NhaCungCap WHERE MaNCC = @MaNCC;";

            await using var connection = await Database.CreateOpenConnectionAsync();
            await using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@MaNCC", maNCC);
            await command.ExecuteNonQueryAsync();
        }
    }
}
