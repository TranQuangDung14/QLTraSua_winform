using QuanLyBanHang.BUS;
using QuanLyBanHang.DTO;
using System.Drawing.Printing;

namespace QuanLyBanHang.GUI
{
    public partial class frmChiTietHoaDon : Form
    {
        private readonly ChiTietHoaDonBUS _chiTietHoaDonBus = new();
        private readonly HoaDonBUS _hoaDonBus = new();
        private List<ChiTietHoaDonDTO> _chiTietDangIn = [];
        private HoaDonDTO? _hoaDonDangChon;
        private int _dongInHienTai;
        private bool _dangTaiDuLieu;
        private bool _dangXemChiTiet;

        public frmChiTietHoaDon()
        {
            InitializeComponent();
            ResponsiveLayout.Configure(this);
        }

        private async void frmChiTietHoaDon_Load(object sender, EventArgs e)
        {
            CauHinhThongTinHoaDon();
            await TaiDanhSachHoaDonAsync();
        }

        private async Task TaiDanhSachHoaDonAsync(string tuKhoa = "")
        {
            _dangTaiDuLieu = true;
            _dangXemChiTiet = false;
            _hoaDonDangChon = null;
            _chiTietDangIn = [];

            try
            {
                grpDanhSach.Text = "Danh sách hóa đơn";
                btnXemChiTiet.Enabled = true;
                btnXemChiTiet.Visible = true;
                btnQuayLai.Visible = false;
                btnInHoaDon.Enabled = false;
                btnXoa.Enabled = false;

                var danhSach = await _hoaDonBus.GetDanhSachAsync(tuKhoa);
                dgvChiTietHoaDon.DataSource = danhSach;
                DinhDangLuoiHoaDon();

                if (danhSach.Count > 0)
                {
                    dgvChiTietHoaDon.Rows[0].Selected = true;
                    dgvChiTietHoaDon.CurrentCell = dgvChiTietHoaDon.Rows[0].Cells[nameof(HoaDonDTO.MaHD)];
                    GanDuLieuLenForm();
                    ThongBao("Chọn hóa đơn rồi bấm Xem chi tiết để xem sản phẩm và in.");
                }
                else
                {
                    XoaNhapLieu();
                    lblThongBao.Text = "Chưa có hóa đơn.";
                }
            }
            finally
            {
                _dangTaiDuLieu = false;
            }
        }

        private async Task TaiChiTietHoaDonAsync(HoaDonDTO hoaDon)
        {
            _dangTaiDuLieu = true;
            _dangXemChiTiet = true;
            _hoaDonDangChon = hoaDon;

            try
            {
                grpDanhSach.Text = $"Chi tiết hóa đơn #{hoaDon.MaHD}";
                btnXemChiTiet.Enabled = false;
                btnXemChiTiet.Visible = false;
                btnQuayLai.Visible = true;
                btnInHoaDon.Enabled = true;
                btnXoa.Enabled = true;

                _chiTietDangIn = await _chiTietHoaDonBus.GetTheoHoaDonAsync(hoaDon.MaHD);
                dgvChiTietHoaDon.DataSource = _chiTietDangIn;
                DinhDangLuoiChiTiet();
                GanThongTinHoaDonLenForm(hoaDon, _chiTietDangIn);

                if (_chiTietDangIn.Count > 0)
                {
                    dgvChiTietHoaDon.Rows[0].Selected = true;
                    dgvChiTietHoaDon.CurrentCell = dgvChiTietHoaDon.Rows[0].Cells[nameof(ChiTietHoaDonDTO.MaSP)];
                }

                ThongBao($"Đang hiển thị chi tiết hóa đơn #{hoaDon.MaHD}.");
            }
            finally
            {
                _dangTaiDuLieu = false;
            }
        }

        private void DinhDangLuoiHoaDon()
        {
            DatLaiCotLuoi();
            ThemCot(nameof(HoaDonDTO.MaHD), "Mã HĐ", 80);
            ThemCot(nameof(HoaDonDTO.NgayLap), "Ngày lập", 150, "dd/MM/yyyy HH:mm");
            ThemCot(nameof(HoaDonDTO.TongTien), "Tổng tiền", 140, "N0");
            ThemCot(nameof(HoaDonDTO.HoTenNhanVien), "Nhân viên", 150);
            ThemCot(nameof(HoaDonDTO.HoTenKhachHang), "Khách hàng", 180, autoFill: true);
        }

        private void DinhDangLuoiChiTiet()
        {
            DatLaiCotLuoi();
            ThemCot(nameof(ChiTietHoaDonDTO.MaSP), "Mã SP", 80);
            ThemCot(nameof(ChiTietHoaDonDTO.TenSP), "Sản phẩm", 240, autoFill: true);
            ThemCot(nameof(ChiTietHoaDonDTO.SoLuong), "Số lượng", 90);
            ThemCot(nameof(ChiTietHoaDonDTO.DonGia), "Đơn giá", 120, "N0");
            ThemCot(nameof(ChiTietHoaDonDTO.ThanhTien), "Thành tiền", 130, "N0");
        }

        private void DatLaiCotLuoi()
        {
            dgvChiTietHoaDon.AutoGenerateColumns = false;
            dgvChiTietHoaDon.Columns.Clear();
        }

        private void ThemCot(string dataPropertyName, string headerText, int width, string? format = null, bool autoFill = false)
        {
            var column = new DataGridViewTextBoxColumn
            {
                DataPropertyName = dataPropertyName,
                HeaderText = headerText,
                Name = dataPropertyName,
                Width = width,
                AutoSizeMode = autoFill ? DataGridViewAutoSizeColumnMode.Fill : DataGridViewAutoSizeColumnMode.None
            };

            if (!string.IsNullOrWhiteSpace(format))
            {
                column.DefaultCellStyle.Format = format;
            }

            dgvChiTietHoaDon.Columns.Add(column);
        }

        private void GanDuLieuLenForm()
        {
            if (_dangXemChiTiet)
            {
                if (_hoaDonDangChon is not null)
                {
                    GanThongTinHoaDonLenForm(_hoaDonDangChon, _chiTietDangIn);
                }

                return;
            }

            if (dgvChiTietHoaDon.CurrentRow?.DataBoundItem is not HoaDonDTO hoaDon)
            {
                return;
            }

            GanThongTinHoaDonLenForm(hoaDon, []);
        }

        private async void btnTimKiem_Click(object sender, EventArgs e)
        {
            await TaiDanhSachHoaDonAsync(txtTimKiem.Text);
            if (dgvChiTietHoaDon.Rows.Count == 0)
            {
                BaoLoi("Không tìm thấy hóa đơn phù hợp.");
                return;
            }

            ThongBao("Chọn hóa đơn rồi bấm Xem chi tiết để xem sản phẩm và in.");
        }

        private async void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            if (dgvChiTietHoaDon.CurrentRow?.DataBoundItem is not HoaDonDTO hoaDon)
            {
                BaoLoi("Vui lòng chọn hóa đơn cần xem chi tiết.");
                return;
            }

            try
            {
                await TaiChiTietHoaDonAsync(hoaDon);
            }
            catch (ArgumentException ex)
            {
                BaoLoi(ex.Message);
            }
            catch (Exception ex)
            {
                BaoLoi($"Không thể tải chi tiết hóa đơn: {ex.Message}");
            }
        }

        private async void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            await TaiDanhSachHoaDonAsync();
        }

        private async void btnQuayLai_Click(object sender, EventArgs e)
        {
            await TaiDanhSachHoaDonAsync(txtTimKiem.Text);
        }

        private async void btnInHoaDon_Click(object sender, EventArgs e)
        {
            if (_hoaDonDangChon is null)
            {
                BaoLoi("Vui lòng bấm Xem chi tiết trước khi in hóa đơn.");
                return;
            }

            try
            {
                _chiTietDangIn = await _chiTietHoaDonBus.GetTheoHoaDonAsync(_hoaDonDangChon.MaHD);
                if (_chiTietDangIn.Count == 0)
                {
                    BaoLoi("Không có dữ liệu để in hóa đơn.");
                    return;
                }

                _dongInHienTai = 0;
                using var printDocument = new PrintDocument
                {
                    DocumentName = $"HoaDon_{_hoaDonDangChon.MaHD}"
                };
                printDocument.PrintPage += InHoaDon_PrintPage;

                using var previewDialog = new PrintPreviewDialog
                {
                    Document = printDocument,
                    StartPosition = FormStartPosition.CenterParent,
                    Width = 900,
                    Height = 700,
                    Text = $"In hóa đơn #{_hoaDonDangChon.MaHD}"
                };

                previewDialog.ShowDialog(this);
                ThongBao($"Đã mở bản xem trước hóa đơn #{_hoaDonDangChon.MaHD}.");
            }
            catch (ArgumentException ex)
            {
                BaoLoi(ex.Message);
            }
            catch (Exception ex)
            {
                BaoLoi($"Không thể in hóa đơn: {ex.Message}");
            }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (!_dangXemChiTiet)
            {
                BaoLoi("Vui lòng bấm Xem chi tiết rồi chọn dòng cần xóa.");
                return;
            }

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
                if (_hoaDonDangChon is not null)
                {
                    await TaiChiTietHoaDonAsync(_hoaDonDangChon);
                }
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

        private void InHoaDon_PrintPage(object sender, PrintPageEventArgs e)
        {
            VeHoaDon(e);
        }

        private void VeHoaDon(PrintPageEventArgs e)
        {
            if (_chiTietDangIn.Count == 0 || e.Graphics is null)
            {
                return;
            }

            var hoaDon = _chiTietDangIn[0];
            var g = e.Graphics;
            var bounds = e.MarginBounds;
            var y = bounds.Top;

            using var fontTieuDe = new Font("Segoe UI", 18, FontStyle.Bold);
            using var fontDam = new Font("Segoe UI", 10, FontStyle.Bold);
            using var fontThuong = new Font("Segoe UI", 10);
            using var fontNho = new Font("Segoe UI", 9);
            using var pen = new Pen(Color.Black);
            using var brush = new SolidBrush(Color.Black);

            DrawCanGiua(g, "HÓA ĐƠN BÁN HÀNG", fontTieuDe, brush, bounds, y);
            y += 42;

            g.DrawString($"Mã hóa đơn: {hoaDon.MaHD}", fontThuong, brush, bounds.Left, y);
            g.DrawString($"Ngày lập: {hoaDon.NgayLap:dd/MM/yyyy HH:mm}", fontThuong, brush, bounds.Left + 360, y);
            y += 24;
            g.DrawString($"Khách hàng: {hoaDon.HoTenKhachHang}", fontThuong, brush, bounds.Left, y);
            y += 24;
            g.DrawString($"Nhân viên: {hoaDon.HoTenNhanVien}", fontThuong, brush, bounds.Left, y);
            y += 34;

            var cotStt = bounds.Left;
            var cotSanPham = cotStt + 45;
            var cotSoLuong = cotSanPham + 270;
            var cotDonGia = cotSoLuong + 85;
            var cotThanhTien = cotDonGia + 120;
            var chieuCaoDong = 28;

            VeDongBang(g, pen, brush, fontDam, y, chieuCaoDong,
                ("STT", cotStt, 45),
                ("Sản phẩm", cotSanPham, 270),
                ("SL", cotSoLuong, 85),
                ("Đơn giá", cotDonGia, 120),
                ("Thành tiền", cotThanhTien, 130));
            y += chieuCaoDong;

            while (_dongInHienTai < _chiTietDangIn.Count)
            {
                if (y + chieuCaoDong + 70 > bounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }

                var chiTiet = _chiTietDangIn[_dongInHienTai];
                VeDongBang(g, pen, brush, fontNho, y, chieuCaoDong,
                    ((_dongInHienTai + 1).ToString(), cotStt, 45),
                    (chiTiet.TenSP, cotSanPham, 270),
                    (chiTiet.SoLuong.ToString(), cotSoLuong, 85),
                    ($"{chiTiet.DonGia:N0}", cotDonGia, 120),
                    ($"{chiTiet.ThanhTien:N0}", cotThanhTien, 130));
                y += chieuCaoDong;
                _dongInHienTai++;
            }

            var tongTien = _chiTietDangIn.Sum(x => x.ThanhTien);
            y += 18;
            g.DrawString($"Tổng tiền: {tongTien:N0} VNĐ", fontDam, brush, cotDonGia, y);
            y += 42;
            DrawCanGiua(g, "Cảm ơn quý khách!", fontThuong, brush, bounds, y);
            e.HasMorePages = false;
        }

        private static void VeDongBang(
            Graphics g,
            Pen pen,
            Brush brush,
            Font font,
            int y,
            int chieuCao,
            params (string Text, int X, int Width)[] cells)
        {
            foreach (var cell in cells)
            {
                var rect = new Rectangle(cell.X, y, cell.Width, chieuCao);
                g.DrawRectangle(pen, rect);
                g.DrawString(cell.Text, font, brush, new RectangleF(rect.X + 5, rect.Y + 6, rect.Width - 10, rect.Height - 8));
            }
        }

        private static void DrawCanGiua(Graphics g, string text, Font font, Brush brush, Rectangle bounds, int y)
        {
            var size = g.MeasureString(text, font);
            g.DrawString(text, font, brush, bounds.Left + (bounds.Width - size.Width) / 2, y);
        }

        private void CauHinhThongTinHoaDon()
        {
            grpThongTin.Text = "Thông tin hóa đơn";
            labelMaCTHD.Text = "Mã HĐ";
            labelMaHD.Text = "Khách hàng";
            labelMaSP.Text = "Nhân viên";
            labelTenSP.Text = "Ngày lập";
            labelKhachHang.Text = "Tổng tiền";
            labelNhanVien.Text = "Số sản phẩm";
            labelNgayLap.Text = "Số dòng";
            labelSoLuong.Text = "";
            labelDonGia.Text = "";
            labelThanhTien.Text = "";
            txtSoLuong.Visible = false;
            txtDonGia.Visible = false;
            txtThanhTien.Visible = false;
        }

        private void GanThongTinHoaDonLenForm(HoaDonDTO hoaDon, List<ChiTietHoaDonDTO> chiTiets)
        {
            txtMaCTHD.Text = hoaDon.MaHD.ToString();
            txtMaHD.Text = hoaDon.HoTenKhachHang;
            txtMaSP.Text = hoaDon.HoTenNhanVien;
            txtTenSP.Text = hoaDon.NgayLap.ToString("dd/MM/yyyy HH:mm");
            txtKhachHang.Text = hoaDon.TongTien.ToString("N0");
            txtNhanVien.Text = chiTiets.Count > 0 ? chiTiets.Sum(x => x.SoLuong).ToString() : "";
            txtNgayLap.Text = chiTiets.Count > 0 ? chiTiets.Count.ToString() : "";
            txtSoLuong.Clear();
            txtDonGia.Clear();
            txtThanhTien.Clear();
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
