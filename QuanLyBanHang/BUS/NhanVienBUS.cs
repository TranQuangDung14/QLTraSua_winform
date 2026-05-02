using QuanLyBanHang.DAL;
using QuanLyBanHang.DTO;

namespace QuanLyBanHang.BUS
{
    internal class NhanVienBUS
    {
        private readonly NhanVienDAL _nhanVienDal = new();

        internal Task<List<NhanVienDTO>> GetDanhSachAsync(string tuKhoa = "")
        {
            return _nhanVienDal.GetDanhSachAsync(tuKhoa.Trim());
        }

        internal Task ThemAsync(
            string hoTen,
            string gioiTinh,
            DateTime? ngaySinh,
            string soDienThoai,
            string diaChi,
            string chucVu,
            string tenDangNhap,
            string matKhau,
            string quyen)
        {
            KiemTraHopLe(hoTen, tenDangNhap, matKhau, quyen);

            return _nhanVienDal.ThemAsync(new NhanVienDTO
            {
                HoTen = hoTen.Trim(),
                GioiTinh = gioiTinh.Trim(),
                NgaySinh = ngaySinh,
                SoDienThoai = soDienThoai.Trim(),
                DiaChi = diaChi.Trim(),
                ChucVu = chucVu.Trim(),
                TenDangNhap = tenDangNhap.Trim(),
                MatKhau = matKhau.Trim(),
                Quyen = quyen.Trim()
            });
        }

        internal Task CapNhatAsync(
            int maNV,
            string hoTen,
            string gioiTinh,
            DateTime? ngaySinh,
            string soDienThoai,
            string diaChi,
            string chucVu,
            string tenDangNhap,
            string matKhau,
            string quyen)
        {
            if (maNV <= 0)
            {
                throw new ArgumentException("Vui lòng chọn nhân viên cần cập nhật.");
            }

            KiemTraHopLe(hoTen, tenDangNhap, matKhau, quyen);

            return _nhanVienDal.CapNhatAsync(new NhanVienDTO
            {
                MaNV = maNV,
                HoTen = hoTen.Trim(),
                GioiTinh = gioiTinh.Trim(),
                NgaySinh = ngaySinh,
                SoDienThoai = soDienThoai.Trim(),
                DiaChi = diaChi.Trim(),
                ChucVu = chucVu.Trim(),
                TenDangNhap = tenDangNhap.Trim(),
                MatKhau = matKhau.Trim(),
                Quyen = quyen.Trim()
            });
        }

        internal Task XoaAsync(int maNV)
        {
            if (maNV <= 0)
            {
                throw new ArgumentException("Vui lòng chọn nhân viên cần xóa.");
            }

            return _nhanVienDal.XoaAsync(maNV);
        }

        private static void KiemTraHopLe(string hoTen, string tenDangNhap, string matKhau, string quyen)
        {
            if (string.IsNullOrWhiteSpace(hoTen))
            {
                throw new ArgumentException("Vui lòng nhập họ tên nhân viên.");
            }

            var coTaiKhoan = !string.IsNullOrWhiteSpace(tenDangNhap) || !string.IsNullOrWhiteSpace(matKhau);
            if (!coTaiKhoan)
            {
                return;
            }

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
                throw new ArgumentException("Vui lòng chọn quyền tài khoản.");
            }
        }
    }
}
