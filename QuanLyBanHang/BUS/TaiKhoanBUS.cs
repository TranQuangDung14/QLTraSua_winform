using QuanLyBanHang.DAL;
using QuanLyBanHang.DTO;

namespace QuanLyBanHang.BUS
{
    internal class TaiKhoanBUS
    {
        private readonly TaiKhoanDAL _taiKhoanDal = new();

        internal async Task<TaiKhoanDTO?> DangNhapAsync(string tenDangNhap, string matKhau, string quyen)
        {
            if (string.IsNullOrWhiteSpace(tenDangNhap))
            {
                throw new ArgumentException("Vui lòng nhập tên đăng nhập.");
            }

            if (string.IsNullOrWhiteSpace(matKhau))
            {
                throw new ArgumentException("Vui lòng nhập mật khẩu.");
            }

            if (string.IsNullOrWhiteSpace(quyen))
            {
                throw new ArgumentException("Vui lòng chọn quyền đăng nhập.");
            }

            return await _taiKhoanDal.DangNhapAsync(tenDangNhap.Trim(), matKhau.Trim(), quyen.Trim());
        }
    }
}
