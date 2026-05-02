namespace QuanLyBanHang.DTO
{
    public class ChiTietHoaDonDTO
    {
        public int MaCTHD { get; set; }

        public int MaHD { get; set; }

        public int MaSP { get; set; }

        public string TenSP { get; set; } = string.Empty;

        public int SoLuong { get; set; }

        public decimal DonGia { get; set; }

        public decimal ThanhTien { get; set; }

        public DateTime? NgayLap { get; set; }

        public string HoTenNhanVien { get; set; } = string.Empty;

        public string HoTenKhachHang { get; set; } = string.Empty;
    }
}
