using Microsoft.Data.SqlClient;
using QuanLyBanHang.BUS;
using QuanLyBanHang.DTO;

namespace QuanLyBanHang.GUI
{
    public partial class frmSanPham : Form
    {
        private readonly SanPhamBUS _sanPhamBus = new();
        private readonly LoaiSanPhamBUS _loaiSanPhamBus = new();
        private readonly NhaCungCapBUS _nhaCungCapBus = new();
        private bool _dangTaiDuLieu;
        private bool _laAdmin = true;

        public frmSanPham()
        {
            InitializeComponent();
            ResponsiveLayout.Configure(this);
        }

        public frmSanPham(string quyen)
            : this()
        {
            _laAdmin = string.Equals(quyen?.Trim(), "Admin", StringComparison.OrdinalIgnoreCase);
            ApDungPhanQuyen();
        }

        private void ApDungPhanQuyen()
        {
            if (_laAdmin)
            {
                return;
            }

            txtTenSP.ReadOnly = true;
            txtMoTa.ReadOnly = true;
            cboLoaiSanPham.Enabled = false;
            cboNhaCungCap.Enabled = false;
            nudDonGia.Enabled = false;
            nudSoLuong.Enabled = false;
            btnThem.Visible = false;
            btnSua.Visible = false;
            btnXoa.Visible = false;
            lblThongBao.Text = "Nhân viên chỉ được xem và tìm kiếm danh sách sản phẩm.";
        }

        private async void frmSanPham_Load(object sender, EventArgs e)
        {
            await TaiDuLieuDanhMucAsync();
            await TaiDanhSachAsync();
        }

        private async Task TaiDuLieuDanhMucAsync()
        {
            var dsLoai = await _loaiSanPhamBus.GetDanhSachAsync();
            cboLoaiSanPham.DataSource = dsLoai;
            cboLoaiSanPham.DisplayMember = nameof(LoaiSanPhamDTO.TenLoai);
            cboLoaiSanPham.ValueMember = nameof(LoaiSanPhamDTO.MaLoai);
            cboLoaiSanPham.SelectedIndex = dsLoai.Count > 0 ? 0 : -1;

            var dsNCC = await _nhaCungCapBus.GetDanhSachAsync();
            cboNhaCungCap.DataSource = dsNCC;
            cboNhaCungCap.DisplayMember = nameof(NhaCungCapDTO.TenNCC);
            cboNhaCungCap.ValueMember = nameof(NhaCungCapDTO.MaNCC);
            cboNhaCungCap.SelectedIndex = dsNCC.Count > 0 ? 0 : -1;
        }

        private async Task TaiDanhSachAsync(string tuKhoa = "")
        {
            _dangTaiDuLieu = true;

            try
            {
                var danhSach = await _sanPhamBus.GetDanhSachAsync(tuKhoa);
                dgvSanPham.DataSource = danhSach;
                DinhDangLuoi();

                if (danhSach.Count > 0)
                {
                    dgvSanPham.Rows[0].Selected = true;
                    dgvSanPham.CurrentCell = dgvSanPham.Rows[0].Cells[nameof(SanPhamDTO.TenSP)];
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
            if (dgvSanPham.Columns.Count == 0)
            {
                return;
            }

            dgvSanPham.Columns[nameof(SanPhamDTO.MaSP)].HeaderText = "Mã SP";
            dgvSanPham.Columns[nameof(SanPhamDTO.MaSP)].Width = 80;
            dgvSanPham.Columns[nameof(SanPhamDTO.TenSP)].HeaderText = "Tên sản phẩm";
            dgvSanPham.Columns[nameof(SanPhamDTO.TenSP)].Width = 180;
            dgvSanPham.Columns[nameof(SanPhamDTO.MaLoai)].Visible = false;
            dgvSanPham.Columns[nameof(SanPhamDTO.MaNCC)].Visible = false;
            dgvSanPham.Columns[nameof(SanPhamDTO.TenLoai)].HeaderText = "Loại sản phẩm";
            dgvSanPham.Columns[nameof(SanPhamDTO.TenLoai)].Width = 140;
            dgvSanPham.Columns[nameof(SanPhamDTO.TenNCC)].HeaderText = "Nhà cung cấp";
            dgvSanPham.Columns[nameof(SanPhamDTO.TenNCC)].Width = 150;
            dgvSanPham.Columns[nameof(SanPhamDTO.DonGia)].HeaderText = "Đơn giá";
            dgvSanPham.Columns[nameof(SanPhamDTO.DonGia)].DefaultCellStyle.Format = "N0";
            dgvSanPham.Columns[nameof(SanPhamDTO.DonGia)].Width = 110;
            dgvSanPham.Columns[nameof(SanPhamDTO.SoLuong)].HeaderText = "Số lượng";
            dgvSanPham.Columns[nameof(SanPhamDTO.SoLuong)].Width = 90;
            dgvSanPham.Columns[nameof(SanPhamDTO.MoTa)].HeaderText = "Mô tả";
            dgvSanPham.Columns[nameof(SanPhamDTO.MoTa)].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void GanDuLieuTuDong()
        {
            if (dgvSanPham.CurrentRow?.DataBoundItem is not SanPhamDTO sanPham)
            {
                return;
            }

            txtMaSP.Text = sanPham.MaSP.ToString();
            txtTenSP.Text = sanPham.TenSP;
            cboLoaiSanPham.SelectedValue = sanPham.MaLoai;
            cboNhaCungCap.SelectedValue = sanPham.MaNCC;
            nudDonGia.Value = sanPham.DonGia < nudDonGia.Minimum ? nudDonGia.Minimum : sanPham.DonGia;
            nudSoLuong.Value = sanPham.SoLuong < nudSoLuong.Minimum ? nudSoLuong.Minimum : sanPham.SoLuong;
            txtMoTa.Text = sanPham.MoTa;
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                var tenSP = txtTenSP.Text.Trim();
                await _sanPhamBus.ThemAsync(
                    tenSP,
                    GetMaLoai(),
                    GetMaNCC(),
                    nudDonGia.Value,
                    (int)nudSoLuong.Value,
                    txtMoTa.Text);

                await TaiDanhSachAsync(txtTimKiem.Text);
                TimDongTheoTen(tenSP);
                ThongBao("Thêm sản phẩm thành công.");
            }
            catch (ArgumentException ex)
            {
                BaoLoi(ex.Message);
            }
            catch (Exception ex)
            {
                BaoLoi($"Không thể thêm sản phẩm: {ex.Message}");
            }
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtMaSP.Text, out var maSP) || maSP <= 0)
            {
                BaoLoi("Vui lòng chọn sản phẩm cần sửa.");
                return;
            }

            try
            {
                await _sanPhamBus.CapNhatAsync(
                    maSP,
                    txtTenSP.Text,
                    GetMaLoai(),
                    GetMaNCC(),
                    nudDonGia.Value,
                    (int)nudSoLuong.Value,
                    txtMoTa.Text);

                await TaiDanhSachAsync(txtTimKiem.Text);
                TimDongTheoMa(maSP.ToString());
                ThongBao("Cập nhật sản phẩm thành công.");
            }
            catch (ArgumentException ex)
            {
                BaoLoi(ex.Message);
            }
            catch (Exception ex)
            {
                BaoLoi($"Không thể cập nhật sản phẩm: {ex.Message}");
            }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                    $"Bạn có chắc muốn xóa sản phẩm \"{txtTenSP.Text}\" không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                await _sanPhamBus.XoaAsync(int.TryParse(txtMaSP.Text, out var maSP) ? maSP : 0);
                await TaiDanhSachAsync(txtTimKiem.Text);
                ThongBao("Xóa sản phẩm thành công.");
            }
            catch (ArgumentException ex)
            {
                BaoLoi(ex.Message);
            }
            catch (SqlException)
            {
                BaoLoi("Không thể xóa vì sản phẩm đang được sử dụng trong chi tiết hóa đơn.");
            }
            catch (Exception ex)
            {
                BaoLoi($"Không thể xóa sản phẩm: {ex.Message}");
            }
        }

        private async void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            XoaNhapLieu();
            await TaiDuLieuDanhMucAsync();
            await TaiDanhSachAsync();
            txtTenSP.Focus();
            ThongBao("Đã làm mới dữ liệu.");
        }

        private async void btnTimKiem_Click(object sender, EventArgs e)
        {
            await TaiDanhSachAsync(txtTimKiem.Text);
            if (dgvSanPham.Rows.Count == 0)
            {
                BaoLoi("Không tìm thấy sản phẩm phù hợp.");
                return;
            }

            ThongBao("Đã cập nhật danh sách tìm kiếm.");
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvSanPham_SelectionChanged(object sender, EventArgs e)
        {
            if (_dangTaiDuLieu)
            {
                return;
            }

            GanDuLieuTuDong();
        }

        private int GetMaLoai()
        {
            return cboLoaiSanPham.SelectedValue is int maLoai ? maLoai : 0;
        }

        private int GetMaNCC()
        {
            return cboNhaCungCap.SelectedValue is int maNCC ? maNCC : 0;
        }

        private void XoaNhapLieu(bool focusTenSP = true)
        {
            txtMaSP.Clear();
            txtTenSP.Clear();
            nudDonGia.Value = 0;
            nudSoLuong.Value = 0;
            txtMoTa.Clear();

            if (cboLoaiSanPham.Items.Count > 0)
            {
                cboLoaiSanPham.SelectedIndex = 0;
            }

            if (cboNhaCungCap.Items.Count > 0)
            {
                cboNhaCungCap.SelectedIndex = 0;
            }

            if (focusTenSP)
            {
                txtTenSP.Focus();
            }
        }

        private void TimDongTheoMa(string maSP)
        {
            foreach (DataGridViewRow row in dgvSanPham.Rows)
            {
                if (row.Cells[nameof(SanPhamDTO.MaSP)].Value?.ToString() == maSP)
                {
                    row.Selected = true;
                    dgvSanPham.CurrentCell = row.Cells[nameof(SanPhamDTO.TenSP)];
                    return;
                }
            }
        }

        private void TimDongTheoTen(string tenSP)
        {
            foreach (DataGridViewRow row in dgvSanPham.Rows)
            {
                if (string.Equals(
                        row.Cells[nameof(SanPhamDTO.TenSP)].Value?.ToString(),
                        tenSP,
                        StringComparison.CurrentCultureIgnoreCase))
                {
                    row.Selected = true;
                    dgvSanPham.CurrentCell = row.Cells[nameof(SanPhamDTO.TenSP)];
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
