using Microsoft.Data.SqlClient;
using QuanLyBanHang.BUS;
using QuanLyBanHang.DTO;

namespace QuanLyBanHang.GUI
{
    public partial class frmLoaiSanPham : Form
    {
        private readonly LoaiSanPhamBUS _loaiSanPhamBus = new();
        private bool _dangTaiDuLieu;

        public frmLoaiSanPham()
        {
            InitializeComponent();
        }

        private async void frmLoaiSanPham_Load(object sender, EventArgs e)
        {
            await TaiDanhSachAsync();
        }

        private async Task TaiDanhSachAsync(string tuKhoa = "")
        {
            _dangTaiDuLieu = true;

            try
            {
                var danhSach = await _loaiSanPhamBus.GetDanhSachAsync(tuKhoa);
                dgvLoaiSanPham.DataSource = danhSach;
                DinhDangLuoi();

                if (danhSach.Count > 0)
                {
                    dgvLoaiSanPham.Rows[0].Selected = true;
                    dgvLoaiSanPham.CurrentCell = dgvLoaiSanPham.Rows[0].Cells["TenLoai"];
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
            if (dgvLoaiSanPham.Columns.Count == 0)
            {
                return;
            }

            dgvLoaiSanPham.Columns[nameof(LoaiSanPhamDTO.MaLoai)].HeaderText = "Mã loại";
            dgvLoaiSanPham.Columns[nameof(LoaiSanPhamDTO.MaLoai)].Width = 120;
            dgvLoaiSanPham.Columns[nameof(LoaiSanPhamDTO.TenLoai)].HeaderText = "Tên loại sản phẩm";
            dgvLoaiSanPham.Columns[nameof(LoaiSanPhamDTO.TenLoai)].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void GanDuLieuTuDong()
        {
            if (dgvLoaiSanPham.CurrentRow?.DataBoundItem is not LoaiSanPhamDTO loaiSanPham)
            {
                return;
            }

            txtMaLoai.Text = loaiSanPham.MaLoai.ToString();
            txtTenLoai.Text = loaiSanPham.TenLoai;
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                var tenLoai = txtTenLoai.Text.Trim();
                await _loaiSanPhamBus.ThemAsync(tenLoai);
                await TaiDanhSachAsync(txtTimKiem.Text);
                TimDongTheoTen(tenLoai);
                ThongBao("Thêm loại sản phẩm thành công.");
            }
            catch (ArgumentException ex)
            {
                BaoLoi(ex.Message);
            }
            catch (Exception ex)
            {
                BaoLoi($"Không thể thêm loại sản phẩm: {ex.Message}");
            }
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                await _loaiSanPhamBus.CapNhatAsync(
                    int.TryParse(txtMaLoai.Text, out var maLoai) ? maLoai : 0,
                    txtTenLoai.Text);

                await TaiDanhSachAsync(txtTimKiem.Text);
                TimDongTheoMa(txtMaLoai.Text);
                ThongBao("Cập nhật loại sản phẩm thành công.");
            }
            catch (ArgumentException ex)
            {
                BaoLoi(ex.Message);
            }
            catch (Exception ex)
            {
                BaoLoi($"Không thể cập nhật loại sản phẩm: {ex.Message}");
            }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                    $"Bạn có chắc muốn xóa loại sản phẩm \"{txtTenLoai.Text}\" không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                await _loaiSanPhamBus.XoaAsync(int.TryParse(txtMaLoai.Text, out var maLoai) ? maLoai : 0);
                await TaiDanhSachAsync(txtTimKiem.Text);
                ThongBao("Xóa loại sản phẩm thành công.");
            }
            catch (ArgumentException ex)
            {
                BaoLoi(ex.Message);
            }
            catch (SqlException)
            {
                BaoLoi("Không thể xóa vì loại sản phẩm đang được sử dụng trong bảng Sản phẩm.");
            }
            catch (Exception ex)
            {
                BaoLoi($"Không thể xóa loại sản phẩm: {ex.Message}");
            }
        }

        private async void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            XoaNhapLieu();
            await TaiDanhSachAsync();
            txtTenLoai.Focus();
            ThongBao("Đã làm mới dữ liệu.");
        }

        private async void btnTimKiem_Click(object sender, EventArgs e)
        {
            await TaiDanhSachAsync(txtTimKiem.Text);
            if (dgvLoaiSanPham.Rows.Count == 0)
            {
                BaoLoi("Không tìm thấy loại sản phẩm phù hợp.");
                return;
            }

            ThongBao("Đã cập nhật danh sách tìm kiếm.");
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvLoaiSanPham_SelectionChanged(object sender, EventArgs e)
        {
            if (_dangTaiDuLieu)
            {
                return;
            }

            GanDuLieuTuDong();
        }

        private void XoaNhapLieu(bool focusTenLoai = true)
        {
            txtMaLoai.Clear();
            txtTenLoai.Clear();
            if (focusTenLoai)
            {
                txtTenLoai.Focus();
            }
        }

        private void TimDongTheoMa(string maLoai)
        {
            foreach (DataGridViewRow row in dgvLoaiSanPham.Rows)
            {
                if (row.Cells[nameof(LoaiSanPhamDTO.MaLoai)].Value?.ToString() == maLoai)
                {
                    row.Selected = true;
                    dgvLoaiSanPham.CurrentCell = row.Cells[nameof(LoaiSanPhamDTO.TenLoai)];
                    return;
                }
            }
        }

        private void TimDongTheoTen(string tenLoai)
        {
            foreach (DataGridViewRow row in dgvLoaiSanPham.Rows)
            {
                if (string.Equals(
                        row.Cells[nameof(LoaiSanPhamDTO.TenLoai)].Value?.ToString(),
                        tenLoai,
                        StringComparison.CurrentCultureIgnoreCase))
                {
                    row.Selected = true;
                    dgvLoaiSanPham.CurrentCell = row.Cells[nameof(LoaiSanPhamDTO.TenLoai)];
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
