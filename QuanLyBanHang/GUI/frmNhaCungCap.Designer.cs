namespace QuanLyBanHang.GUI
{
    partial class frmNhaCungCap
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
            lblThongBao = new Label();
            btnDong = new Button();
            btnLamMoi = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnThem = new Button();
            txtEmail = new TextBox();
            lblEmail = new Label();
            txtSoDienThoai = new TextBox();
            lblSoDienThoai = new Label();
            txtDiaChi = new TextBox();
            lblDiaChi = new Label();
            txtTenNCC = new TextBox();
            lblTenNCC = new Label();
            txtMaNCC = new TextBox();
            lblMaNCC = new Label();
            dgvNhaCungCap = new DataGridView();
            panelTop.SuspendLayout();
            panelEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNhaCungCap).BeginInit();
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
            panelTop.Size = new Size(1220, 110);
            panelTop.TabIndex = 0;
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = Color.FromArgb(15, 118, 110);
            btnTimKiem.FlatAppearance.BorderSize = 0;
            btnTimKiem.FlatStyle = FlatStyle.Flat;
            btnTimKiem.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnTimKiem.ForeColor = Color.White;
            btnTimKiem.Location = new Point(1054, 48);
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
            txtTimKiem.Location = new Point(772, 54);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Nhập tên nhà cung cấp";
            txtTimKiem.Size = new Size(264, 25);
            txtTimKiem.TabIndex = 2;
            // 
            // lblTimKiem
            // 
            lblTimKiem.AutoSize = true;
            lblTimKiem.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblTimKiem.ForeColor = Color.FromArgb(51, 65, 85);
            lblTimKiem.Location = new Point(772, 29);
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
            lblTieuDe.Size = new Size(243, 45);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "Nhà cung cấp";
            // 
            // panelEditor
            // 
            panelEditor.BackColor = Color.White;
            panelEditor.Controls.Add(lblThongBao);
            panelEditor.Controls.Add(btnDong);
            panelEditor.Controls.Add(btnLamMoi);
            panelEditor.Controls.Add(btnXoa);
            panelEditor.Controls.Add(btnSua);
            panelEditor.Controls.Add(btnThem);
            panelEditor.Controls.Add(txtEmail);
            panelEditor.Controls.Add(lblEmail);
            panelEditor.Controls.Add(txtSoDienThoai);
            panelEditor.Controls.Add(lblSoDienThoai);
            panelEditor.Controls.Add(txtDiaChi);
            panelEditor.Controls.Add(lblDiaChi);
            panelEditor.Controls.Add(txtTenNCC);
            panelEditor.Controls.Add(lblTenNCC);
            panelEditor.Controls.Add(txtMaNCC);
            panelEditor.Controls.Add(lblMaNCC);
            panelEditor.Dock = DockStyle.Left;
            panelEditor.Location = new Point(0, 110);
            panelEditor.Name = "panelEditor";
            panelEditor.Padding = new Padding(28);
            panelEditor.Size = new Size(400, 610);
            panelEditor.TabIndex = 1;
            // 
            // lblThongBao
            // 
            lblThongBao.AutoSize = true;
            lblThongBao.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblThongBao.ForeColor = Color.FromArgb(13, 148, 136);
            lblThongBao.Location = new Point(31, 501);
            lblThongBao.MaximumSize = new Size(330, 0);
            lblThongBao.Name = "lblThongBao";
            lblThongBao.Size = new Size(159, 19);
            lblThongBao.TabIndex = 15;
            lblThongBao.Text = "Sẵn sàng thao tác dữ liệu.";
            // 
            // btnDong
            // 
            btnDong.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnDong.FlatStyle = FlatStyle.Flat;
            btnDong.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnDong.ForeColor = Color.FromArgb(51, 65, 85);
            btnDong.Location = new Point(199, 425);
            btnDong.Name = "btnDong";
            btnDong.Size = new Size(150, 42);
            btnDong.TabIndex = 14;
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
            btnLamMoi.Location = new Point(31, 425);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(150, 42);
            btnLamMoi.TabIndex = 13;
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
            btnXoa.Location = new Point(261, 365);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(88, 42);
            btnXoa.TabIndex = 12;
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
            btnSua.Location = new Point(146, 365);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(88, 42);
            btnSua.TabIndex = 11;
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
            btnThem.Location = new Point(31, 365);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(88, 42);
            btnThem.TabIndex = 10;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // txtEmail
            // 
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Location = new Point(31, 309);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Nhập email";
            txtEmail.Size = new Size(318, 25);
            txtEmail.TabIndex = 9;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblEmail.ForeColor = Color.FromArgb(51, 65, 85);
            lblEmail.Location = new Point(31, 282);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(44, 19);
            lblEmail.TabIndex = 8;
            lblEmail.Text = "Email";
            // 
            // txtSoDienThoai
            // 
            txtSoDienThoai.BorderStyle = BorderStyle.FixedSingle;
            txtSoDienThoai.Location = new Point(31, 234);
            txtSoDienThoai.Name = "txtSoDienThoai";
            txtSoDienThoai.PlaceholderText = "Nhập số điện thoại";
            txtSoDienThoai.Size = new Size(318, 25);
            txtSoDienThoai.TabIndex = 7;
            // 
            // lblSoDienThoai
            // 
            lblSoDienThoai.AutoSize = true;
            lblSoDienThoai.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblSoDienThoai.ForeColor = Color.FromArgb(51, 65, 85);
            lblSoDienThoai.Location = new Point(31, 207);
            lblSoDienThoai.Name = "lblSoDienThoai";
            lblSoDienThoai.Size = new Size(92, 19);
            lblSoDienThoai.TabIndex = 6;
            lblSoDienThoai.Text = "Số điện thoại";
            // 
            // txtDiaChi
            // 
            txtDiaChi.BorderStyle = BorderStyle.FixedSingle;
            txtDiaChi.Location = new Point(31, 159);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.PlaceholderText = "Nhập địa chỉ";
            txtDiaChi.Size = new Size(318, 25);
            txtDiaChi.TabIndex = 5;
            // 
            // lblDiaChi
            // 
            lblDiaChi.AutoSize = true;
            lblDiaChi.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblDiaChi.ForeColor = Color.FromArgb(51, 65, 85);
            lblDiaChi.Location = new Point(31, 132);
            lblDiaChi.Name = "lblDiaChi";
            lblDiaChi.Size = new Size(55, 19);
            lblDiaChi.TabIndex = 4;
            lblDiaChi.Text = "Địa chỉ";
            // 
            // txtTenNCC
            // 
            txtTenNCC.BorderStyle = BorderStyle.FixedSingle;
            txtTenNCC.Location = new Point(31, 84);
            txtTenNCC.Name = "txtTenNCC";
            txtTenNCC.PlaceholderText = "Nhập tên nhà cung cấp";
            txtTenNCC.Size = new Size(318, 25);
            txtTenNCC.TabIndex = 3;
            // 
            // lblTenNCC
            // 
            lblTenNCC.AutoSize = true;
            lblTenNCC.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblTenNCC.ForeColor = Color.FromArgb(51, 65, 85);
            lblTenNCC.Location = new Point(31, 57);
            lblTenNCC.Name = "lblTenNCC";
            lblTenNCC.Size = new Size(125, 19);
            lblTenNCC.TabIndex = 2;
            lblTenNCC.Text = "Tên nhà cung cấp";
            // 
            // txtMaNCC
            // 
            txtMaNCC.BackColor = Color.FromArgb(248, 250, 252);
            txtMaNCC.BorderStyle = BorderStyle.FixedSingle;
            txtMaNCC.Location = new Point(235, 30);
            txtMaNCC.Name = "txtMaNCC";
            txtMaNCC.ReadOnly = true;
            txtMaNCC.Size = new Size(114, 25);
            txtMaNCC.TabIndex = 1;
            // 
            // lblMaNCC
            // 
            lblMaNCC.AutoSize = true;
            lblMaNCC.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblMaNCC.ForeColor = Color.FromArgb(51, 65, 85);
            lblMaNCC.Location = new Point(31, 32);
            lblMaNCC.Name = "lblMaNCC";
            lblMaNCC.Size = new Size(101, 19);
            lblMaNCC.TabIndex = 0;
            lblMaNCC.Text = "Mã cung cấp";
            // 
            // dgvNhaCungCap
            // 
            dgvNhaCungCap.AllowUserToAddRows = false;
            dgvNhaCungCap.AllowUserToDeleteRows = false;
            dgvNhaCungCap.BackgroundColor = Color.White;
            dgvNhaCungCap.BorderStyle = BorderStyle.None;
            dgvNhaCungCap.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNhaCungCap.Dock = DockStyle.Fill;
            dgvNhaCungCap.Location = new Point(400, 110);
            dgvNhaCungCap.MultiSelect = false;
            dgvNhaCungCap.Name = "dgvNhaCungCap";
            dgvNhaCungCap.ReadOnly = true;
            dgvNhaCungCap.RowHeadersVisible = false;
            dgvNhaCungCap.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNhaCungCap.Size = new Size(820, 610);
            dgvNhaCungCap.TabIndex = 2;
            dgvNhaCungCap.SelectionChanged += dgvNhaCungCap_SelectionChanged;
            // 
            // frmNhaCungCap
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 245, 249);
            ClientSize = new Size(1220, 720);
            Controls.Add(dgvNhaCungCap);
            Controls.Add(panelEditor);
            Controls.Add(panelTop);
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmNhaCungCap";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Quản lý nhà cung cấp";
            Load += frmNhaCungCap_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelEditor.ResumeLayout(false);
            panelEditor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNhaCungCap).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Button btnTimKiem;
        private TextBox txtTimKiem;
        private Label lblTimKiem;
        private Label lblTieuDe;
        private Panel panelEditor;
        private Label lblThongBao;
        private Button btnDong;
        private Button btnLamMoi;
        private Button btnXoa;
        private Button btnSua;
        private Button btnThem;
        private TextBox txtEmail;
        private Label lblEmail;
        private TextBox txtSoDienThoai;
        private Label lblSoDienThoai;
        private TextBox txtDiaChi;
        private Label lblDiaChi;
        private TextBox txtTenNCC;
        private Label lblTenNCC;
        private TextBox txtMaNCC;
        private Label lblMaNCC;
        private DataGridView dgvNhaCungCap;
    }
}
