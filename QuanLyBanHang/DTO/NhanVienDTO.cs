namespace QuanLyBanHang.DTO
{
    public class NhanVienDTO
    {
        public int MaNV { get; set; }

        public string HoTen { get; set; } = string.Empty;

        public string GioiTinh { get; set; } = string.Empty;

        public DateTime? NgaySinh { get; set; }

        public string SoDienThoai { get; set; } = string.Empty;

        public string DiaChi { get; set; } = string.Empty;

        public string ChucVu { get; set; } = string.Empty;

        public int? MaTK { get; set; }

        public string TenDangNhap { get; set; } = string.Empty;

        public string MatKhau { get; set; } = string.Empty;

        public string Quyen { get; set; } = string.Empty;
    }
}
