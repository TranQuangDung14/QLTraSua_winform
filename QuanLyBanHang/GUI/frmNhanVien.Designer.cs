namespace QuanLyBanHang.GUI
{
    partial class frmNhanVien
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
            panelTop = new Panel();
            btnTimKiem = new Button();
            txtTimKiem = new TextBox();
            lblTimKiem = new Label();
            lblTieuDe = new Label();
            panelEditor = new Panel();
            chkHienMatKhau = new CheckBox();
            cboQuyen = new ComboBox();
            lblQuyen = new Label();
            txtMatKhau = new TextBox();
            lblMatKhau = new Label();
            txtTenDangNhap = new TextBox();
            lblTenDangNhap = new Label();
            txtChucVu = new TextBox();
            lblChucVu = new Label();
            txtDiaChi = new TextBox();
            lblDiaChi = new Label();
            txtSoDienThoai = new TextBox();
            lblSoDienThoai = new Label();
            dtpNgaySinh = new DateTimePicker();
            lblNgaySinh = new Label();
            cboGioiTinh = new ComboBox();
            lblGioiTinh = new Label();
            lblThongBao = new Label();
            btnDong = new Button();
            btnLamMoi = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnThem = new Button();
            txtHoTen = new TextBox();
            lblHoTen = new Label();
            txtMaNV = new TextBox();
            lblMaNV = new Label();
            dgvNhanVien = new DataGridView();
            panelTop.SuspendLayout();
            panelEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.White;
            panelTop.Controls.Add(btnTimKiem);
            panelTop.Controls.Add(txtTimKiem);
            panelTop.Controls.Add(lblTimKiem);
            panelTop.Controls.Add(lblTieuDe);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1420, 110);
            panelTop.TabIndex = 0;
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = Color.FromArgb(15, 118, 110);
            btnTimKiem.FlatAppearance.BorderSize = 0;
            btnTimKiem.FlatStyle = FlatStyle.Flat;
            btnTimKiem.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnTimKiem.ForeColor = Color.White;
            btnTimKiem.Location = new Point(1260, 48);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(110, 36);
            btnTimKiem.TabIndex = 3;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = false;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // txtTimKiem
            // 
            txtTimKiem.BorderStyle = BorderStyle.FixedSingle;
            txtTimKiem.Location = new Point(978, 54);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Nhập họ tên nhân viên";
            txtTimKiem.Size = new Size(264, 25);
            txtTimKiem.TabIndex = 2;
            // 
            // lblTimKiem
            // 
            lblTimKiem.AutoSize = true;
            lblTimKiem.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblTimKiem.ForeColor = Color.FromArgb(51, 65, 85);
            lblTimKiem.Location = new Point(978, 29);
            lblTimKiem.Name = "lblTimKiem";
            lblTimKiem.Size = new Size(69, 19);
            lblTimKiem.TabIndex = 1;
            lblTimKiem.Text = "Tìm kiếm";
            // 
            // lblTieuDe
            // 
            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point);
            lblTieuDe.ForeColor = Color.FromArgb(15, 23, 42);
            lblTieuDe.Location = new Point(28, 28);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(182, 45);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "Nhân viên";
            // 
            // panelEditor
            // 
            panelEditor.BackColor = Color.White;
            panelEditor.Controls.Add(chkHienMatKhau);
            panelEditor.Controls.Add(cboQuyen);
            panelEditor.Controls.Add(lblQuyen);
            panelEditor.Controls.Add(txtMatKhau);
            panelEditor.Controls.Add(lblMatKhau);
            panelEditor.Controls.Add(txtTenDangNhap);
            panelEditor.Controls.Add(lblTenDangNhap);
            panelEditor.Controls.Add(txtChucVu);
            panelEditor.Controls.Add(lblChucVu);
            panelEditor.Controls.Add(txtDiaChi);
            panelEditor.Controls.Add(lblDiaChi);
            panelEditor.Controls.Add(txtSoDienThoai);
            panelEditor.Controls.Add(lblSoDienThoai);
            panelEditor.Controls.Add(dtpNgaySinh);
            panelEditor.Controls.Add(lblNgaySinh);
            panelEditor.Controls.Add(cboGioiTinh);
            panelEditor.Controls.Add(lblGioiTinh);
            panelEditor.Controls.Add(lblThongBao);
            panelEditor.Controls.Add(btnDong);
            panelEditor.Controls.Add(btnLamMoi);
            panelEditor.Controls.Add(btnXoa);
            panelEditor.Controls.Add(btnSua);
            panelEditor.Controls.Add(btnThem);
            panelEditor.Controls.Add(txtHoTen);
            panelEditor.Controls.Add(lblHoTen);
            panelEditor.Controls.Add(txtMaNV);
            panelEditor.Controls.Add(lblMaNV);
            panelEditor.Dock = DockStyle.Left;
            panelEditor.Location = new Point(0, 110);
            panelEditor.Name = "panelEditor";
            panelEditor.Padding = new Padding(28);
            panelEditor.Size = new Size(460, 710);
            panelEditor.TabIndex = 1;
            // 
            // chkHienMatKhau
            // 
            chkHienMatKhau.AutoSize = true;
            chkHienMatKhau.Location = new Point(31, 541);
            chkHienMatKhau.Name = "chkHienMatKhau";
            chkHienMatKhau.Size = new Size(127, 23);
            chkHienMatKhau.TabIndex = 17;
            chkHienMatKhau.Text = "Hiện mật khẩu";
            chkHienMatKhau.UseVisualStyleBackColor = true;
            chkHienMatKhau.CheckedChanged += chkHienMatKhau_CheckedChanged;
            // 
            // cboQuyen
            // 
            cboQuyen.DropDownStyle = ComboBoxStyle.DropDownList;
            cboQuyen.FormattingEnabled = true;
            cboQuyen.Items.AddRange(new object[] { "", "Admin", "Nhân viên" });
            cboQuyen.Location = new Point(31, 507);
            cboQuyen.Name = "cboQuyen";
            cboQuyen.Size = new Size(380, 25);
            cboQuyen.TabIndex = 16;
            // 
            // lblQuyen
            // 
            lblQuyen.AutoSize = true;
            lblQuyen.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblQuyen.ForeColor = Color.FromArgb(51, 65, 85);
            lblQuyen.Location = new Point(31, 480);
            lblQuyen.Name = "lblQuyen";
            lblQuyen.Size = new Size(51, 19);
            lblQuyen.TabIndex = 15;
            lblQuyen.Text = "Quyền";
            // 
            // txtMatKhau
            // 
            txtMatKhau.BorderStyle = BorderStyle.FixedSingle;
            txtMatKhau.Location = new Point(31, 451);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(380, 25);
            txtMatKhau.TabIndex = 14;
            txtMatKhau.UseSystemPasswordChar = true;
            // 
            // lblMatKhau
            // 
            lblMatKhau.AutoSize = true;
            lblMatKhau.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblMatKhau.ForeColor = Color.FromArgb(51, 65, 85);
            lblMatKhau.Location = new Point(31, 424);
            lblMatKhau.Name = "lblMatKhau";
            lblMatKhau.Size = new Size(68, 19);
            lblMatKhau.TabIndex = 13;
            lblMatKhau.Text = "Mật khẩu";
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.BorderStyle = BorderStyle.FixedSingle;
            txtTenDangNhap.Location = new Point(31, 395);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(380, 25);
            txtTenDangNhap.TabIndex = 12;
            // 
            // lblTenDangNhap
            // 
            lblTenDangNhap.AutoSize = true;
            lblTenDangNhap.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblTenDangNhap.ForeColor = Color.FromArgb(51, 65, 85);
            lblTenDangNhap.Location = new Point(31, 368);
            lblTenDangNhap.Name = "lblTenDangNhap";
            lblTenDangNhap.Size = new Size(103, 19);
            lblTenDangNhap.TabIndex = 11;
            lblTenDangNhap.Text = "Tên đăng nhập";
            // 
            // txtChucVu
            // 
            txtChucVu.BorderStyle = BorderStyle.FixedSingle;
            txtChucVu.Location = new Point(31, 339);
            txtChucVu.Name = "txtChucVu";
            txtChucVu.Size = new Size(380, 25);
            txtChucVu.TabIndex = 10;
            // 
            // lblChucVu
            // 
            lblChucVu.AutoSize = true;
            lblChucVu.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblChucVu.ForeColor = Color.FromArgb(51, 65, 85);
            lblChucVu.Location = new Point(31, 312);
            lblChucVu.Name = "lblChucVu";
            lblChucVu.Size = new Size(57, 19);
            lblChucVu.TabIndex = 9;
            lblChucVu.Text = "Chức vụ";
            // 
            // txtDiaChi
            // 
            txtDiaChi.BorderStyle = BorderStyle.FixedSingle;
            txtDiaChi.Location = new Point(31, 283);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(380, 25);
            txtDiaChi.TabIndex = 8;
            // 
            // lblDiaChi
            // 
            lblDiaChi.AutoSize = true;
            lblDiaChi.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblDiaChi.ForeColor = Color.FromArgb(51, 65, 85);
            lblDiaChi.Location = new Point(31, 256);
            lblDiaChi.Name = "lblDiaChi";
            lblDiaChi.Size = new Size(50, 19);
            lblDiaChi.TabIndex = 7;
            lblDiaChi.Text = "Địa chỉ";
            // 
            // txtSoDienThoai
            // 
            txtSoDienThoai.BorderStyle = BorderStyle.FixedSingle;
            txtSoDienThoai.Location = new Point(31, 227);
            txtSoDienThoai.Name = "txtSoDienThoai";
            txtSoDienThoai.Size = new Size(380, 25);
            txtSoDienThoai.TabIndex = 6;
            // 
            // lblSoDienThoai
            // 
            lblSoDienThoai.AutoSize = true;
            lblSoDienThoai.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblSoDienThoai.ForeColor = Color.FromArgb(51, 65, 85);
            lblSoDienThoai.Location = new Point(31, 200);
            lblSoDienThoai.Name = "lblSoDienThoai";
            lblSoDienThoai.Size = new Size(92, 19);
            lblSoDienThoai.TabIndex = 5;
            lblSoDienThoai.Text = "Số điện thoại";
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.Checked = false;
            dtpNgaySinh.Format = DateTimePickerFormat.Short;
            dtpNgaySinh.Location = new Point(216, 171);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.ShowCheckBox = true;
            dtpNgaySinh.Size = new Size(195, 25);
            dtpNgaySinh.TabIndex = 4;
            // 
            // lblNgaySinh
            // 
            lblNgaySinh.AutoSize = true;
            lblNgaySinh.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblNgaySinh.ForeColor = Color.FromArgb(51, 65, 85);
            lblNgaySinh.Location = new Point(216, 144);
            lblNgaySinh.Name = "lblNgaySinh";
            lblNgaySinh.Size = new Size(69, 19);
            lblNgaySinh.TabIndex = 3;
            lblNgaySinh.Text = "Ngày sinh";
            // 
            // cboGioiTinh
            // 
            cboGioiTinh.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGioiTinh.FormattingEnabled = true;
            cboGioiTinh.Items.AddRange(new object[] { "", "Nam", "Nữ", "Khác" });
            cboGioiTinh.Location = new Point(31, 171);
            cboGioiTinh.Name = "cboGioiTinh";
            cboGioiTinh.Size = new Size(170, 25);
            cboGioiTinh.TabIndex = 2;
            // 
            // lblGioiTinh
            // 
            lblGioiTinh.AutoSize = true;
            lblGioiTinh.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblGioiTinh.ForeColor = Color.FromArgb(51, 65, 85);
            lblGioiTinh.Location = new Point(31, 144);
            lblGioiTinh.Name = "lblGioiTinh";
            lblGioiTinh.Size = new Size(64, 19);
            lblGioiTinh.TabIndex = 1;
            lblGioiTinh.Text = "Giới tính";
            // 
            // lblThongBao
            // 
            lblThongBao.AutoSize = true;
            lblThongBao.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblThongBao.ForeColor = Color.FromArgb(13, 148, 136);
            lblThongBao.Location = new Point(31, 652);
            lblThongBao.MaximumSize = new Size(380, 0);
            lblThongBao.Name = "lblThongBao";
            lblThongBao.Size = new Size(159, 19);
            lblThongBao.TabIndex = 23;
            lblThongBao.Text = "Sẵn sàng thao tác dữ liệu.";
            // 
            // btnDong
            // 
            btnDong.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnDong.FlatStyle = FlatStyle.Flat;
            btnDong.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnDong.ForeColor = Color.FromArgb(51, 65, 85);
            btnDong.Location = new Point(216, 591);
            btnDong.Name = "btnDong";
            btnDong.Size = new Size(150, 42);
            btnDong.TabIndex = 22;
            btnDong.Text = "Đóng";
            btnDong.UseVisualStyleBackColor = true;
            btnDong.Click += btnDong_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnLamMoi.ForeColor = Color.FromArgb(51, 65, 85);
            btnLamMoi.Location = new Point(31, 591);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(150, 42);
            btnLamMoi.TabIndex = 21;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.FromArgb(239, 68, 68);
            btnXoa.FlatAppearance.BorderSize = 0;
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(323, 536);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(88, 42);
            btnXoa.TabIndex = 20;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.FromArgb(59, 130, 246);
            btnSua.FlatAppearance.BorderSize = 0;
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnSua.ForeColor = Color.White;
            btnSua.Location = new Point(175, 536);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(88, 42);
            btnSua.TabIndex = 19;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.FromArgb(15, 118, 110);
            btnThem.FlatAppearance.BorderSize = 0;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(31, 536);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(88, 42);
            btnThem.TabIndex = 18;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // txtHoTen
            // 
            txtHoTen.BorderStyle = BorderStyle.FixedSingle;
            txtHoTen.Location = new Point(31, 115);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(380, 25);
            txtHoTen.TabIndex = 0;
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblHoTen.ForeColor = Color.FromArgb(51, 65, 85);
            lblHoTen.Location = new Point(31, 88);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(53, 19);
            lblHoTen.TabIndex = 24;
            lblHoTen.Text = "Họ tên";
            // 
            // txtMaNV
            // 
            txtMaNV.BackColor = Color.FromArgb(248, 250, 252);
            txtMaNV.BorderStyle = BorderStyle.FixedSingle;
            txtMaNV.Location = new Point(297, 50);
            txtMaNV.Name = "txtMaNV";
            txtMaNV.ReadOnly = true;
            txtMaNV.Size = new Size(114, 25);
            txtMaNV.TabIndex = 25;
            // 
            // lblMaNV
            // 
            lblMaNV.AutoSize = true;
            lblMaNV.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblMaNV.ForeColor = Color.FromArgb(51, 65, 85);
            lblMaNV.Location = new Point(31, 52);
            lblMaNV.Name = "lblMaNV";
            lblMaNV.Size = new Size(51, 19);
            lblMaNV.TabIndex = 26;
            lblMaNV.Text = "Mã NV";
            // 
            // dgvNhanVien
            // 
            dgvNhanVien.AllowUserToAddRows = false;
            dgvNhanVien.AllowUserToDeleteRows = false;
            dgvNhanVien.BackgroundColor = Color.White;
            dgvNhanVien.BorderStyle = BorderStyle.None;
            dgvNhanVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNhanVien.Dock = DockStyle.Fill;
            dgvNhanVien.Location = new Point(460, 110);
            dgvNhanVien.MultiSelect = false;
            dgvNhanVien.Name = "dgvNhanVien";
            dgvNhanVien.ReadOnly = true;
            dgvNhanVien.RowHeadersVisible = false;
            dgvNhanVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNhanVien.Size = new Size(960, 710);
            dgvNhanVien.TabIndex = 2;
            dgvNhanVien.SelectionChanged += dgvNhanVien_SelectionChanged;
            // 
            // frmNhanVien
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 245, 249);
            ClientSize = new Size(1420, 820);
            Controls.Add(dgvNhanVien);
            Controls.Add(panelEditor);
            Controls.Add(panelTop);
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmNhanVien";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Quản lý nhân viên";
            Load += frmNhanVien_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelEditor.ResumeLayout(false);
            panelEditor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Button btnTimKiem;
        private TextBox txtTimKiem;
        private Label lblTimKiem;
        private Label lblTieuDe;
        private Panel panelEditor;
        private CheckBox chkHienMatKhau;
        private ComboBox cboQuyen;
        private Label lblQuyen;
        private TextBox txtMatKhau;
        private Label lblMatKhau;
        private TextBox txtTenDangNhap;
        private Label lblTenDangNhap;
        private TextBox txtChucVu;
        private Label lblChucVu;
        private TextBox txtDiaChi;
        private Label lblDiaChi;
        private TextBox txtSoDienThoai;
        private Label lblSoDienThoai;
        private DateTimePicker dtpNgaySinh;
        private Label lblNgaySinh;
        private ComboBox cboGioiTinh;
        private Label lblGioiTinh;
        private Label lblThongBao;
        private Button btnDong;
        private Button btnLamMoi;
        private Button btnXoa;
        private Button btnSua;
        private Button btnThem;
        private TextBox txtHoTen;
        private Label lblHoTen;
        private TextBox txtMaNV;
        private Label lblMaNV;
        private DataGridView dgvNhanVien;
    }
}
