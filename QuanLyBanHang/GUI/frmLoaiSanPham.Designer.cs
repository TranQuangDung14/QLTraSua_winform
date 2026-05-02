namespace QuanLyBanHang.GUI
{
    partial class frmLoaiSanPham
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
            txtTenLoai = new TextBox();
            lblTenLoai = new Label();
            txtMaLoai = new TextBox();
            lblMaLoai = new Label();
            dgvLoaiSanPham = new DataGridView();
            panelTop.SuspendLayout();
            panelEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLoaiSanPham).BeginInit();
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
            panelTop.Size = new Size(1080, 110);
            panelTop.TabIndex = 0;
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = Color.FromArgb(15, 118, 110);
            btnTimKiem.FlatAppearance.BorderSize = 0;
            btnTimKiem.FlatStyle = FlatStyle.Flat;
            btnTimKiem.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnTimKiem.ForeColor = Color.White;
            btnTimKiem.Location = new Point(922, 48);
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
            txtTimKiem.Location = new Point(640, 54);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Nhập tên loại sản phẩm";
            txtTimKiem.Size = new Size(264, 25);
            txtTimKiem.TabIndex = 2;
            // 
            // lblTimKiem
            // 
            lblTimKiem.AutoSize = true;
            lblTimKiem.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblTimKiem.ForeColor = Color.FromArgb(51, 65, 85);
            lblTimKiem.Location = new Point(640, 29);
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
            lblTieuDe.Size = new Size(257, 45);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "Loại sản phẩm";
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
            panelEditor.Controls.Add(txtTenLoai);
            panelEditor.Controls.Add(lblTenLoai);
            panelEditor.Controls.Add(txtMaLoai);
            panelEditor.Controls.Add(lblMaLoai);
            panelEditor.Dock = DockStyle.Left;
            panelEditor.Location = new Point(0, 110);
            panelEditor.Name = "panelEditor";
            panelEditor.Padding = new Padding(28);
            panelEditor.Size = new Size(360, 570);
            panelEditor.TabIndex = 1;
            // 
            // lblThongBao
            // 
            lblThongBao.AutoSize = true;
            lblThongBao.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblThongBao.ForeColor = Color.FromArgb(13, 148, 136);
            lblThongBao.Location = new Point(31, 395);
            lblThongBao.MaximumSize = new Size(290, 0);
            lblThongBao.Name = "lblThongBao";
            lblThongBao.Size = new Size(159, 19);
            lblThongBao.TabIndex = 9;
            lblThongBao.Text = "Sẵn sàng thao tác dữ liệu.";
            // 
            // btnDong
            // 
            btnDong.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnDong.FlatStyle = FlatStyle.Flat;
            btnDong.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnDong.ForeColor = Color.FromArgb(51, 65, 85);
            btnDong.Location = new Point(173, 318);
            btnDong.Name = "btnDong";
            btnDong.Size = new Size(128, 42);
            btnDong.TabIndex = 8;
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
            btnLamMoi.Location = new Point(31, 318);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(128, 42);
            btnLamMoi.TabIndex = 7;
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
            btnXoa.Location = new Point(244, 255);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(88, 42);
            btnXoa.TabIndex = 6;
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
            btnSua.Location = new Point(138, 255);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(88, 42);
            btnSua.TabIndex = 5;
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
            btnThem.Location = new Point(31, 255);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(88, 42);
            btnThem.TabIndex = 4;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // txtTenLoai
            // 
            txtTenLoai.BorderStyle = BorderStyle.FixedSingle;
            txtTenLoai.Location = new Point(31, 166);
            txtTenLoai.Name = "txtTenLoai";
            txtTenLoai.PlaceholderText = "Nhập tên loại sản phẩm";
            txtTenLoai.Size = new Size(301, 25);
            txtTenLoai.TabIndex = 3;
            // 
            // lblTenLoai
            // 
            lblTenLoai.AutoSize = true;
            lblTenLoai.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblTenLoai.ForeColor = Color.FromArgb(51, 65, 85);
            lblTenLoai.Location = new Point(31, 139);
            lblTenLoai.Name = "lblTenLoai";
            lblTenLoai.Size = new Size(145, 19);
            lblTenLoai.TabIndex = 2;
            lblTenLoai.Text = "Tên loại sản phẩm";
            // 
            // txtMaLoai
            // 
            txtMaLoai.BackColor = Color.FromArgb(248, 250, 252);
            txtMaLoai.BorderStyle = BorderStyle.FixedSingle;
            txtMaLoai.Location = new Point(31, 90);
            txtMaLoai.Name = "txtMaLoai";
            txtMaLoai.ReadOnly = true;
            txtMaLoai.Size = new Size(301, 25);
            txtMaLoai.TabIndex = 1;
            // 
            // lblMaLoai
            // 
            lblMaLoai.AutoSize = true;
            lblMaLoai.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblMaLoai.ForeColor = Color.FromArgb(51, 65, 85);
            lblMaLoai.Location = new Point(31, 63);
            lblMaLoai.Name = "lblMaLoai";
            lblMaLoai.Size = new Size(56, 19);
            lblMaLoai.TabIndex = 0;
            lblMaLoai.Text = "Mã loại";
            // 
            // dgvLoaiSanPham
            // 
            dgvLoaiSanPham.AllowUserToAddRows = false;
            dgvLoaiSanPham.AllowUserToDeleteRows = false;
            dgvLoaiSanPham.BackgroundColor = Color.White;
            dgvLoaiSanPham.BorderStyle = BorderStyle.None;
            dgvLoaiSanPham.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLoaiSanPham.Dock = DockStyle.Fill;
            dgvLoaiSanPham.Location = new Point(360, 110);
            dgvLoaiSanPham.MultiSelect = false;
            dgvLoaiSanPham.Name = "dgvLoaiSanPham";
            dgvLoaiSanPham.ReadOnly = true;
            dgvLoaiSanPham.RowHeadersVisible = false;
            dgvLoaiSanPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLoaiSanPham.Size = new Size(720, 570);
            dgvLoaiSanPham.TabIndex = 2;
            dgvLoaiSanPham.SelectionChanged += dgvLoaiSanPham_SelectionChanged;
            // 
            // frmLoaiSanPham
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 245, 249);
            ClientSize = new Size(1080, 680);
            Controls.Add(dgvLoaiSanPham);
            Controls.Add(panelEditor);
            Controls.Add(panelTop);
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmLoaiSanPham";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Quản lý loại sản phẩm";
            Load += frmLoaiSanPham_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelEditor.ResumeLayout(false);
            panelEditor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLoaiSanPham).EndInit();
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
        private TextBox txtTenLoai;
        private Label lblTenLoai;
        private TextBox txtMaLoai;
        private Label lblMaLoai;
        private DataGridView dgvLoaiSanPham;
    }
}
