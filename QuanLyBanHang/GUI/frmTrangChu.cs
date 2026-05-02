namespace QuanLyBanHang.GUI
{
    public partial class frmTrangChu : Form
    {
        public frmTrangChu()
            : this("Người dùng", "Nhân viên")
        {
        }

        public frmTrangChu(string hoTen, string quyen)
        {
            InitializeComponent();
            lblHoTen.Text = hoTen;
            lblQuyen.Text = quyen;
            lblLoiChao.Text = $"Xin chào, {hoTen}";
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            using var frm = new frmSanPham();
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
