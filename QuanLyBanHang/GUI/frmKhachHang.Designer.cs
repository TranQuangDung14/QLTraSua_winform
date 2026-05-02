namespace QuanLyBanHang.GUI
{
    partial class frmKhachHang
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
            txtDiaChi = new TextBox();
            lblDiaChi = new Label();
            txtSoDienThoai = new TextBox();
            lblSoDienThoai = new Label();
            txtHoTen = new TextBox();
            lblHoTen = new Label();
            txtMaKH = new TextBox();
            lblMaKH = new Label();
            dgvKhachHang = new DataGridView();
            panelTop.SuspendLayout();
            panelEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKhachHang).BeginInit();
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
            txtTimKiem.PlaceholderText = "Nhập tên khách hàng";
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
            lblTieuDe.Size = new Size(208, 45);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "Khách hàng";
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
            panelEditor.Controls.Add(txtDiaChi);
            panelEditor.Controls.Add(lblDiaChi);
            panelEditor.Controls.Add(txtSoDienThoai);
            panelEditor.Controls.Add(lblSoDienThoai);
            panelEditor.Controls.Add(txtHoTen);
            panelEditor.Controls.Add(lblHoTen);
            panelEditor.Controls.Add(txtMaKH);
            panelEditor.Controls.Add(lblMaKH);
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
            lblThongBao.Location = new Point(31, 414);
            lblThongBao.MaximumSize = new Size(330, 0);
            lblThongBao.Name = "lblThongBao";
            lblThongBao.Size = new Size(159, 19);
            lblThongBao.TabIndex = 13;
            lblThongBao.Text = "Sẵn sàng thao tác dữ liệu.";
            // 
            // btnDong
            // 
            btnDong.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnDong.FlatStyle = FlatStyle.Flat;
            btnDong.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnDong.ForeColor = Color.FromArgb(51, 65, 85);
            btnDong.Location = new Point(199, 338);
            btnDong.Name = "btnDong";
            btnDong.Size = new Size(150, 42);
            btnDong.TabIndex = 12;
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
            btnLamMoi.Location = new Point(31, 338);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(150, 42);
            btnLamMoi.TabIndex = 11;
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
            btnXoa.Location = new Point(261, 278);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(88, 42);
            btnXoa.TabIndex = 10;
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
            btnSua.Location = new Point(146, 278);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(88, 42);
            btnSua.TabIndex = 9;
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
            btnThem.Location = new Point(31, 278);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(88, 42);
            btnThem.TabIndex = 8;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // txtDiaChi
            // 
            txtDiaChi.BorderStyle = BorderStyle.FixedSingle;
            txtDiaChi.Location = new Point(31, 205);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.PlaceholderText = "Nhập địa chỉ";
            txtDiaChi.Size = new Size(318, 25);
            txtDiaChi.TabIndex = 7;
            // 
            // lblDiaChi
            // 
            lblDiaChi.AutoSize = true;
            lblDiaChi.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblDiaChi.ForeColor = Color.FromArgb(51, 65, 85);
            lblDiaChi.Location = new Point(31, 178);
            lblDiaChi.Name = "lblDiaChi";
            lblDiaChi.Size = new Size(55, 19);
            lblDiaChi.TabIndex = 6;
            lblDiaChi.Text = "Địa chỉ";
            // 
            // txtSoDienThoai
            // 
            txtSoDienThoai.BorderStyle = BorderStyle.FixedSingle;
            txtSoDienThoai.Location = new Point(31, 132);
            txtSoDienThoai.Name = "txtSoDienThoai";
            txtSoDienThoai.PlaceholderText = "Nhập số điện thoại";
            txtSoDienThoai.Size = new Size(318, 25);
            txtSoDienThoai.TabIndex = 5;
            // 
            // lblSoDienThoai
            // 
            lblSoDienThoai.AutoSize = true;
            lblSoDienThoai.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblSoDienThoai.ForeColor = Color.FromArgb(51, 65, 85);
            lblSoDienThoai.Location = new Point(31, 105);
            lblSoDienThoai.Name = "lblSoDienThoai";
            lblSoDienThoai.Size = new Size(92, 19);
            lblSoDienThoai.TabIndex = 4;
            lblSoDienThoai.Text = "Số điện thoại";
            // 
            // txtHoTen
            // 
            txtHoTen.BorderStyle = BorderStyle.FixedSingle;
            txtHoTen.Location = new Point(31, 58);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.PlaceholderText = "Nhập họ tên khách hàng";
            txtHoTen.Size = new Size(318, 25);
            txtHoTen.TabIndex = 3;
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblHoTen.ForeColor = Color.FromArgb(51, 65, 85);
            lblHoTen.Location = new Point(31, 31);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(123, 19);
            lblHoTen.TabIndex = 2;
            lblHoTen.Text = "Họ tên khách hàng";
            // 
            // txtMaKH
            // 
            txtMaKH.BackColor = Color.FromArgb(248, 250, 252);
            txtMaKH.BorderStyle = BorderStyle.FixedSingle;
            txtMaKH.Location = new Point(235, 3);
            txtMaKH.Name = "txtMaKH";
            txtMaKH.ReadOnly = true;
            txtMaKH.Size = new Size(114, 25);
            txtMaKH.TabIndex = 1;
            // 
            // lblMaKH
            // 
            lblMaKH.AutoSize = true;
            lblMaKH.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblMaKH.ForeColor = Color.FromArgb(51, 65, 85);
            lblMaKH.Location = new Point(31, 5);
            lblMaKH.Name = "lblMaKH";
            lblMaKH.Size = new Size(49, 19);
            lblMaKH.TabIndex = 0;
            lblMaKH.Text = "Mã KH";
            // 
            // dgvKhachHang
            // 
            dgvKhachHang.AllowUserToAddRows = false;
            dgvKhachHang.AllowUserToDeleteRows = false;
            dgvKhachHang.BackgroundColor = Color.White;
            dgvKhachHang.BorderStyle = BorderStyle.None;
            dgvKhachHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKhachHang.Dock = DockStyle.Fill;
            dgvKhachHang.Location = new Point(400, 110);
            dgvKhachHang.MultiSelect = false;
            dgvKhachHang.Name = "dgvKhachHang";
            dgvKhachHang.ReadOnly = true;
            dgvKhachHang.RowHeadersVisible = false;
            dgvKhachHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKhachHang.Size = new Size(820, 610);
            dgvKhachHang.TabIndex = 2;
            dgvKhachHang.SelectionChanged += dgvKhachHang_SelectionChanged;
            // 
            // frmKhachHang
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 245, 249);
            ClientSize = new Size(1220, 720);
            Controls.Add(dgvKhachHang);
            Controls.Add(panelEditor);
            Controls.Add(panelTop);
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmKhachHang";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Quản lý khách hàng";
            Load += frmKhachHang_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelEditor.ResumeLayout(false);
            panelEditor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKhachHang).EndInit();
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
        private TextBox txtDiaChi;
        private Label lblDiaChi;
        private TextBox txtSoDienThoai;
        private Label lblSoDienThoai;
        private TextBox txtHoTen;
        private Label lblHoTen;
        private TextBox txtMaKH;
        private Label lblMaKH;
        private DataGridView dgvKhachHang;
    }
}
