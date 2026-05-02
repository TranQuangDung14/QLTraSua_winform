using QuanLyBanHang.BUS;

namespace QuanLyBanHang.GUI
{
    public partial class frmDangNhap : Form
    {
        private readonly TaiKhoanBUS _taiKhoanBus = new();

        public frmDangNhap()
        {
            InitializeComponent();
            cboQuyen.SelectedIndex = 0;
            txtTenDangNhap.Select();
        }

        private async void btnDangNhap_Click(object sender, EventArgs e)
        {
            await DangNhapAsync();
        }

        private async Task DangNhapAsync()
        {
            BatCheDoDangNhap(false, "Đang kiểm tra tài khoản...");

            try
            {
                var taiKhoan = await _taiKhoanBus.DangNhapAsync(
                    txtTenDangNhap.Text,
                    txtMatKhau.Text,
                    cboQuyen.Text);

                if (taiKhoan is null)
                {
                    CapNhatThongBao("Sai tên đăng nhập, mật khẩu hoặc quyền truy cập.", true);
                    txtMatKhau.SelectAll();
                    txtMatKhau.Focus();
                    return;
                }

                CapNhatThongBao("Đăng nhập thành công.", false);
                Hide();

                using var frm = new frmTrangChu(taiKhoan.HoTen, taiKhoan.Quyen);
                frm.ShowDialog(this);

                Show();
                txtMatKhau.Clear();
                txtMatKhau.Focus();
                CapNhatThongBao("Vui lòng đăng nhập để tiếp tục.", false);
            }
            catch (ArgumentException ex)
            {
                CapNhatThongBao(ex.Message, true);
            }
            catch (Exception ex)
            {
                CapNhatThongBao($"Không thể kết nối cơ sở dữ liệu: {ex.Message}", true);
            }
            finally
            {
                BatCheDoDangNhap(true, lblThongBao.Text);
            }
        }

        private void chkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = !chkHienMatKhau.Checked;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void InputValueChanged(object sender, EventArgs e)
        {
            CapNhatThongBao("Vui lòng đăng nhập để tiếp tục.", false);
        }

        private void BatCheDoDangNhap(bool sanSang, string thongBao)
        {
            txtTenDangNhap.Enabled = sanSang;
            txtMatKhau.Enabled = sanSang;
            cboQuyen.Enabled = sanSang;
            chkHienMatKhau.Enabled = sanSang;
            btnDangNhap.Enabled = sanSang;
            btnThoat.Enabled = sanSang;
            CapNhatThongBao(thongBao, false);
        }

        private void CapNhatThongBao(string thongBao, bool laLoi)
        {
            lblThongBao.ForeColor = laLoi
                ? Color.FromArgb(220, 38, 38)
                : Color.FromArgb(13, 148, 136);
            lblThongBao.Text = thongBao;
        }
    }
}
