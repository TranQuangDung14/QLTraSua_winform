using QuanLyBanHang.BUS;
using QuanLyBanHang.DTO;

namespace QuanLyBanHang.GUI
{
    public partial class frmChiTietHoaDon : Form
    {
        private readonly ChiTietHoaDonBUS _chiTietHoaDonBus = new();
        private bool _dangTaiDuLieu;

        public frmChiTietHoaDon()
        {
            InitializeComponent();
        }

        private async void frmChiTietHoaDon_Load(object sender, EventArgs e)
        {
            await TaiDanhSachAsync();
        }

        private async Task TaiDanhSachAsync(string tuKhoa = "")
        {
            _dangTaiDuLieu = true;

            try
            {
                var danhSach = await _chiTietHoaDonBus.GetDanhSachAsync(tuKhoa);
                dgvChiTietHoaDon.DataSource = danhSach;
                DinhDangLuoi();

                if (danhSach.Count > 0)
                {
                    dgvChiTietHoaDon.Rows[0].Selected = true;
                    dgvChiTietHoaDon.CurrentCell = dgvChiTietHoaDon.Rows[0].Cells[nameof(ChiTietHoaDonDTO.MaCTHD)];
                    GanDuLieuLenForm();
                }
                else
                {
                    XoaNhapLieu();
                    lblThongBao.Text = "Chưa có chi tiết hóa đơn.";
                }
            }
            finally
            {
                _dangTaiDuLieu = false;
            }
        }

        private void DinhDangLuoi()
        {
            if (dgvChiTietHoaDon.Columns.Count == 0)
            {
                return;
            }

            dgvChiTietHoaDon.Columns[nameof(ChiTietHoaDonDTO.MaCTHD)].HeaderText = "Mã CTHĐ";
            dgvChiTietHoaDon.Columns[nameof(ChiTietHoaDonDTO.MaCTHD)].Width = 90;
            dgvChiTietHoaDon.Columns[nameof(ChiTietHoaDonDTO.MaHD)].HeaderText = "Mã HĐ";
            dgvChiTietHoaDon.Columns[nameof(ChiTietHoaDonDTO.MaHD)].Width = 80;
            dgvChiTietHoaDon.Columns[nameof(ChiTietHoaDonDTO.MaSP)].HeaderText = "Mã SP";
            dgvChiTietHoaDon.Columns[nameof(ChiTietHoaDonDTO.MaSP)].Width = 80;
            dgvChiTietHoaDon.Columns[nameof(ChiTietHoaDonDTO.TenSP)].HeaderText = "Sản phẩm";
            dgvChiTietHoaDon.Columns[nameof(ChiTietHoaDonDTO.TenSP)].Width = 170;
            dgvChiTietHoaDon.Columns[nameof(ChiTietHoaDonDTO.SoLuong)].HeaderText = "Số lượng";
            dgvChiTietHoaDon.Columns[nameof(ChiTietHoaDonDTO.SoLuong)].Width = 85;
            dgvChiTietHoaDon.Columns[nameof(ChiTietHoaDonDTO.DonGia)].HeaderText = "Đơn giá";
            dgvChiTietHoaDon.Columns[nameof(ChiTietHoaDonDTO.DonGia)].DefaultCellStyle.Format = "N0";
            dgvChiTietHoaDon.Columns[nameof(ChiTietHoaDonDTO.DonGia)].Width = 100;
            dgvChiTietHoaDon.Columns[nameof(ChiTietHoaDonDTO.ThanhTien)].HeaderText = "Thành tiền";
            dgvChiTietHoaDon.Columns[nameof(ChiTietHoaDonDTO.ThanhTien)].DefaultCellStyle.Format = "N0";
            dgvChiTietHoaDon.Columns[nameof(ChiTietHoaDonDTO.ThanhTien)].Width = 110;
            dgvChiTietHoaDon.Columns[nameof(ChiTietHoaDonDTO.NgayLap)].HeaderText = "Ngày lập";
            dgvChiTietHoaDon.Columns[nameof(ChiTietHoaDonDTO.NgayLap)].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            dgvChiTietHoaDon.Columns[nameof(ChiTietHoaDonDTO.NgayLap)].Width = 135;
            dgvChiTietHoaDon.Columns[nameof(ChiTietHoaDonDTO.HoTenNhanVien)].HeaderText = "Nhân viên";
            dgvChiTietHoaDon.Columns[nameof(ChiTietHoaDonDTO.HoTenNhanVien)].Width = 130;
            dgvChiTietHoaDon.Columns[nameof(ChiTietHoaDonDTO.HoTenKhachHang)].HeaderText = "Khách hàng";
            dgvChiTietHoaDon.Columns[nameof(ChiTietHoaDonDTO.HoTenKhachHang)].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void GanDuLieuLenForm()
        {
            if (dgvChiTietHoaDon.CurrentRow?.DataBoundItem is not ChiTietHoaDonDTO chiTiet)
            {
                return;
            }

            txtMaCTHD.Text = chiTiet.MaCTHD.ToString();
            txtMaHD.Text = chiTiet.MaHD.ToString();
            txtMaSP.Text = chiTiet.MaSP.ToString();
            txtTenSP.Text = chiTiet.TenSP;
            txtKhachHang.Text = chiTiet.HoTenKhachHang;
            txtNhanVien.Text = chiTiet.HoTenNhanVien;
            txtNgayLap.Text = chiTiet.NgayLap?.ToString("dd/MM/yyyy HH:mm") ?? string.Empty;
            txtSoLuong.Text = chiTiet.SoLuong.ToString();
            txtDonGia.Text = chiTiet.DonGia.ToString("N0");
            txtThanhTien.Text = chiTiet.ThanhTien.ToString("N0");
        }

        private async void btnTimKiem_Click(object sender, EventArgs e)
        {
            await TaiDanhSachAsync(txtTimKiem.Text);
            if (dgvChiTietHoaDon.Rows.Count == 0)
            {
                BaoLoi("Không tìm thấy chi tiết hóa đơn phù hợp.");
                return;
            }

            ThongBao("Đã cập nhật danh sách chi tiết hóa đơn.");
        }

        private async void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            await TaiDanhSachAsync();
            ThongBao("Đã làm mới dữ liệu.");
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvChiTietHoaDon.CurrentRow?.DataBoundItem is not ChiTietHoaDonDTO chiTiet)
            {
                BaoLoi("Vui lòng chọn chi tiết hóa đơn cần xóa.");
                return;
            }

            var xacNhan = MessageBox.Show(
                $"Bạn có chắc muốn xóa chi tiết #{chiTiet.MaCTHD} của hóa đơn #{chiTiet.MaHD} không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (xacNhan != DialogResult.Yes)
            {
                return;
            }

            try
            {
                await _chiTietHoaDonBus.XoaAsync(chiTiet.MaCTHD);
                await TaiDanhSachAsync(txtTimKiem.Text);
                ThongBao("Đã xóa chi tiết hóa đơn thành công.");
            }
            catch (ArgumentException ex)
            {
                BaoLoi(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                BaoLoi(ex.Message);
            }
            catch (Exception ex)
            {
                BaoLoi($"Không thể xóa chi tiết hóa đơn: {ex.Message}");
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvChiTietHoaDon_SelectionChanged(object sender, EventArgs e)
        {
            if (_dangTaiDuLieu)
            {
                return;
            }

            GanDuLieuLenForm();
        }

        private void XoaNhapLieu()
        {
            txtMaCTHD.Clear();
            txtMaHD.Clear();
            txtMaSP.Clear();
            txtTenSP.Clear();
            txtKhachHang.Clear();
            txtNhanVien.Clear();
            txtNgayLap.Clear();
            txtSoLuong.Clear();
            txtDonGia.Clear();
            txtThanhTien.Clear();
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
