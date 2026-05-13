using Microsoft.Data.SqlClient;
using QuanLyBanHang.BUS;
using QuanLyBanHang.DTO;

namespace QuanLyBanHang.GUI
{
    public partial class frmKhachHang : Form
    {
        private readonly KhachHangBUS _khachHangBus = new();
        private bool _dangTaiDuLieu;

        public frmKhachHang()
        {
            InitializeComponent();
            ResponsiveLayout.Configure(this);
        }

        private async void frmKhachHang_Load(object sender, EventArgs e)
        {
            await TaiDanhSachAsync();
        }

        private async Task TaiDanhSachAsync(string tuKhoa = "")
        {
            _dangTaiDuLieu = true;

            try
            {
                var danhSach = await _khachHangBus.GetDanhSachAsync(tuKhoa);
                dgvKhachHang.DataSource = danhSach;
                DinhDangLuoi();

                if (danhSach.Count > 0)
                {
                    dgvKhachHang.Rows[0].Selected = true;
                    dgvKhachHang.CurrentCell = dgvKhachHang.Rows[0].Cells[nameof(KhachHangDTO.HoTen)];
                    GanDuLieuTuDong();
                }
                else
                {
                    XoaNhapLieu(false);
                }
            }
            finally
            {
                _dangTaiDuLieu = false;
            }
        }

        private void DinhDangLuoi()
        {
            if (dgvKhachHang.Columns.Count == 0)
            {
                return;
            }

            dgvKhachHang.Columns[nameof(KhachHangDTO.MaKH)].HeaderText = "Mã KH";
            dgvKhachHang.Columns[nameof(KhachHangDTO.MaKH)].Width = 90;
            dgvKhachHang.Columns[nameof(KhachHangDTO.HoTen)].HeaderText = "Họ tên khách hàng";
            dgvKhachHang.Columns[nameof(KhachHangDTO.HoTen)].Width = 220;
            dgvKhachHang.Columns[nameof(KhachHangDTO.SoDienThoai)].HeaderText = "Số điện thoại";
            dgvKhachHang.Columns[nameof(KhachHangDTO.SoDienThoai)].Width = 140;
            dgvKhachHang.Columns[nameof(KhachHangDTO.DiaChi)].HeaderText = "Địa chỉ";
            dgvKhachHang.Columns[nameof(KhachHangDTO.DiaChi)].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void GanDuLieuTuDong()
        {
            if (dgvKhachHang.CurrentRow?.DataBoundItem is not KhachHangDTO khachHang)
            {
                return;
            }

            txtMaKH.Text = khachHang.MaKH.ToString();
            txtHoTen.Text = khachHang.HoTen;
            txtSoDienThoai.Text = khachHang.SoDienThoai;
            txtDiaChi.Text = khachHang.DiaChi;
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                var hoTen = txtHoTen.Text.Trim();
                await _khachHangBus.ThemAsync(hoTen, txtSoDienThoai.Text, txtDiaChi.Text);
                await TaiDanhSachAsync(txtTimKiem.Text);
                TimDongTheoTen(hoTen);
                ThongBao("Thêm khách hàng thành công.");
            }
            catch (ArgumentException ex)
            {
                BaoLoi(ex.Message);
            }
            catch (Exception ex)
            {
                BaoLoi($"Không thể thêm khách hàng: {ex.Message}");
            }
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtMaKH.Text, out var maKH) || maKH <= 0)
            {
                BaoLoi("Vui lòng chọn khách hàng cần sửa.");
                return;
            }

            try
            {
                await _khachHangBus.CapNhatAsync(
                    maKH,
                    txtHoTen.Text,
                    txtSoDienThoai.Text,
                    txtDiaChi.Text);

                await TaiDanhSachAsync(txtTimKiem.Text);
                TimDongTheoMa(maKH.ToString());
                ThongBao("Cập nhật khách hàng thành công.");
            }
            catch (ArgumentException ex)
            {
                BaoLoi(ex.Message);
            }
            catch (Exception ex)
            {
                BaoLoi($"Không thể cập nhật khách hàng: {ex.Message}");
            }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                    $"Bạn có chắc muốn xóa khách hàng \"{txtHoTen.Text}\" không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                await _khachHangBus.XoaAsync(int.TryParse(txtMaKH.Text, out var maKH) ? maKH : 0);
                await TaiDanhSachAsync(txtTimKiem.Text);
                ThongBao("Xóa khách hàng thành công.");
            }
            catch (ArgumentException ex)
            {
                BaoLoi(ex.Message);
            }
            catch (SqlException)
            {
                BaoLoi("Không thể xóa vì khách hàng đang được sử dụng trong hóa đơn.");
            }
            catch (Exception ex)
            {
                BaoLoi($"Không thể xóa khách hàng: {ex.Message}");
            }
        }

        private async void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            XoaNhapLieu();
            await TaiDanhSachAsync();
            txtHoTen.Focus();
            ThongBao("Đã làm mới dữ liệu.");
        }

        private async void btnTimKiem_Click(object sender, EventArgs e)
        {
            await TaiDanhSachAsync(txtTimKiem.Text);
            if (dgvKhachHang.Rows.Count == 0)
            {
                BaoLoi("Không tìm thấy khách hàng phù hợp.");
                return;
            }

            ThongBao("Đã cập nhật danh sách tìm kiếm.");
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvKhachHang_SelectionChanged(object sender, EventArgs e)
        {
            if (_dangTaiDuLieu)
            {
                return;
            }

            GanDuLieuTuDong();
        }

        private void XoaNhapLieu(bool focusHoTen = true)
        {
            txtMaKH.Clear();
            txtHoTen.Clear();
            txtSoDienThoai.Clear();
            txtDiaChi.Clear();
            if (focusHoTen)
            {
                txtHoTen.Focus();
            }
        }

        private void TimDongTheoMa(string maKH)
        {
            foreach (DataGridViewRow row in dgvKhachHang.Rows)
            {
                if (row.Cells[nameof(KhachHangDTO.MaKH)].Value?.ToString() == maKH)
                {
                    row.Selected = true;
                    dgvKhachHang.CurrentCell = row.Cells[nameof(KhachHangDTO.HoTen)];
                    return;
                }
            }
        }

        private void TimDongTheoTen(string hoTen)
        {
            foreach (DataGridViewRow row in dgvKhachHang.Rows)
            {
                if (string.Equals(row.Cells[nameof(KhachHangDTO.HoTen)].Value?.ToString(), hoTen, StringComparison.CurrentCultureIgnoreCase))
                {
                    row.Selected = true;
                    dgvKhachHang.CurrentCell = row.Cells[nameof(KhachHangDTO.HoTen)];
                    return;
                }
            }
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
