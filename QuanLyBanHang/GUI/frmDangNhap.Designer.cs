namespace QuanLyBanHang.GUI
{
    partial class frmDangNhap
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelBrand = new Panel();
            labelBrandBody = new Label();
            labelBrandCaption = new Label();
            labelBrandTitle = new Label();
            panelLogin = new Panel();
            lblThongBao = new Label();
            btnThoat = new Button();
            btnDangNhap = new Button();
            chkHienMatKhau = new CheckBox();
            cboQuyen = new ComboBox();
            lblQuyen = new Label();
            txtMatKhau = new TextBox();
            lblMatKhau = new Label();
            txtTenDangNhap = new TextBox();
            lblTenDangNhap = new Label();
            labelTaiKhoanMau = new Label();
            lblTieuDe = new Label();
            panelBrand.SuspendLayout();
            panelLogin.SuspendLayout();
            SuspendLayout();
            // 
            // panelBrand
            // 
            panelBrand.BackColor = Color.FromArgb(15, 118, 110);
            panelBrand.Controls.Add(labelBrandBody);
            panelBrand.Controls.Add(labelBrandCaption);
            panelBrand.Controls.Add(labelBrandTitle);
            panelBrand.Dock = DockStyle.Left;
            panelBrand.Location = new Point(0, 0);
            panelBrand.Name = "panelBrand";
            panelBrand.Size = new Size(380, 620);
            panelBrand.TabIndex = 0;
            // 
            // labelBrandBody
            // 
            labelBrandBody.AutoSize = true;
            labelBrandBody.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            labelBrandBody.ForeColor = Color.FromArgb(204, 251, 241);
            labelBrandBody.Location = new Point(40, 280);
            labelBrandBody.MaximumSize = new Size(300, 0);
            labelBrandBody.Name = "labelBrandBody";
            labelBrandBody.Size = new Size(290, 100);
            labelBrandBody.TabIndex = 2;
            labelBrandBody.Text = "Đăng nhập bằng tài khoản nhân viên để truy cập các phân hệ sản phẩm, khách hàng, hóa đơn và thống kê doanh thu.";
            // 
            // labelBrandCaption
            // 
            labelBrandCaption.AutoSize = true;
            labelBrandCaption.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point);
            labelBrandCaption.ForeColor = Color.White;
            labelBrandCaption.Location = new Point(40, 230);
            labelBrandCaption.Name = "labelBrandCaption";
            labelBrandCaption.Size = new Size(251, 25);
            labelBrandCaption.TabIndex = 1;
            labelBrandCaption.Text = "Hệ thống quản lý bán hàng";
            // 
            // labelBrandTitle
            // 
            labelBrandTitle.AutoSize = true;
            labelBrandTitle.Font = new Font("Segoe UI Semibold", 28F, FontStyle.Bold, GraphicsUnit.Point);
            labelBrandTitle.ForeColor = Color.White;
            labelBrandTitle.Location = new Point(36, 152);
            labelBrandTitle.Name = "labelBrandTitle";
            labelBrandTitle.Size = new Size(248, 51);
            labelBrandTitle.TabIndex = 0;
            labelBrandTitle.Text = "Trà sữa UTEHY";
            // 
            // panelLogin
            // 
            panelLogin.BackColor = Color.White;
            panelLogin.Controls.Add(lblThongBao);
            panelLogin.Controls.Add(btnThoat);
            panelLogin.Controls.Add(btnDangNhap);
            panelLogin.Controls.Add(chkHienMatKhau);
            panelLogin.Controls.Add(cboQuyen);
            panelLogin.Controls.Add(lblQuyen);
            panelLogin.Controls.Add(txtMatKhau);
            panelLogin.Controls.Add(lblMatKhau);
            panelLogin.Controls.Add(txtTenDangNhap);
            panelLogin.Controls.Add(lblTenDangNhap);
            panelLogin.Controls.Add(labelTaiKhoanMau);
            panelLogin.Controls.Add(lblTieuDe);
            panelLogin.Dock = DockStyle.Fill;
            panelLogin.Location = new Point(380, 0);
            panelLogin.Name = "panelLogin";
            panelLogin.Size = new Size(520, 620);
            panelLogin.TabIndex = 1;
            // 
            // lblThongBao
            // 
            lblThongBao.AutoSize = true;
            lblThongBao.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblThongBao.ForeColor = Color.FromArgb(13, 148, 136);
            lblThongBao.Location = new Point(53, 450);
            lblThongBao.Name = "lblThongBao";
            lblThongBao.Size = new Size(234, 19);
            lblThongBao.TabIndex = 11;
            lblThongBao.Text = "Vui lòng đăng nhập để tiếp tục.";
            // 
            // btnThoat
            // 
            btnThoat.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnThoat.FlatStyle = FlatStyle.Flat;
            btnThoat.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            btnThoat.ForeColor = Color.FromArgb(51, 65, 85);
            btnThoat.Location = new Point(235, 500);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(160, 44);
            btnThoat.TabIndex = 5;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnDangNhap
            // 
            btnDangNhap.BackColor = Color.FromArgb(15, 118, 110);
            btnDangNhap.FlatAppearance.BorderSize = 0;
            btnDangNhap.FlatStyle = FlatStyle.Flat;
            btnDangNhap.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            btnDangNhap.ForeColor = Color.White;
            btnDangNhap.Location = new Point(53, 500);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Size = new Size(160, 44);
            btnDangNhap.TabIndex = 4;
            btnDangNhap.Text = "Đăng nhập";
            btnDangNhap.UseVisualStyleBackColor = false;
            btnDangNhap.Click += btnDangNhap_Click;
            // 
            // chkHienMatKhau
            // 
            chkHienMatKhau.AutoSize = true;
            chkHienMatKhau.ForeColor = Color.FromArgb(51, 65, 85);
            chkHienMatKhau.Location = new Point(53, 409);
            chkHienMatKhau.Name = "chkHienMatKhau";
            chkHienMatKhau.Size = new Size(127, 23);
            chkHienMatKhau.TabIndex = 3;
            chkHienMatKhau.Text = "Hiện mật khẩu";
            chkHienMatKhau.UseVisualStyleBackColor = true;
            chkHienMatKhau.CheckedChanged += chkHienMatKhau_CheckedChanged;
            // 
            // cboQuyen
            // 
            cboQuyen.DropDownStyle = ComboBoxStyle.DropDownList;
            cboQuyen.FormattingEnabled = true;
            cboQuyen.Items.AddRange(new object[] { "Admin", "Nhân viên" });
            cboQuyen.Location = new Point(53, 353);
            cboQuyen.Name = "cboQuyen";
            cboQuyen.Size = new Size(342, 25);
            cboQuyen.TabIndex = 2;
            cboQuyen.SelectedIndexChanged += InputValueChanged;
            // 
            // lblQuyen
            // 
            lblQuyen.AutoSize = true;
            lblQuyen.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            lblQuyen.ForeColor = Color.FromArgb(30, 41, 59);
            lblQuyen.Location = new Point(53, 324);
            lblQuyen.Name = "lblQuyen";
            lblQuyen.Size = new Size(51, 19);
            lblQuyen.TabIndex = 7;
            lblQuyen.Text = "Quyền";
            // 
            // txtMatKhau
            // 
            txtMatKhau.BorderStyle = BorderStyle.FixedSingle;
            txtMatKhau.Location = new Point(53, 269);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.PlaceholderText = "Nhập mật khẩu";
            txtMatKhau.Size = new Size(342, 25);
            txtMatKhau.TabIndex = 1;
            txtMatKhau.TextChanged += InputValueChanged;
            txtMatKhau.UseSystemPasswordChar = true;
            // 
            // lblMatKhau
            // 
            lblMatKhau.AutoSize = true;
            lblMatKhau.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            lblMatKhau.ForeColor = Color.FromArgb(30, 41, 59);
            lblMatKhau.Location = new Point(53, 240);
            lblMatKhau.Name = "lblMatKhau";
            lblMatKhau.Size = new Size(74, 19);
            lblMatKhau.TabIndex = 5;
            lblMatKhau.Text = "Mật khẩu";
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.BorderStyle = BorderStyle.FixedSingle;
            txtTenDangNhap.Location = new Point(53, 185);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.PlaceholderText = "Nhập tên đăng nhập";
            txtTenDangNhap.Size = new Size(342, 25);
            txtTenDangNhap.TabIndex = 0;
            txtTenDangNhap.TextChanged += InputValueChanged;
            // 
            // lblTenDangNhap
            // 
            lblTenDangNhap.AutoSize = true;
            lblTenDangNhap.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            lblTenDangNhap.ForeColor = Color.FromArgb(30, 41, 59);
            lblTenDangNhap.Location = new Point(53, 156);
            lblTenDangNhap.Name = "lblTenDangNhap";
            lblTenDangNhap.Size = new Size(109, 19);
            lblTenDangNhap.TabIndex = 3;
            lblTenDangNhap.Text = "Tên đăng nhập";
            // 
            // labelTaiKhoanMau
            // 
            labelTaiKhoanMau.AutoSize = true;
            labelTaiKhoanMau.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelTaiKhoanMau.ForeColor = Color.FromArgb(100, 116, 139);
            labelTaiKhoanMau.Location = new Point(53, 95);
            labelTaiKhoanMau.Name = "labelTaiKhoanMau";
            labelTaiKhoanMau.Size = new Size(278, 38);
            labelTaiKhoanMau.TabIndex = 1;
            labelTaiKhoanMau.Text = "Tài khoản mẫu hiện có trong cơ sở dữ liệu:\r\nadmin / 123 / Admin";
            // 
            // lblTieuDe
            // 
            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI Semibold", 22F, FontStyle.Bold, GraphicsUnit.Point);
            lblTieuDe.ForeColor = Color.FromArgb(15, 23, 42);
            lblTieuDe.Location = new Point(46, 44);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(177, 41);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "Đăng nhập";
            // 
            // frmDangNhap
            // 
            AcceptButton = btnDangNhap;
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btnThoat;
            ClientSize = new Size(900, 620);
            Controls.Add(panelLogin);
            Controls.Add(panelBrand);
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmDangNhap";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập hệ thống";
            panelBrand.ResumeLayout(false);
            panelBrand.PerformLayout();
            panelLogin.ResumeLayout(false);
            panelLogin.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelBrand;
        private Label labelBrandBody;
        private Label labelBrandCaption;
        private Label labelBrandTitle;
        private Panel panelLogin;
        private Label lblThongBao;
        private Button btnThoat;
        private Button btnDangNhap;
        private CheckBox chkHienMatKhau;
        private ComboBox cboQuyen;
        private Label lblQuyen;
        private TextBox txtMatKhau;
        private Label lblMatKhau;
        private TextBox txtTenDangNhap;
        private Label lblTenDangNhap;
        private Label labelTaiKhoanMau;
        private Label lblTieuDe;
    }
}
