using QuanLyBanHang.DAL;
using QuanLyBanHang.DTO;

namespace QuanLyBanHang.BUS
{
    internal class ChiTietHoaDonBUS
    {
        private readonly ChiTietHoaDonDAL _chiTietHoaDonDal = new();

        internal Task<List<ChiTietHoaDonDTO>> GetDanhSachAsync(string tuKhoa = "")
        {
            return _chiTietHoaDonDal.GetDanhSachAsync(tuKhoa.Trim());
        }

        internal Task<List<ChiTietHoaDonDTO>> GetTheoHoaDonAsync(int maHD)
        {
            if (maHD <= 0)
            {
                throw new ArgumentException("Vui lòng chọn hóa đơn cần in.");
            }

            return _chiTietHoaDonDal.GetTheoHoaDonAsync(maHD);
        }

        internal Task XoaAsync(int maCTHD)
        {
            if (maCTHD <= 0)
            {
                throw new ArgumentException("Vui lòng chọn chi tiết hóa đơn cần xóa.");
            }

            return _chiTietHoaDonDal.XoaAsync(maCTHD);
        }
    }
}
