using QuanLyBanHang.BUS;
using QuanLyBanHang.DTO;

namespace QuanLyBanHang.GUI
{
    public partial class frmThongKeDoanhThu : Form
    {
        private readonly ThongKeBUS _thongKeBus = new();

        public frmThongKeDoanhThu()
        {
            InitializeComponent();
            ResponsiveLayout.Configure(this);
        }

        private async void frmThongKeDoanhThu_Load(object sender, EventArgs e)
        {
            var homNay = DateTime.Today;
            dtpTuNgay.Value = new DateTime(homNay.Year, homNay.Month, 1);
            dtpDenNgay.Value = homNay;
            await TaiBaoCaoAsync();
        }

        private async Task TaiBaoCaoAsync()
        {
            try
            {
                var ketQua = await _thongKeBus.GetBaoCaoAsync(dtpTuNgay.Value, dtpDenNgay.Value);
                lblSoHoaDon.Text = ketQua.TongHop.SoHoaDon.ToString();
                lblTongDoanhThu.Text = $"{ketQua.TongHop.TongDoanhThu:N0} VNĐ";
                lblTrungBinh.Text = $"{ketQua.TongHop.HoaDonTrungBinh:N0} VNĐ";

                dgvThongKe.DataSource = ketQua.HoaDons;
                DinhDangLuoi();
                ThongBao("Đã cập nhật báo cáo doanh thu.");
            }
            catch (ArgumentException ex)
            {
                BaoLoi(ex.Message);
            }
            catch (Exception ex)
            {
                BaoLoi($"Không thể tải báo cáo: {ex.Message}");
            }
        }

        private void DinhDangLuoi()
        {
            if (dgvThongKe.Columns.Count == 0)
            {
                return;
            }

            dgvThongKe.Columns[nameof(HoaDonDTO.MaHD)].HeaderText = "Mã HĐ";
            dgvThongKe.Columns[nameof(HoaDonDTO.MaHD)].Width = 90;
            dgvThongKe.Columns[nameof(HoaDonDTO.MaNV)].Visible = false;
            dgvThongKe.Columns[nameof(HoaDonDTO.MaKH)].Visible = false;
            dgvThongKe.Columns[nameof(HoaDonDTO.NgayLap)].HeaderText = "Ngày lập";
            dgvThongKe.Columns[nameof(HoaDonDTO.NgayLap)].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            dgvThongKe.Columns[nameof(HoaDonDTO.NgayLap)].Width = 140;
            dgvThongKe.Columns[nameof(HoaDonDTO.HoTenNhanVien)].HeaderText = "Nhân viên";
            dgvThongKe.Columns[nameof(HoaDonDTO.HoTenNhanVien)].Width = 150;
            dgvThongKe.Columns[nameof(HoaDonDTO.HoTenKhachHang)].HeaderText = "Khách hàng";
            dgvThongKe.Columns[nameof(HoaDonDTO.HoTenKhachHang)].Width = 170;
            dgvThongKe.Columns[nameof(HoaDonDTO.TongTien)].HeaderText = "Tổng tiền";
            dgvThongKe.Columns[nameof(HoaDonDTO.TongTien)].DefaultCellStyle.Format = "N0";
            dgvThongKe.Columns[nameof(HoaDonDTO.TongTien)].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private async void btnThongKe_Click(object sender, EventArgs e)
        {
            await TaiBaoCaoAsync();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ThongBao(string message)
        {
            lblThongBao.ForeColor = Color.FromArgb(13, 148, 136);
            lblThongBao.Text = message;
        }

        private void BaoLoi(string message)
        {
            lblThongBao.ForeColor = Color.FromArgb(220, 38, 38);
            lblThongBao.Text = message;
        }
    }
}
