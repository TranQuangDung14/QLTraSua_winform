using Microsoft.Data.SqlClient;
using QuanLyBanHang.BUS;
using QuanLyBanHang.DTO;

namespace QuanLyBanHang.GUI
{
    public partial class frmNhaCungCap : Form
    {
        private readonly NhaCungCapBUS _nhaCungCapBus = new();
        private bool _dangTaiDuLieu;

        public frmNhaCungCap()
        {
            InitializeComponent();
        }

        private async void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            await TaiDanhSachAsync();
        }

        private async Task TaiDanhSachAsync(string tuKhoa = "")
        {
            _dangTaiDuLieu = true;

            try
            {
                var danhSach = await _nhaCungCapBus.GetDanhSachAsync(tuKhoa);
                dgvNhaCungCap.DataSource = danhSach;
                DinhDangLuoi();

                if (danhSach.Count > 0)
                {
                    dgvNhaCungCap.Rows[0].Selected = true;
                    dgvNhaCungCap.CurrentCell = dgvNhaCungCap.Rows[0].Cells["TenNCC"];
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
            if (dgvNhaCungCap.Columns.Count == 0)
            {
                return;
            }

            dgvNhaCungCap.Columns[nameof(NhaCungCapDTO.MaNCC)].HeaderText = "Mã NCC";
            dgvNhaCungCap.Columns[nameof(NhaCungCapDTO.MaNCC)].Width = 90;
            dgvNhaCungCap.Columns[nameof(NhaCungCapDTO.TenNCC)].HeaderText = "Tên nhà cung cấp";
            dgvNhaCungCap.Columns[nameof(NhaCungCapDTO.TenNCC)].Width = 180;
            dgvNhaCungCap.Columns[nameof(NhaCungCapDTO.DiaChi)].HeaderText = "Địa chỉ";
            dgvNhaCungCap.Columns[nameof(NhaCungCapDTO.DiaChi)].Width = 220;
            dgvNhaCungCap.Columns[nameof(NhaCungCapDTO.SoDienThoai)].HeaderText = "Số điện thoại";
            dgvNhaCungCap.Columns[nameof(NhaCungCapDTO.SoDienThoai)].Width = 130;
            dgvNhaCungCap.Columns[nameof(NhaCungCapDTO.Email)].HeaderText = "Email";
            dgvNhaCungCap.Columns[nameof(NhaCungCapDTO.Email)].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void GanDuLieuTuDong()
        {
            if (dgvNhaCungCap.CurrentRow?.DataBoundItem is not NhaCungCapDTO nhaCungCap)
            {
                return;
            }

            txtMaNCC.Text = nhaCungCap.MaNCC.ToString();
            txtTenNCC.Text = nhaCungCap.TenNCC;
            txtDiaChi.Text = nhaCungCap.DiaChi;
            txtSoDienThoai.Text = nhaCungCap.SoDienThoai;
            txtEmail.Text = nhaCungCap.Email;
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                await _nhaCungCapBus.ThemAsync(
                    txtTenNCC.Text,
                    txtDiaChi.Text,
                    txtSoDienThoai.Text,
                    txtEmail.Text);

                await TaiDanhSachAsync(txtTimKiem.Text);
                ThongBao("Thêm nhà cung cấp thành công.");
            }
            catch (ArgumentException ex)
            {
                BaoLoi(ex.Message);
            }
            catch (Exception ex)
            {
                BaoLoi($"Không thể thêm nhà cung cấp: {ex.Message}");
            }
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                await _nhaCungCapBus.CapNhatAsync(
                    int.TryParse(txtMaNCC.Text, out var maNCC) ? maNCC : 0,
                    txtTenNCC.Text,
                    txtDiaChi.Text,
                    txtSoDienThoai.Text,
                    txtEmail.Text);

                await TaiDanhSachAsync(txtTimKiem.Text);
                TimDongTheoMa(txtMaNCC.Text);
                ThongBao("Cập nhật nhà cung cấp thành công.");
            }
            catch (ArgumentException ex)
            {
                BaoLoi(ex.Message);
            }
            catch (Exception ex)
            {
                BaoLoi($"Không thể cập nhật nhà cung cấp: {ex.Message}");
            }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                    $"Bạn có chắc muốn xóa nhà cung cấp \"{txtTenNCC.Text}\" không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                await _nhaCungCapBus.XoaAsync(int.TryParse(txtMaNCC.Text, out var maNCC) ? maNCC : 0);
                await TaiDanhSachAsync(txtTimKiem.Text);
                ThongBao("Xóa nhà cung cấp thành công.");
            }
            catch (ArgumentException ex)
            {
                BaoLoi(ex.Message);
            }
            catch (SqlException)
            {
                BaoLoi("Không thể xóa vì nhà cung cấp đang được sử dụng trong bảng Sản phẩm.");
            }
            catch (Exception ex)
            {
                BaoLoi($"Không thể xóa nhà cung cấp: {ex.Message}");
            }
        }

        private async void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            XoaNhapLieu();
            await TaiDanhSachAsync();
            txtTenNCC.Focus();
            ThongBao("Đã làm mới dữ liệu.");
        }

        private async void btnTimKiem_Click(object sender, EventArgs e)
        {
            await TaiDanhSachAsync(txtTimKiem.Text);
            if (dgvNhaCungCap.Rows.Count == 0)
            {
                BaoLoi("Không tìm thấy nhà cung cấp phù hợp.");
                return;
            }

            ThongBao("Đã cập nhật danh sách tìm kiếm.");
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvNhaCungCap_SelectionChanged(object sender, EventArgs e)
        {
            if (_dangTaiDuLieu)
            {
                return;
            }

            GanDuLieuTuDong();
        }

        private void XoaNhapLieu(bool focusTenNCC = true)
        {
            txtMaNCC.Clear();
            txtTenNCC.Clear();
            txtDiaChi.Clear();
            txtSoDienThoai.Clear();
            txtEmail.Clear();
            if (focusTenNCC)
            {
                txtTenNCC.Focus();
            }
        }

        private void TimDongTheoMa(string maNCC)
        {
            foreach (DataGridViewRow row in dgvNhaCungCap.Rows)
            {
                if (row.Cells[nameof(NhaCungCapDTO.MaNCC)].Value?.ToString() == maNCC)
                {
                    row.Selected = true;
                    dgvNhaCungCap.CurrentCell = row.Cells[nameof(NhaCungCapDTO.TenNCC)];
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
