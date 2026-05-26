namespace QuanLyBanHang.GUI
{
    public partial class frmTrangChu : Form
    {
        private string _quyen = "Nhân viên";

        public frmTrangChu()
            : this("Người dùng", "Nhân viên")
        {
        }

        public frmTrangChu(string hoTen, string quyen)
        {
            InitializeComponent();
            ResponsiveLayout.Configure(this);
            _quyen = quyen;
            lblHoTen.Text = hoTen;
            lblQuyen.Text = quyen;
            lblLoiChao.Text = $"Xin chào, {hoTen}";
            ApDungPhanQuyen(quyen);
        }

        private void ApDungPhanQuyen(string quyen)
        {
            var laAdmin = string.Equals(quyen?.Trim(), "Admin", StringComparison.OrdinalIgnoreCase);

            if (!laAdmin)
            {
                AnChucNangQuanTri(btnLoaiSanPham, btnNhaCungCap, btnNhanVien, btnThongKe);
            }

            SapXepLaiMenu();
        }

        private static void AnChucNangQuanTri(params Button[] buttons)
        {
            foreach (var button in buttons)
            {
                button.Visible = false;
                button.Enabled = false;
            }
        }

        private void SapXepLaiMenu()
        {
            const int menuTop = 130;
            const int menuGap = 8;
            var y = menuTop;
            var menuButtons = new[]
            {
                btnSanPham,
                btnLoaiSanPham,
                btnNhaCungCap,
                btnNhanVien,
                btnKhachHang,
                btnHoaDon,
                btnChiTietHoaDon,
                btnThongKe
            };

            foreach (var button in menuButtons)
            {
                if (!button.Enabled)
                {
                    continue;
                }

                button.Location = new Point(button.Location.X, y);
                y += button.Height + menuGap;
            }
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            using var frm = new frmSanPham(_quyen);
            frm.ShowDialog(this);
        }

        private void btnLoaiSanPham_Click(object sender, EventArgs e)
        {
            using var frm = new frmLoaiSanPham();
            frm.ShowDialog(this);
        }

        private void btnNhaCungCap_Click(object sender, EventArgs e)
        {
            using var frm = new frmNhaCungCap();
            frm.ShowDialog(this);
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            using var frm = new frmNhanVien();
            frm.ShowDialog(this);
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            using var frm = new frmKhachHang();
            frm.ShowDialog(this);
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            using var frm = new frmHoaDon();
            frm.ShowDialog(this);
        }

        private void btnChiTietHoaDon_Click(object sender, EventArgs e)
        {
            using var frm = new frmChiTietHoaDon();
            frm.ShowDialog(this);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            using var frm = new frmThongKeDoanhThu();
            frm.ShowDialog(this);
        }
    }
}
