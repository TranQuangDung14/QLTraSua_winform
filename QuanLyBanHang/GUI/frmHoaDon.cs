using System.ComponentModel;
using QuanLyBanHang.BUS;
using QuanLyBanHang.DTO;

namespace QuanLyBanHang.GUI
{
    public partial class frmHoaDon : Form
    {
        private readonly HoaDonBUS _hoaDonBus = new();
        private readonly NhanVienBUS _nhanVienBus = new();
        private readonly KhachHangBUS _khachHangBus = new();
        private readonly SanPhamBUS _sanPhamBus = new();
        private readonly BindingList<ChiTietHoaDonDTO> _gioHang = new();
        private bool _dangTaiHoaDon;

        public frmHoaDon()
        {
            InitializeComponent();
            ResponsiveLayout.Configure(this);
        }

        private async void frmHoaDon_Load(object sender, EventArgs e)
        {
            dgvChiTietTao.DataSource = _gioHang;
            DinhDangLuoiChiTiet(dgvChiTietTao);
            DinhDangLuoiChiTiet(dgvChiTietLichSu);
            dtpNgayLap.Value = DateTime.Now;

            await TaiDuLieuBanDauAsync();
        }

        private async Task TaiDuLieuBanDauAsync()
        {
            await TaiDanhMucAsync();
            await TaiHoaDonAsync();
            CapNhatTongTien();
            HienThiThongTinSanPham();
        }

        private async Task TaiDanhMucAsync()
        {
            var danhSachNhanVien = await _nhanVienBus.GetDanhSachAsync();
            cboNhanVien.DataSource = danhSachNhanVien;
            cboNhanVien.DisplayMember = nameof(NhanVienDTO.HoTen);
            cboNhanVien.ValueMember = nameof(NhanVienDTO.MaNV);
            cboNhanVien.SelectedIndex = danhSachNhanVien.Count > 0 ? 0 : -1;

            var danhSachKhachHang = await _khachHangBus.GetDanhSachAsync();
            danhSachKhachHang.Insert(0, new KhachHangDTO
            {
                MaKH = 0,
                HoTen = "Khách lẻ",
                SoDienThoai = string.Empty,
                DiaChi = string.Empty
            });

            cboKhachHang.DataSource = danhSachKhachHang;
            cboKhachHang.DisplayMember = nameof(KhachHangDTO.HoTen);
            cboKhachHang.ValueMember = nameof(KhachHangDTO.MaKH);
            cboKhachHang.SelectedIndex = 0;

            var danhSachSanPham = await _sanPhamBus.GetDanhSachAsync();
            cboSanPham.DataSource = danhSachSanPham;
            cboSanPham.DisplayMember = nameof(SanPhamDTO.TenSP);
            cboSanPham.ValueMember = nameof(SanPhamDTO.MaSP);
            cboSanPham.SelectedIndex = danhSachSanPham.Count > 0 ? 0 : -1;

            btnThemSanPham.Enabled = danhSachSanPham.Count > 0;
            btnLuuHoaDon.Enabled = danhSachNhanVien.Count > 0;
        }

        private async Task TaiHoaDonAsync(string tuKhoa = "")
        {
            _dangTaiHoaDon = true;

            try
            {
                var danhSach = await _hoaDonBus.GetDanhSachAsync(tuKhoa);
                dgvHoaDon.DataSource = danhSach;
                DinhDangLuoiHoaDon();

                if (danhSach.Count > 0)
                {
                    dgvHoaDon.Rows[0].Selected = true;
                    dgvHoaDon.CurrentCell = dgvHoaDon.Rows[0].Cells[nameof(HoaDonDTO.MaHD)];
                    await TaiChiTietHoaDonDangChonAsync();
                }
                else
                {
                    dgvChiTietLichSu.DataSource = null;
                    lblThongTinHoaDon.Text = "Chưa có hóa đơn.";
                }
            }
            finally
            {
                _dangTaiHoaDon = false;
            }
        }

        private void DinhDangLuoiHoaDon()
        {
            if (dgvHoaDon.Columns.Count == 0)
            {
                return;
            }

            dgvHoaDon.Columns[nameof(HoaDonDTO.MaHD)].HeaderText = "Mã HD";
            dgvHoaDon.Columns[nameof(HoaDonDTO.MaHD)].Width = 80;
            dgvHoaDon.Columns[nameof(HoaDonDTO.MaNV)].Visible = false;
            dgvHoaDon.Columns[nameof(HoaDonDTO.MaKH)].Visible = false;
            dgvHoaDon.Columns[nameof(HoaDonDTO.NgayLap)].HeaderText = "Ngày lập";
            dgvHoaDon.Columns[nameof(HoaDonDTO.NgayLap)].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            dgvHoaDon.Columns[nameof(HoaDonDTO.NgayLap)].Width = 140;
            dgvHoaDon.Columns[nameof(HoaDonDTO.HoTenNhanVien)].HeaderText = "Nhân viên";
            dgvHoaDon.Columns[nameof(HoaDonDTO.HoTenNhanVien)].Width = 140;
            dgvHoaDon.Columns[nameof(HoaDonDTO.HoTenKhachHang)].HeaderText = "Khách hàng";
            dgvHoaDon.Columns[nameof(HoaDonDTO.HoTenKhachHang)].Width = 150;
            dgvHoaDon.Columns[nameof(HoaDonDTO.TongTien)].HeaderText = "Tổng tiền";
            dgvHoaDon.Columns[nameof(HoaDonDTO.TongTien)].DefaultCellStyle.Format = "N0";
            dgvHoaDon.Columns[nameof(HoaDonDTO.TongTien)].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private static void DinhDangLuoiChiTiet(DataGridView dgv)
        {
            if (dgv.Columns.Count == 0)
            {
                return;
            }

            if (dgv.Columns.Contains(nameof(ChiTietHoaDonDTO.MaCTHD)))
            {
                dgv.Columns[nameof(ChiTietHoaDonDTO.MaCTHD)].Visible = false;
            }

            if (dgv.Columns.Contains(nameof(ChiTietHoaDonDTO.MaHD)))
            {
                dgv.Columns[nameof(ChiTietHoaDonDTO.MaHD)].Visible = false;
            }

            if (dgv.Columns.Contains(nameof(ChiTietHoaDonDTO.NgayLap)))
            {
                dgv.Columns[nameof(ChiTietHoaDonDTO.NgayLap)].Visible = false;
            }

            if (dgv.Columns.Contains(nameof(ChiTietHoaDonDTO.HoTenNhanVien)))
            {
                dgv.Columns[nameof(ChiTietHoaDonDTO.HoTenNhanVien)].Visible = false;
            }

            if (dgv.Columns.Contains(nameof(ChiTietHoaDonDTO.HoTenKhachHang)))
            {
                dgv.Columns[nameof(ChiTietHoaDonDTO.HoTenKhachHang)].Visible = false;
            }

            dgv.Columns[nameof(ChiTietHoaDonDTO.MaSP)].HeaderText = "Mã SP";
            dgv.Columns[nameof(ChiTietHoaDonDTO.MaSP)].Width = 80;
            dgv.Columns[nameof(ChiTietHoaDonDTO.TenSP)].HeaderText = "Sản phẩm";
            dgv.Columns[nameof(ChiTietHoaDonDTO.TenSP)].Width = 180;
            dgv.Columns[nameof(ChiTietHoaDonDTO.SoLuong)].HeaderText = "Số lượng";
            dgv.Columns[nameof(ChiTietHoaDonDTO.SoLuong)].Width = 90;
            dgv.Columns[nameof(ChiTietHoaDonDTO.DonGia)].HeaderText = "Đơn giá";
            dgv.Columns[nameof(ChiTietHoaDonDTO.DonGia)].DefaultCellStyle.Format = "N0";
            dgv.Columns[nameof(ChiTietHoaDonDTO.DonGia)].Width = 110;
            dgv.Columns[nameof(ChiTietHoaDonDTO.ThanhTien)].HeaderText = "Thành tiền";
            dgv.Columns[nameof(ChiTietHoaDonDTO.ThanhTien)].DefaultCellStyle.Format = "N0";
            dgv.Columns[nameof(ChiTietHoaDonDTO.ThanhTien)].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private async Task TaiChiTietHoaDonDangChonAsync()
        {
            if (dgvHoaDon.CurrentRow?.DataBoundItem is not HoaDonDTO hoaDon)
            {
                dgvChiTietLichSu.DataSource = null;
                lblThongTinHoaDon.Text = "Chưa chọn hóa đơn.";
                return;
            }

            var chiTiets = await _hoaDonBus.GetChiTietAsync(hoaDon.MaHD);
            dgvChiTietLichSu.DataSource = chiTiets;
            DinhDangLuoiChiTiet(dgvChiTietLichSu);
            lblThongTinHoaDon.Text =
                $"Hóa đơn #{hoaDon.MaHD} | {hoaDon.HoTenKhachHang} | {hoaDon.TongTien:N0} VNĐ";
        }

        private void cboSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            HienThiThongTinSanPham();
        }

        private void HienThiThongTinSanPham()
        {
            if (cboSanPham.SelectedItem is not SanPhamDTO sanPham)
            {
                lblDonGia.Text = "0 VNĐ";
                lblTonKho.Text = "0";
                return;
            }

            lblDonGia.Text = $"{sanPham.DonGia:N0} VNĐ";
            lblTonKho.Text = sanPham.SoLuong.ToString();
        }

        private void btnThemSanPham_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboSanPham.SelectedItem is not SanPhamDTO sanPham)
                {
                    throw new ArgumentException("Vui lòng chọn sản phẩm.");
                }

                var soLuongThem = (int)nudSoLuongBan.Value;
                if (soLuongThem <= 0)
                {
                    throw new ArgumentException("Số lượng bán phải lớn hơn 0.");
                }

                var chiTietDaCo = _gioHang.FirstOrDefault(x => x.MaSP == sanPham.MaSP);
                var soLuongHienTai = chiTietDaCo?.SoLuong ?? 0;
                if (soLuongHienTai + soLuongThem > sanPham.SoLuong)
                {
                    throw new ArgumentException("Số lượng bán vượt quá tồn kho hiện tại.");
                }

                if (chiTietDaCo is null)
                {
                    _gioHang.Add(new ChiTietHoaDonDTO
                    {
                        MaSP = sanPham.MaSP,
                        TenSP = sanPham.TenSP,
                        SoLuong = soLuongThem,
                        DonGia = sanPham.DonGia,
                        ThanhTien = sanPham.DonGia * soLuongThem
                    });
                }
                else
                {
                    chiTietDaCo.SoLuong += soLuongThem;
                    chiTietDaCo.ThanhTien = chiTietDaCo.DonGia * chiTietDaCo.SoLuong;
                    dgvChiTietTao.Refresh();
                }

                CapNhatTongTien();
                nudSoLuongBan.Value = 1;
                ThongBao("Đã thêm sản phẩm vào hóa đơn.");
            }
            catch (ArgumentException ex)
            {
                BaoLoi(ex.Message);
            }
        }

        private void btnBoSanPham_Click(object sender, EventArgs e)
        {
            if (dgvChiTietTao.CurrentRow?.DataBoundItem is not ChiTietHoaDonDTO chiTiet)
            {
                BaoLoi("Vui lòng chọn sản phẩm cần bỏ.");
                return;
            }

            _gioHang.Remove(chiTiet);
            CapNhatTongTien();
            ThongBao("Đã bỏ sản phẩm khỏi hóa đơn.");
        }

        private void btnXoaGioHang_Click(object sender, EventArgs e)
        {
            _gioHang.Clear();
            CapNhatTongTien();
            dtpNgayLap.Value = DateTime.Now;
            ThongBao("Đã làm mới hóa đơn đang tạo.");
        }

        private async void btnLuuHoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                var maHoaDon = await _hoaDonBus.ThemHoaDonAsync(
                    GetMaNhanVien(),
                    GetMaKhachHang(),
                    dtpNgayLap.Value,
                    _gioHang.ToList());

                _gioHang.Clear();
                CapNhatTongTien();
                dtpNgayLap.Value = DateTime.Now;

                await TaiDanhMucAsync();
                await TaiHoaDonAsync(txtTimKiem.Text);
                TimHoaDonTheoMa(maHoaDon);
                ThongBao($"Đã lưu hóa đơn #{maHoaDon} thành công.");
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
                BaoLoi($"Không thể lưu hóa đơn: {ex.Message}");
            }
        }

        private async void btnTimKiem_Click(object sender, EventArgs e)
        {
            await TaiHoaDonAsync(txtTimKiem.Text);
            if (dgvHoaDon.Rows.Count == 0)
            {
                BaoLoi("Không tìm thấy hóa đơn phù hợp.");
                return;
            }

            ThongBao("Đã cập nhật danh sách hóa đơn.");
        }

        private async void btnXoaHoaDon_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.CurrentRow?.DataBoundItem is not HoaDonDTO hoaDon)
            {
                BaoLoi("Vui lòng chọn hóa đơn cần xóa.");
                return;
            }

            var xacNhan = MessageBox.Show(
                $"Bạn có chắc muốn xóa hóa đơn #{hoaDon.MaHD} không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (xacNhan != DialogResult.Yes)
            {
                return;
            }

            try
            {
                await _hoaDonBus.XoaHoaDonAsync(hoaDon.MaHD);
                await TaiDanhMucAsync();
                await TaiHoaDonAsync(txtTimKiem.Text);
                ThongBao("Đã xóa hóa đơn thành công.");
            }
            catch (ArgumentException ex)
            {
                BaoLoi(ex.Message);
            }
            catch (Exception ex)
            {
                BaoLoi($"Không thể xóa hóa đơn: {ex.Message}");
            }
        }

        private async void dgvHoaDon_SelectionChanged(object sender, EventArgs e)
        {
            if (_dangTaiHoaDon)
            {
                return;
            }

            try
            {
                await TaiChiTietHoaDonDangChonAsync();
            }
            catch (Exception ex)
            {
                BaoLoi($"Không thể tải chi tiết hóa đơn: {ex.Message}");
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }

        private int GetMaNhanVien()
        {
            return cboNhanVien.SelectedValue is int maNV ? maNV : 0;
        }

        private int GetMaKhachHang()
        {
            return cboKhachHang.SelectedValue is int maKH ? maKH : 0;
        }

        private void CapNhatTongTien()
        {
            var tongTien = _gioHang.Sum(x => x.ThanhTien);
            lblTongTien.Text = $"{tongTien:N0} VNĐ";
        }

        private void TimHoaDonTheoMa(int maHD)
        {
            foreach (DataGridViewRow row in dgvHoaDon.Rows)
            {
                if (row.DataBoundItem is HoaDonDTO hoaDon && hoaDon.MaHD == maHD)
                {
                    row.Selected = true;
                    dgvHoaDon.CurrentCell = row.Cells[nameof(HoaDonDTO.MaHD)];
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
