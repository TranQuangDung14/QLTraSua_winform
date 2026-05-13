using Microsoft.Data.SqlClient;
using QuanLyBanHang.BUS;
using QuanLyBanHang.DTO;

namespace QuanLyBanHang.GUI
{
    public partial class frmNhanVien : Form
    {
        private readonly NhanVienBUS _nhanVienBus = new();
        private bool _dangTaiDuLieu;

        public frmNhanVien()
        {
            InitializeComponent();
            ResponsiveLayout.Configure(this);
            cboGioiTinh.SelectedIndex = 0;
            cboQuyen.SelectedIndex = 0;
        }

        private async void frmNhanVien_Load(object sender, EventArgs e)
        {
            await TaiDanhSachAsync();
        }

        private async Task TaiDanhSachAsync(string tuKhoa = "")
        {
            _dangTaiDuLieu = true;

            try
            {
                var danhSach = await _nhanVienBus.GetDanhSachAsync(tuKhoa);
                dgvNhanVien.DataSource = danhSach;
                DinhDangLuoi();

                if (danhSach.Count > 0)
                {
                    dgvNhanVien.Rows[0].Selected = true;
                    dgvNhanVien.CurrentCell = dgvNhanVien.Rows[0].Cells[nameof(NhanVienDTO.HoTen)];
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
            if (dgvNhanVien.Columns.Count == 0)
            {
                return;
            }

            dgvNhanVien.Columns[nameof(NhanVienDTO.MaNV)].HeaderText = "Mã NV";
            dgvNhanVien.Columns[nameof(NhanVienDTO.MaNV)].Width = 80;
            dgvNhanVien.Columns[nameof(NhanVienDTO.HoTen)].HeaderText = "Họ tên";
            dgvNhanVien.Columns[nameof(NhanVienDTO.HoTen)].Width = 170;
            dgvNhanVien.Columns[nameof(NhanVienDTO.GioiTinh)].HeaderText = "Giới tính";
            dgvNhanVien.Columns[nameof(NhanVienDTO.GioiTinh)].Width = 90;
            dgvNhanVien.Columns[nameof(NhanVienDTO.NgaySinh)].HeaderText = "Ngày sinh";
            dgvNhanVien.Columns[nameof(NhanVienDTO.NgaySinh)].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvNhanVien.Columns[nameof(NhanVienDTO.NgaySinh)].Width = 100;
            dgvNhanVien.Columns[nameof(NhanVienDTO.SoDienThoai)].HeaderText = "Số điện thoại";
            dgvNhanVien.Columns[nameof(NhanVienDTO.SoDienThoai)].Width = 120;
            dgvNhanVien.Columns[nameof(NhanVienDTO.DiaChi)].HeaderText = "Địa chỉ";
            dgvNhanVien.Columns[nameof(NhanVienDTO.DiaChi)].Width = 160;
            dgvNhanVien.Columns[nameof(NhanVienDTO.ChucVu)].HeaderText = "Chức vụ";
            dgvNhanVien.Columns[nameof(NhanVienDTO.ChucVu)].Width = 120;
            dgvNhanVien.Columns[nameof(NhanVienDTO.MaTK)].Visible = false;
            dgvNhanVien.Columns[nameof(NhanVienDTO.TenDangNhap)].HeaderText = "Tên đăng nhập";
            dgvNhanVien.Columns[nameof(NhanVienDTO.TenDangNhap)].Width = 120;
            dgvNhanVien.Columns[nameof(NhanVienDTO.MatKhau)].Visible = false;
            dgvNhanVien.Columns[nameof(NhanVienDTO.Quyen)].HeaderText = "Quyền";
            dgvNhanVien.Columns[nameof(NhanVienDTO.Quyen)].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void GanDuLieuTuDong()
        {
            if (dgvNhanVien.CurrentRow?.DataBoundItem is not NhanVienDTO nhanVien)
            {
                return;
            }

            txtMaNV.Text = nhanVien.MaNV.ToString();
            txtHoTen.Text = nhanVien.HoTen;
            ChonCombo(cboGioiTinh, nhanVien.GioiTinh);
            if (nhanVien.NgaySinh.HasValue)
            {
                dtpNgaySinh.Checked = true;
                dtpNgaySinh.Value = nhanVien.NgaySinh.Value;
            }
            else
            {
                dtpNgaySinh.Checked = false;
            }

            txtSoDienThoai.Text = nhanVien.SoDienThoai;
            txtDiaChi.Text = nhanVien.DiaChi;
            txtChucVu.Text = nhanVien.ChucVu;
            txtTenDangNhap.Text = nhanVien.TenDangNhap;
            txtMatKhau.Text = nhanVien.MatKhau;
            ChonCombo(cboQuyen, nhanVien.Quyen);
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                var hoTen = txtHoTen.Text.Trim();
                await _nhanVienBus.ThemAsync(
                    hoTen,
                    cboGioiTinh.Text,
                    dtpNgaySinh.Checked ? dtpNgaySinh.Value.Date : null,
                    txtSoDienThoai.Text,
                    txtDiaChi.Text,
                    txtChucVu.Text,
                    txtTenDangNhap.Text,
                    txtMatKhau.Text,
                    cboQuyen.Text);

                await TaiDanhSachAsync(txtTimKiem.Text);
                TimDongTheoTen(hoTen);
                ThongBao("Thêm nhân viên thành công.");
            }
            catch (ArgumentException ex)
            {
                BaoLoi(ex.Message);
            }
            catch (SqlException ex) when (ex.Number is 2627 or 2601)
            {
                BaoLoi("Tên đăng nhập đã tồn tại.");
            }
            catch (Exception ex)
            {
                BaoLoi($"Không thể thêm nhân viên: {ex.Message}");
            }
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtMaNV.Text, out var maNV) || maNV <= 0)
            {
                BaoLoi("Vui lòng chọn nhân viên cần sửa.");
                return;
            }

            try
            {
                await _nhanVienBus.CapNhatAsync(
                    maNV,
                    txtHoTen.Text,
                    cboGioiTinh.Text,
                    dtpNgaySinh.Checked ? dtpNgaySinh.Value.Date : null,
                    txtSoDienThoai.Text,
                    txtDiaChi.Text,
                    txtChucVu.Text,
                    txtTenDangNhap.Text,
                    txtMatKhau.Text,
                    cboQuyen.Text);

                await TaiDanhSachAsync(txtTimKiem.Text);
                TimDongTheoMa(maNV.ToString());
                ThongBao("Cập nhật nhân viên thành công.");
            }
            catch (ArgumentException ex)
            {
                BaoLoi(ex.Message);
            }
            catch (SqlException ex) when (ex.Number is 2627 or 2601)
            {
                BaoLoi("Tên đăng nhập đã tồn tại.");
            }
            catch (Exception ex)
            {
                BaoLoi($"Không thể cập nhật nhân viên: {ex.Message}");
            }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                    $"Bạn có chắc muốn xóa nhân viên \"{txtHoTen.Text}\" không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                await _nhanVienBus.XoaAsync(int.TryParse(txtMaNV.Text, out var maNV) ? maNV : 0);
                await TaiDanhSachAsync(txtTimKiem.Text);
                ThongBao("Xóa nhân viên thành công.");
            }
            catch (ArgumentException ex)
            {
                BaoLoi(ex.Message);
            }
            catch (SqlException)
            {
                BaoLoi("Không thể xóa vì nhân viên đang được sử dụng trong hóa đơn.");
            }
            catch (Exception ex)
            {
                BaoLoi($"Không thể xóa nhân viên: {ex.Message}");
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
            if (dgvNhanVien.Rows.Count == 0)
            {
                BaoLoi("Không tìm thấy nhân viên phù hợp.");
                return;
            }

            ThongBao("Đã cập nhật danh sách tìm kiếm.");
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvNhanVien_SelectionChanged(object sender, EventArgs e)
        {
            if (_dangTaiDuLieu)
            {
                return;
            }

            GanDuLieuTuDong();
        }

        private void chkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = !chkHienMatKhau.Checked;
        }

        private void XoaNhapLieu(bool focusHoTen = true)
        {
            txtMaNV.Clear();
            txtHoTen.Clear();
            cboGioiTinh.SelectedIndex = 0;
            dtpNgaySinh.Checked = false;
            txtSoDienThoai.Clear();
            txtDiaChi.Clear();
            txtChucVu.Clear();
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
            cboQuyen.SelectedIndex = 0;

            if (focusHoTen)
            {
                txtHoTen.Focus();
            }
        }

        private void TimDongTheoMa(string maNV)
        {
            foreach (DataGridViewRow row in dgvNhanVien.Rows)
            {
                if (row.Cells[nameof(NhanVienDTO.MaNV)].Value?.ToString() == maNV)
                {
                    row.Selected = true;
                    dgvNhanVien.CurrentCell = row.Cells[nameof(NhanVienDTO.HoTen)];
                    return;
                }
            }
        }

        private void TimDongTheoTen(string hoTen)
        {
            foreach (DataGridViewRow row in dgvNhanVien.Rows)
            {
                if (string.Equals(row.Cells[nameof(NhanVienDTO.HoTen)].Value?.ToString(), hoTen, StringComparison.CurrentCultureIgnoreCase))
                {
                    row.Selected = true;
                    dgvNhanVien.CurrentCell = row.Cells[nameof(NhanVienDTO.HoTen)];
                    return;
                }
            }
        }

        private static void ChonCombo(ComboBox comboBox, string value)
        {
            var index = comboBox.FindStringExact(value);
            comboBox.SelectedIndex = index >= 0 ? index : 0;
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
