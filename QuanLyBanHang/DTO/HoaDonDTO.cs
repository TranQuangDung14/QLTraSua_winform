namespace QuanLyBanHang.DTO
{
    public class HoaDonDTO
    {
        public int MaHD { get; set; }

        public int MaNV { get; set; }

        public int MaKH { get; set; }

        public DateTime NgayLap { get; set; }

        public decimal TongTien { get; set; }

        public string HoTenNhanVien { get; set; } = string.Empty;

        public string HoTenKhachHang { get; set; } = string.Empty;
    }
}
