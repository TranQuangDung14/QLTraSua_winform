using QuanLyBanHang.DAL;
using QuanLyBanHang.DTO;

namespace QuanLyBanHang.BUS
{
    internal class HoaDonBUS
    {
        private readonly HoaDonDAL _hoaDonDal = new();

        internal Task<List<HoaDonDTO>> GetDanhSachAsync(string tuKhoa = "")
        {
            return _hoaDonDal.GetDanhSachAsync(tuKhoa.Trim());
        }

        internal Task<List<ChiTietHoaDonDTO>> GetChiTietAsync(int maHD)
        {
            if (maHD <= 0)
            {
                throw new ArgumentException("Vui lòng chọn hóa đơn cần xem.");
            }

            return _hoaDonDal.GetChiTietAsync(maHD);
        }

        internal Task<int> ThemHoaDonAsync(int maNV, int maKH, DateTime ngayLap, List<ChiTietHoaDonDTO> chiTietHoaDons)
        {
            if (maNV <= 0)
            {
                throw new ArgumentException("Vui lòng chọn nhân viên lập hóa đơn.");
            }

            if (chiTietHoaDons.Count == 0)
            {
                throw new ArgumentException("Hóa đơn phải có ít nhất một sản phẩm.");
            }

            if (chiTietHoaDons.Any(x => x.SoLuong <= 0))
            {
                throw new ArgumentException("Số lượng bán phải lớn hơn 0.");
            }

            var tongTien = chiTietHoaDons.Sum(x => x.ThanhTien);

            return _hoaDonDal.ThemHoaDonAsync(new HoaDonDTO
            {
                MaNV = maNV,
                MaKH = maKH,
                NgayLap = ngayLap,
                TongTien = tongTien
            }, chiTietHoaDons);
        }

        internal Task XoaHoaDonAsync(int maHD)
        {
            if (maHD <= 0)
            {
                throw new ArgumentException("Vui lòng chọn hóa đơn cần xóa.");
            }

            return _hoaDonDal.XoaHoaDonAsync(maHD);
        }
    }
}
