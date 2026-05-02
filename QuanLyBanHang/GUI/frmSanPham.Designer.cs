namespace QuanLyBanHang.GUI
{
    partial class frmSanPham
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
            txtMoTa = new TextBox();
            lblMoTa = new Label();
            nudSoLuong = new NumericUpDown();
            lblSoLuong = new Label();
            nudDonGia = new NumericUpDown();
            lblDonGia = new Label();
            cboNhaCungCap = new ComboBox();
            lblNhaCungCap = new Label();
            cboLoaiSanPham = new ComboBox();
            lblLoaiSanPham = new Label();
            lblThongBao = new Label();
            btnDong = new Button();
            btnLamMoi = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnThem = new Button();
            txtTenSP = new TextBox();
            lblTenSP = new Label();
            txtMaSP = new TextBox();
            lblMaSP = new Label();
            dgvSanPham = new DataGridView();
            panelTop.SuspendLayout();
            panelEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudSoLuong).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudDonGia).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).BeginInit();
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
            panelTop.Size = new Size(1360, 110);
            panelTop.TabIndex = 0;
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = Color.FromArgb(15, 118, 110);
            btnTimKiem.FlatAppearance.BorderSize = 0;
            btnTimKiem.FlatStyle = FlatStyle.Flat;
            btnTimKiem.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnTimKiem.ForeColor = Color.White;
            btnTimKiem.Location = new Point(1205, 48);
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
            txtTimKiem.Location = new Point(923, 54);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Nhập tên sản phẩm";
            txtTimKiem.Size = new Size(264, 25);
            txtTimKiem.TabIndex = 2;
            // 
            // lblTimKiem
            // 
            lblTimKiem.AutoSize = true;
            lblTimKiem.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblTimKiem.ForeColor = Color.FromArgb(51, 65, 85);
            lblTimKiem.Location = new Point(923, 29);
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
            lblTieuDe.Size = new Size(180, 45);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "Sản phẩm";
            // 
            // panelEditor
            // 
            panelEditor.BackColor = Color.White;
            panelEditor.Controls.Add(txtMoTa);
            panelEditor.Controls.Add(lblMoTa);
            panelEditor.Controls.Add(nudSoLuong);
            panelEditor.Controls.Add(lblSoLuong);
            panelEditor.Controls.Add(nudDonGia);
            panelEditor.Controls.Add(lblDonGia);
            panelEditor.Controls.Add(cboNhaCungCap);
            panelEditor.Controls.Add(lblNhaCungCap);
            panelEditor.Controls.Add(cboLoaiSanPham);
            panelEditor.Controls.Add(lblLoaiSanPham);
            panelEditor.Controls.Add(lblThongBao);
            panelEditor.Controls.Add(btnDong);
            panelEditor.Controls.Add(btnLamMoi);
            panelEditor.Controls.Add(btnXoa);
            panelEditor.Controls.Add(btnSua);
            panelEditor.Controls.Add(btnThem);
            panelEditor.Controls.Add(txtTenSP);
            panelEditor.Controls.Add(lblTenSP);
            panelEditor.Controls.Add(txtMaSP);
            panelEditor.Controls.Add(lblMaSP);
            panelEditor.Dock = DockStyle.Left;
            panelEditor.Location = new Point(0, 110);
            panelEditor.Name = "panelEditor";
            panelEditor.Padding = new Padding(28);
            panelEditor.Size = new Size(430, 670);
            panelEditor.TabIndex = 1;
            // 
            // txtMoTa
            // 
            txtMoTa.BorderStyle = BorderStyle.FixedSingle;
            txtMoTa.Location = new Point(31, 365);
            txtMoTa.Multiline = true;
            txtMoTa.Name = "txtMoTa";
            txtMoTa.PlaceholderText = "Nhập mô tả sản phẩm";
            txtMoTa.Size = new Size(355, 90);
            txtMoTa.TabIndex = 11;
            // 
            // lblMoTa
            // 
            lblMoTa.AutoSize = true;
            lblMoTa.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblMoTa.ForeColor = Color.FromArgb(51, 65, 85);
            lblMoTa.Location = new Point(31, 338);
            lblMoTa.Name = "lblMoTa";
            lblMoTa.Size = new Size(44, 19);
            lblMoTa.TabIndex = 10;
            lblMoTa.Text = "Mô tả";
            // 
            // nudSoLuong
            // 
            nudSoLuong.Location = new Point(216, 286);
            nudSoLuong.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudSoLuong.Name = "nudSoLuong";
            nudSoLuong.Size = new Size(170, 25);
            nudSoLuong.TabIndex = 9;
            // 
            // lblSoLuong
            // 
            lblSoLuong.AutoSize = true;
            lblSoLuong.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblSoLuong.ForeColor = Color.FromArgb(51, 65, 85);
            lblSoLuong.Location = new Point(216, 259);
            lblSoLuong.Name = "lblSoLuong";
            lblSoLuong.Size = new Size(66, 19);
            lblSoLuong.TabIndex = 8;
            lblSoLuong.Text = "Số lượng";
            // 
            // nudDonGia
            // 
            nudDonGia.Location = new Point(31, 286);
            nudDonGia.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            nudDonGia.Name = "nudDonGia";
            nudDonGia.Size = new Size(170, 25);
            nudDonGia.TabIndex = 7;
            nudDonGia.ThousandsSeparator = true;
            // 
            // lblDonGia
            // 
            lblDonGia.AutoSize = true;
            lblDonGia.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblDonGia.ForeColor = Color.FromArgb(51, 65, 85);
            lblDonGia.Location = new Point(31, 259);
            lblDonGia.Name = "lblDonGia";
            lblDonGia.Size = new Size(61, 19);
            lblDonGia.TabIndex = 6;
            lblDonGia.Text = "Đơn giá";
            // 
            // cboNhaCungCap
            // 
            cboNhaCungCap.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNhaCungCap.FormattingEnabled = true;
            cboNhaCungCap.Location = new Point(31, 214);
            cboNhaCungCap.Name = "cboNhaCungCap";
            cboNhaCungCap.Size = new Size(355, 25);
            cboNhaCungCap.TabIndex = 5;
            // 
            // lblNhaCungCap
            // 
            lblNhaCungCap.AutoSize = true;
            lblNhaCungCap.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblNhaCungCap.ForeColor = Color.FromArgb(51, 65, 85);
            lblNhaCungCap.Location = new Point(31, 187);
            lblNhaCungCap.Name = "lblNhaCungCap";
            lblNhaCungCap.Size = new Size(113, 19);
            lblNhaCungCap.TabIndex = 4;
            lblNhaCungCap.Text = "Nhà cung cấp";
            // 
            // cboLoaiSanPham
            // 
            cboLoaiSanPham.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoaiSanPham.FormattingEnabled = true;
            cboLoaiSanPham.Location = new Point(31, 142);
            cboLoaiSanPham.Name = "cboLoaiSanPham";
            cboLoaiSanPham.Size = new Size(355, 25);
            cboLoaiSanPham.TabIndex = 3;
            // 
            // lblLoaiSanPham
            // 
            lblLoaiSanPham.AutoSize = true;
            lblLoaiSanPham.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblLoaiSanPham.ForeColor = Color.FromArgb(51, 65, 85);
            lblLoaiSanPham.Location = new Point(31, 115);
            lblLoaiSanPham.Name = "lblLoaiSanPham";
            lblLoaiSanPham.Size = new Size(130, 19);
            lblLoaiSanPham.TabIndex = 2;
            lblLoaiSanPham.Text = "Loại sản phẩm";
            // 
            // lblThongBao
            // 
            lblThongBao.AutoSize = true;
            lblThongBao.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblThongBao.ForeColor = Color.FromArgb(13, 148, 136);
            lblThongBao.Location = new Point(31, 593);
            lblThongBao.MaximumSize = new Size(355, 0);
            lblThongBao.Name = "lblThongBao";
            lblThongBao.Size = new Size(159, 19);
            lblThongBao.TabIndex = 17;
            lblThongBao.Text = "Sẵn sàng thao tác dữ liệu.";
            // 
            // btnDong
            // 
            btnDong.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnDong.FlatStyle = FlatStyle.Flat;
            btnDong.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnDong.ForeColor = Color.FromArgb(51, 65, 85);
            btnDong.Location = new Point(204, 530);
            btnDong.Name = "btnDong";
            btnDong.Size = new Size(150, 42);
            btnDong.TabIndex = 16;
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
            btnLamMoi.Location = new Point(31, 530);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(150, 42);
            btnLamMoi.TabIndex = 15;
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
            btnXoa.Location = new Point(298, 472);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(88, 42);
            btnXoa.TabIndex = 14;
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
            btnSua.Location = new Point(164, 472);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(88, 42);
            btnSua.TabIndex = 13;
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
            btnThem.Location = new Point(31, 472);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(88, 42);
            btnThem.TabIndex = 12;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // txtTenSP
            // 
            txtTenSP.BorderStyle = BorderStyle.FixedSingle;
            txtTenSP.Location = new Point(31, 71);
            txtTenSP.Name = "txtTenSP";
            txtTenSP.PlaceholderText = "Nhập tên sản phẩm";
            txtTenSP.Size = new Size(355, 25);
            txtTenSP.TabIndex = 1;
            // 
            // lblTenSP
            // 
            lblTenSP.AutoSize = true;
            lblTenSP.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblTenSP.ForeColor = Color.FromArgb(51, 65, 85);
            lblTenSP.Location = new Point(31, 44);
            lblTenSP.Name = "lblTenSP";
            lblTenSP.Size = new Size(96, 19);
            lblTenSP.TabIndex = 0;
            lblTenSP.Text = "Tên sản phẩm";
            // 
            // txtMaSP
            // 
            txtMaSP.BackColor = Color.FromArgb(248, 250, 252);
            txtMaSP.BorderStyle = BorderStyle.FixedSingle;
            txtMaSP.Location = new Point(272, 13);
            txtMaSP.Name = "txtMaSP";
            txtMaSP.ReadOnly = true;
            txtMaSP.Size = new Size(114, 25);
            txtMaSP.TabIndex = 19;
            // 
            // lblMaSP
            // 
            lblMaSP.AutoSize = true;
            lblMaSP.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblMaSP.ForeColor = Color.FromArgb(51, 65, 85);
            lblMaSP.Location = new Point(31, 15);
            lblMaSP.Name = "lblMaSP";
            lblMaSP.Size = new Size(47, 19);
            lblMaSP.TabIndex = 18;
            lblMaSP.Text = "Mã SP";
            // 
            // dgvSanPham
            // 
            dgvSanPham.AllowUserToAddRows = false;
            dgvSanPham.AllowUserToDeleteRows = false;
            dgvSanPham.BackgroundColor = Color.White;
            dgvSanPham.BorderStyle = BorderStyle.None;
            dgvSanPham.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSanPham.Dock = DockStyle.Fill;
            dgvSanPham.Location = new Point(430, 110);
            dgvSanPham.MultiSelect = false;
            dgvSanPham.Name = "dgvSanPham";
            dgvSanPham.ReadOnly = true;
            dgvSanPham.RowHeadersVisible = false;
            dgvSanPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSanPham.Size = new Size(930, 670);
            dgvSanPham.TabIndex = 2;
            dgvSanPham.SelectionChanged += dgvSanPham_SelectionChanged;
            // 
            // frmSanPham
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 245, 249);
            ClientSize = new Size(1360, 780);
            Controls.Add(dgvSanPham);
            Controls.Add(panelEditor);
            Controls.Add(panelTop);
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmSanPham";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Quản lý sản phẩm";
            Load += frmSanPham_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelEditor.ResumeLayout(false);
            panelEditor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudSoLuong).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudDonGia).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Button btnTimKiem;
        private TextBox txtTimKiem;
        private Label lblTimKiem;
        private Label lblTieuDe;
        private Panel panelEditor;
        private TextBox txtMoTa;
        private Label lblMoTa;
        private NumericUpDown nudSoLuong;
        private Label lblSoLuong;
        private NumericUpDown nudDonGia;
        private Label lblDonGia;
        private ComboBox cboNhaCungCap;
        private Label lblNhaCungCap;
        private ComboBox cboLoaiSanPham;
        private Label lblLoaiSanPham;
        private Label lblThongBao;
        private Button btnDong;
        private Button btnLamMoi;
        private Button btnXoa;
        private Button btnSua;
        private Button btnThem;
        private TextBox txtTenSP;
        private Label lblTenSP;
        private TextBox txtMaSP;
        private Label lblMaSP;
        private DataGridView dgvSanPham;
    }
}
