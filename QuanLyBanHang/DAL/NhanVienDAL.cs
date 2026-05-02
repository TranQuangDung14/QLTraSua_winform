using Microsoft.Data.SqlClient;
using QuanLyBanHang.DTO;

namespace QuanLyBanHang.DAL
{
    internal class NhanVienDAL
    {
        internal async Task<List<NhanVienDTO>> GetDanhSachAsync(string tuKhoa)
        {
            const string query = """
                SELECT
                    nv.MaNV,
                    nv.HoTen,
                    ISNULL(nv.GioiTinh, '') AS GioiTinh,
                    nv.NgaySinh,
                    ISNULL(nv.SoDienThoai, '') AS SoDienThoai,
                    ISNULL(nv.DiaChi, '') AS DiaChi,
                    ISNULL(nv.ChucVu, '') AS ChucVu,
                    tk.MaTK,
                    ISNULL(tk.TenDangNhap, '') AS TenDangNhap,
                    ISNULL(tk.MatKhau, '') AS MatKhau,
                    ISNULL(tk.Quyen, '') AS Quyen
                FROM NhanVien nv
                LEFT JOIN TaiKhoan tk ON tk.MaNV = nv.MaNV
                WHERE (@TuKhoa = '' OR nv.HoTen LIKE '%' + @TuKhoa + '%')
                ORDER BY nv.MaNV DESC;
                """;

            var danhSach = new List<NhanVienDTO>();

            await using var connection = await Database.CreateOpenConnectionAsync();
            await using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TuKhoa", tuKhoa);

            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                danhSach.Add(new NhanVienDTO
                {
                    MaNV = reader.GetInt32(reader.GetOrdinal("MaNV")),
                    HoTen = reader["HoTen"]?.ToString() ?? string.Empty,
                    GioiTinh = reader["GioiTinh"]?.ToString() ?? string.Empty,
                    NgaySinh = reader["NgaySinh"] == DBNull.Value ? null : Convert.ToDateTime(reader["NgaySinh"]),
                    SoDienThoai = reader["SoDienThoai"]?.ToString() ?? string.Empty,
                    DiaChi = reader["DiaChi"]?.ToString() ?? string.Empty,
                    ChucVu = reader["ChucVu"]?.ToString() ?? string.Empty,
                    MaTK = reader["MaTK"] == DBNull.Value ? null : Convert.ToInt32(reader["MaTK"]),
                    TenDangNhap = reader["TenDangNhap"]?.ToString() ?? string.Empty,
                    MatKhau = reader["MatKhau"]?.ToString() ?? string.Empty,
                    Quyen = reader["Quyen"]?.ToString() ?? string.Empty
                });
            }

            return danhSach;
        }

        internal async Task ThemAsync(NhanVienDTO nhanVien)
        {
            await using var connection = await Database.CreateOpenConnectionAsync();
            await using var transaction = await connection.BeginTransactionAsync();

            try
            {
                const string insertNhanVien = """
                    INSERT INTO NhanVien (HoTen, GioiTinh, NgaySinh, SoDienThoai, DiaChi, ChucVu)
                    OUTPUT INSERTED.MaNV
                    VALUES (@HoTen, @GioiTinh, @NgaySinh, @SoDienThoai, @DiaChi, @ChucVu);
                    """;

                await using var commandNhanVien = new SqlCommand(insertNhanVien, connection, (SqlTransaction)transaction);
                commandNhanVien.Parameters.AddWithValue("@HoTen", nhanVien.HoTen);
                commandNhanVien.Parameters.AddWithValue("@GioiTinh", string.IsNullOrWhiteSpace(nhanVien.GioiTinh) ? DBNull.Value : nhanVien.GioiTinh);
                commandNhanVien.Parameters.AddWithValue("@NgaySinh", nhanVien.NgaySinh.HasValue ? nhanVien.NgaySinh.Value : DBNull.Value);
                commandNhanVien.Parameters.AddWithValue("@SoDienThoai", string.IsNullOrWhiteSpace(nhanVien.SoDienThoai) ? DBNull.Value : nhanVien.SoDienThoai);
                commandNhanVien.Parameters.AddWithValue("@DiaChi", string.IsNullOrWhiteSpace(nhanVien.DiaChi) ? DBNull.Value : nhanVien.DiaChi);
                commandNhanVien.Parameters.AddWithValue("@ChucVu", string.IsNullOrWhiteSpace(nhanVien.ChucVu) ? DBNull.Value : nhanVien.ChucVu);

                var maNV = Convert.ToInt32(await commandNhanVien.ExecuteScalarAsync());

                await LuuTaiKhoanAsync(connection, (SqlTransaction)transaction, maNV, nhanVien);

                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        internal async Task CapNhatAsync(NhanVienDTO nhanVien)
        {
            await using var connection = await Database.CreateOpenConnectionAsync();
            await using var transaction = await connection.BeginTransactionAsync();

            try
            {
                const string updateNhanVien = """
                    UPDATE NhanVien
                    SET HoTen = @HoTen,
                        GioiTinh = @GioiTinh,
                        NgaySinh = @NgaySinh,
                        SoDienThoai = @SoDienThoai,
                        DiaChi = @DiaChi,
                        ChucVu = @ChucVu
                    WHERE MaNV = @MaNV;
                    """;

                await using var commandNhanVien = new SqlCommand(updateNhanVien, connection, (SqlTransaction)transaction);
                commandNhanVien.Parameters.AddWithValue("@HoTen", nhanVien.HoTen);
                commandNhanVien.Parameters.AddWithValue("@GioiTinh", string.IsNullOrWhiteSpace(nhanVien.GioiTinh) ? DBNull.Value : nhanVien.GioiTinh);
                commandNhanVien.Parameters.AddWithValue("@NgaySinh", nhanVien.NgaySinh.HasValue ? nhanVien.NgaySinh.Value : DBNull.Value);
                commandNhanVien.Parameters.AddWithValue("@SoDienThoai", string.IsNullOrWhiteSpace(nhanVien.SoDienThoai) ? DBNull.Value : nhanVien.SoDienThoai);
                commandNhanVien.Parameters.AddWithValue("@DiaChi", string.IsNullOrWhiteSpace(nhanVien.DiaChi) ? DBNull.Value : nhanVien.DiaChi);
                commandNhanVien.Parameters.AddWithValue("@ChucVu", string.IsNullOrWhiteSpace(nhanVien.ChucVu) ? DBNull.Value : nhanVien.ChucVu);
                commandNhanVien.Parameters.AddWithValue("@MaNV", nhanVien.MaNV);
                await commandNhanVien.ExecuteNonQueryAsync();

                await LuuTaiKhoanAsync(connection, (SqlTransaction)transaction, nhanVien.MaNV, nhanVien);

                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        internal async Task XoaAsync(int maNV)
        {
            await using var connection = await Database.CreateOpenConnectionAsync();
            await using var transaction = await connection.BeginTransactionAsync();

            try
            {
                await using (var commandTaiKhoan = new SqlCommand("DELETE FROM TaiKhoan WHERE MaNV = @MaNV;", connection, (SqlTransaction)transaction))
                {
                    commandTaiKhoan.Parameters.AddWithValue("@MaNV", maNV);
                    await commandTaiKhoan.ExecuteNonQueryAsync();
                }

                await using (var commandNhanVien = new SqlCommand("DELETE FROM NhanVien WHERE MaNV = @MaNV;", connection, (SqlTransaction)transaction))
                {
                    commandNhanVien.Parameters.AddWithValue("@MaNV", maNV);
                    await commandNhanVien.ExecuteNonQueryAsync();
                }

                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        private static async Task LuuTaiKhoanAsync(SqlConnection connection, SqlTransaction transaction, int maNV, NhanVienDTO nhanVien)
        {
            var coTaiKhoan = !string.IsNullOrWhiteSpace(nhanVien.TenDangNhap) || !string.IsNullOrWhiteSpace(nhanVien.MatKhau);

            if (!coTaiKhoan)
            {
                await using var commandDelete = new SqlCommand("DELETE FROM TaiKhoan WHERE MaNV = @MaNV;", connection, transaction);
                commandDelete.Parameters.AddWithValue("@MaNV", maNV);
                await commandDelete.ExecuteNonQueryAsync();
                return;
            }

            await using var commandExists = new SqlCommand("SELECT COUNT(*) FROM TaiKhoan WHERE MaNV = @MaNV;", connection, transaction);
            commandExists.Parameters.AddWithValue("@MaNV", maNV);
            var exists = Convert.ToInt32(await commandExists.ExecuteScalarAsync()) > 0;

            var query = exists
                ? """
                    UPDATE TaiKhoan
                    SET TenDangNhap = @TenDangNhap,
                        MatKhau = @MatKhau,
                        Quyen = @Quyen
                    WHERE MaNV = @MaNV;
                    """
                : """
                    INSERT INTO TaiKhoan (TenDangNhap, MatKhau, Quyen, MaNV)
                    VALUES (@TenDangNhap, @MatKhau, @Quyen, @MaNV);
                    """;

            await using var commandSave = new SqlCommand(query, connection, transaction);
            commandSave.Parameters.AddWithValue("@TenDangNhap", nhanVien.TenDangNhap);
            commandSave.Parameters.AddWithValue("@MatKhau", nhanVien.MatKhau);
            commandSave.Parameters.AddWithValue("@Quyen", nhanVien.Quyen);
            commandSave.Parameters.AddWithValue("@MaNV", maNV);
            await commandSave.ExecuteNonQueryAsync();
        }
    }
}
