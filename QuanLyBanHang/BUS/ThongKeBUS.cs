using QuanLyBanHang.DAL;
using QuanLyBanHang.DTO;

namespace QuanLyBanHang.BUS
{
    internal class ThongKeBUS
    {
        private readonly ThongKeDAL _thongKeDal = new();

        internal async Task<(ThongKeDoanhThuDTO TongHop, List<HoaDonDTO> HoaDons)> GetBaoCaoAsync(DateTime tuNgay, DateTime denNgay)
        {
            if (tuNgay.Date > denNgay.Date)
            {
                throw new ArgumentException("Từ ngày không được lớn hơn đến ngày.");
            }

            var batDau = tuNgay.Date;
            var ketThuc = denNgay.Date.AddDays(1);

            var tongHop = await _thongKeDal.GetTongHopAsync(batDau, ketThuc);
            var hoaDons = await _thongKeDal.GetHoaDonsAsync(batDau, ketThuc);
            return (tongHop, hoaDons);
        }
    }
}
