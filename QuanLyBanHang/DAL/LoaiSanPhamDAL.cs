using Microsoft.Data.SqlClient;
using QuanLyBanHang.DTO;

namespace QuanLyBanHang.DAL
{
    internal class LoaiSanPhamDAL
    {
        internal async Task<List<LoaiSanPhamDTO>> GetDanhSachAsync(string tuKhoa)
        {
            const string query = """
                SELECT MaLoai, TenLoai
                FROM LoaiSanPham
                WHERE (@TuKhoa = '' OR TenLoai LIKE '%' + @TuKhoa + '%')
                ORDER BY MaLoai DESC;
                """;

            var danhSach = new List<LoaiSanPhamDTO>();

            await using var connection = await Database.CreateOpenConnectionAsync();
            await using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TuKhoa", tuKhoa);

            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                danhSach.Add(new LoaiSanPhamDTO
                {
                    MaLoai = reader.GetInt32(reader.GetOrdinal("MaLoai")),
                    TenLoai = reader["TenLoai"]?.ToString() ?? string.Empty
                });
            }

            return danhSach;
        }

        internal async Task ThemAsync(LoaiSanPhamDTO loaiSanPham)
        {
            const string query = """
                INSERT INTO LoaiSanPham (TenLoai)
                VALUES (@TenLoai);
                """;

            await using var connection = await Database.CreateOpenConnectionAsync();
            await using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TenLoai", loaiSanPham.TenLoai);
            await command.ExecuteNonQueryAsync();
        }

        internal async Task CapNhatAsync(LoaiSanPhamDTO loaiSanPham)
        {
            const string query = """
                UPDATE LoaiSanPham
                SET TenLoai = @TenLoai
                WHERE MaLoai = @MaLoai;
                """;

            await using var connection = await Database.CreateOpenConnectionAsync();
            await using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TenLoai", loaiSanPham.TenLoai);
            command.Parameters.AddWithValue("@MaLoai", loaiSanPham.MaLoai);
            await command.ExecuteNonQueryAsync();
        }

        internal async Task XoaAsync(int maLoai)
        {
            const string query = "DELETE FROM LoaiSanPham WHERE MaLoai = @MaLoai;";

            await using var connection = await Database.CreateOpenConnectionAsync();
            await using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@MaLoai", maLoai);
            await command.ExecuteNonQueryAsync();
        }
    }
}
