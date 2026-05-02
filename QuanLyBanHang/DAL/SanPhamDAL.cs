using Microsoft.Data.SqlClient;
using QuanLyBanHang.DTO;

namespace QuanLyBanHang.DAL
{
    internal class SanPhamDAL
    {
        internal async Task<List<SanPhamDTO>> GetDanhSachAsync(string tuKhoa)
        {
            const string query = """
                SELECT
                    sp.MaSP,
                    sp.TenSP,
                    sp.MaLoai,
                    sp.MaNCC,
                    sp.DonGia,
                    sp.SoLuong,
                    ISNULL(sp.MoTa, '') AS MoTa,
                    ISNULL(lsp.TenLoai, '') AS TenLoai,
                    ISNULL(ncc.TenNCC, '') AS TenNCC
                FROM SanPham sp
                LEFT JOIN LoaiSanPham lsp ON lsp.MaLoai = sp.MaLoai
                LEFT JOIN NhaCungCap ncc ON ncc.MaNCC = sp.MaNCC
                WHERE (@TuKhoa = '' OR sp.TenSP LIKE '%' + @TuKhoa + '%')
                ORDER BY sp.MaSP DESC;
                """;

            var danhSach = new List<SanPhamDTO>();

            await using var connection = await Database.CreateOpenConnectionAsync();
            await using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TuKhoa", tuKhoa);

            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                danhSach.Add(new SanPhamDTO
                {
                    MaSP = reader.GetInt32(reader.GetOrdinal("MaSP")),
                    TenSP = reader["TenSP"]?.ToString() ?? string.Empty,
                    MaLoai = reader["MaLoai"] == DBNull.Value ? 0 : Convert.ToInt32(reader["MaLoai"]),
                    MaNCC = reader["MaNCC"] == DBNull.Value ? 0 : Convert.ToInt32(reader["MaNCC"]),
                    DonGia = reader["DonGia"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["DonGia"]),
                    SoLuong = reader["SoLuong"] == DBNull.Value ? 0 : Convert.ToInt32(reader["SoLuong"]),
                    MoTa = reader["MoTa"]?.ToString() ?? string.Empty,
                    TenLoai = reader["TenLoai"]?.ToString() ?? string.Empty,
                    TenNCC = reader["TenNCC"]?.ToString() ?? string.Empty
                });
            }

            return danhSach;
        }

        internal async Task ThemAsync(SanPhamDTO sanPham)
        {
            const string query = """
                INSERT INTO SanPham (TenSP, MaLoai, MaNCC, DonGia, SoLuong, MoTa)
                VALUES (@TenSP, @MaLoai, @MaNCC, @DonGia, @SoLuong, @MoTa);
                """;

            await using var connection = await Database.CreateOpenConnectionAsync();
            await using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TenSP", sanPham.TenSP);
            command.Parameters.AddWithValue("@MaLoai", sanPham.MaLoai);
            command.Parameters.AddWithValue("@MaNCC", sanPham.MaNCC);
            command.Parameters.AddWithValue("@DonGia", sanPham.DonGia);
            command.Parameters.AddWithValue("@SoLuong", sanPham.SoLuong);
            command.Parameters.AddWithValue("@MoTa", string.IsNullOrWhiteSpace(sanPham.MoTa) ? DBNull.Value : sanPham.MoTa);
            await command.ExecuteNonQueryAsync();
        }

        internal async Task CapNhatAsync(SanPhamDTO sanPham)
        {
            const string query = """
                UPDATE SanPham
                SET TenSP = @TenSP,
                    MaLoai = @MaLoai,
                    MaNCC = @MaNCC,
                    DonGia = @DonGia,
                    SoLuong = @SoLuong,
                    MoTa = @MoTa
                WHERE MaSP = @MaSP;
                """;

            await using var connection = await Database.CreateOpenConnectionAsync();
            await using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TenSP", sanPham.TenSP);
            command.Parameters.AddWithValue("@MaLoai", sanPham.MaLoai);
            command.Parameters.AddWithValue("@MaNCC", sanPham.MaNCC);
            command.Parameters.AddWithValue("@DonGia", sanPham.DonGia);
            command.Parameters.AddWithValue("@SoLuong", sanPham.SoLuong);
            command.Parameters.AddWithValue("@MoTa", string.IsNullOrWhiteSpace(sanPham.MoTa) ? DBNull.Value : sanPham.MoTa);
            command.Parameters.AddWithValue("@MaSP", sanPham.MaSP);
            await command.ExecuteNonQueryAsync();
        }

        internal async Task XoaAsync(int maSP)
        {
            const string query = "DELETE FROM SanPham WHERE MaSP = @MaSP;";

            await using var connection = await Database.CreateOpenConnectionAsync();
            await using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@MaSP", maSP);
            await command.ExecuteNonQueryAsync();
        }
    }
}
