namespace QuanLyBanHang.DTO
{
    public class SanPhamDTO
    {
        public int MaSP { get; set; }

        public string TenSP { get; set; } = string.Empty;

        public int MaLoai { get; set; }

        public int MaNCC { get; set; }

        public decimal DonGia { get; set; }

        public int SoLuong { get; set; }

        public string MoTa { get; set; } = string.Empty;

        public string TenLoai { get; set; } = string.Empty;

        public string TenNCC { get; set; } = string.Empty;
    }
}
