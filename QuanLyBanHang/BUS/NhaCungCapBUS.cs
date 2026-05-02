using QuanLyBanHang.DAL;
using QuanLyBanHang.DTO;

namespace QuanLyBanHang.BUS
{
    internal class NhaCungCapBUS
    {
        private readonly NhaCungCapDAL _nhaCungCapDal = new();

        internal Task<List<NhaCungCapDTO>> GetDanhSachAsync(string tuKhoa = "")
        {
            return _nhaCungCapDal.GetDanhSachAsync(tuKhoa.Trim());
        }

        internal Task ThemAsync(string tenNCC, string diaChi, string soDienThoai, string email)
        {
            KiemTraHopLe(tenNCC, email);

            return _nhaCungCapDal.ThemAsync(new NhaCungCapDTO
            {
                TenNCC = tenNCC.Trim(),
                DiaChi = diaChi.Trim(),
                SoDienThoai = soDienThoai.Trim(),
                Email = email.Trim()
            });
        }

        internal Task CapNhatAsync(int maNCC, string tenNCC, string diaChi, string soDienThoai, string email)
        {
            if (maNCC <= 0)
            {
                throw new ArgumentException("Vui lòng chọn nhà cung cấp cần cập nhật.");
            }

            KiemTraHopLe(tenNCC, email);

            return _nhaCungCapDal.CapNhatAsync(new NhaCungCapDTO
            {
                MaNCC = maNCC,
                TenNCC = tenNCC.Trim(),
                DiaChi = diaChi.Trim(),
                SoDienThoai = soDienThoai.Trim(),
                Email = email.Trim()
            });
        }

        internal Task XoaAsync(int maNCC)
        {
            if (maNCC <= 0)
            {
                throw new ArgumentException("Vui lòng chọn nhà cung cấp cần xóa.");
            }

            return _nhaCungCapDal.XoaAsync(maNCC);
        }

        private static void KiemTraHopLe(string tenNCC, string email)
        {
            if (string.IsNullOrWhiteSpace(tenNCC))
            {
                throw new ArgumentException("Vui lòng nhập tên nhà cung cấp.");
            }

            if (!string.IsNullOrWhiteSpace(email) && !email.Contains('@'))
            {
                throw new ArgumentException("Email chưa đúng định dạng cơ bản.");
            }
        }
    }
}
