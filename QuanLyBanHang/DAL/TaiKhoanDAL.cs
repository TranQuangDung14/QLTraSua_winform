using Microsoft.Data.SqlClient;
using QuanLyBanHang.DTO;

namespace QuanLyBanHang.DAL
{
    internal class TaiKhoanDAL
    {
        internal async Task<TaiKhoanDTO?> DangNhapAsync(string tenDangNhap, string matKhau, string quyen)
        {
            const string query = """
                SELECT TOP 1
                    tk.MaTK,
                    tk.TenDangNhap,
                    tk.Quyen,
                    tk.MaNV,
                    ISNULL(nv.HoTen, tk.TenDangNhap) AS HoTen
                FROM TaiKhoan tk
                LEFT JOIN NhanVien nv ON nv.MaNV = tk.MaNV
                WHERE tk.TenDangNhap = @TenDangNhap
                    AND tk.MatKhau = @MatKhau
                    AND tk.Quyen = @Quyen;
                """;

            await using var connection = await Database.CreateOpenConnectionAsync();
            await using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
            command.Parameters.AddWithValue("@MatKhau", matKhau);
            command.Parameters.AddWithValue("@Quyen", quyen);

            await using var reader = await command.ExecuteReaderAsync();
            if (!await reader.ReadAsync())
            {
                return null;
            }

            return new TaiKhoanDTO
            {
                MaTK = reader.GetInt32(reader.GetOrdinal("MaTK")),
                TenDangNhap = reader["TenDangNhap"]?.ToString() ?? string.Empty,
                Quyen = reader["Quyen"]?.ToString() ?? string.Empty,
                MaNV = reader["MaNV"] == DBNull.Value ? 0 : Convert.ToInt32(reader["MaNV"]),
                HoTen = reader["HoTen"]?.ToString() ?? string.Empty
            };
        }
    }
}
