using QuanLyBanHang.DAL;
using QuanLyBanHang.DTO;

namespace QuanLyBanHang.BUS
{
    internal class KhachHangBUS
    {
        private readonly KhachHangDAL _khachHangDal = new();

        internal Task<List<KhachHangDTO>> GetDanhSachAsync(string tuKhoa = "")
        {
            return _khachHangDal.GetDanhSachAsync(tuKhoa.Trim());
        }

        internal Task ThemAsync(string hoTen, string soDienThoai, string diaChi)
        {
            if (string.IsNullOrWhiteSpace(hoTen))
            {
                throw new ArgumentException("Vui lòng nhập họ tên khách hàng.");
            }

            return _khachHangDal.ThemAsync(new KhachHangDTO
            {
                HoTen = hoTen.Trim(),
                SoDienThoai = soDienThoai.Trim(),
                DiaChi = diaChi.Trim()
            });
        }

        internal Task CapNhatAsync(int maKH, string hoTen, string soDienThoai, string diaChi)
        {
            if (maKH <= 0)
            {
                throw new ArgumentException("Vui lòng chọn khách hàng cần cập nhật.");
            }

            if (string.IsNullOrWhiteSpace(hoTen))
            {
                throw new ArgumentException("Vui lòng nhập họ tên khách hàng.");
            }

            return _khachHangDal.CapNhatAsync(new KhachHangDTO
            {
                MaKH = maKH,
                HoTen = hoTen.Trim(),
                SoDienThoai = soDienThoai.Trim(),
                DiaChi = diaChi.Trim()
            });
        }

        internal Task XoaAsync(int maKH)
        {
            if (maKH <= 0)
            {
                throw new ArgumentException("Vui lòng chọn khách hàng cần xóa.");
            }

            return _khachHangDal.XoaAsync(maKH);
        }
    }
}
