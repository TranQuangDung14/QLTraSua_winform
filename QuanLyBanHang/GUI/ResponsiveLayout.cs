namespace QuanLyBanHang.GUI
{
    internal static class ResponsiveLayout
    {
        public static void Configure(Form form)
        {
            form.FormBorderStyle = FormBorderStyle.Sizable;
            form.MaximizeBox = true;
            form.MinimumSize = GetMinimumSize(form);

            ConfigureIdentityTextBoxes(form);
            AnchorEditorInputs(form);
            AnchorSearchBar(form);
            AnchorMainDashboard(form);
            AnchorHoaDon(form);
            AnchorChiTietHoaDon(form);
            AnchorThongKe(form);
            AnchorDangNhap(form);
        }

        private static Size GetMinimumSize(Form form)
        {
            return form.Name switch
            {
                "frmHoaDon" => new Size(1180, 680),
                "frmChiTietHoaDon" => new Size(1000, 620),
                "frmNhanVien" => new Size(1120, 700),
                "frmSanPham" => new Size(1080, 680),
                "frmTrangChu" => new Size(980, 620),
                "frmDangNhap" => new Size(760, 560),
                _ => new Size(900, 600)
            };
        }

        private static void AnchorSearchBar(Form form)
        {
            SetAnchor(form, "btnTimKiem", AnchorStyles.Top | AnchorStyles.Right);
            SetAnchor(form, "txtTimKiem", AnchorStyles.Top | AnchorStyles.Right);
            SetAnchor(form, "lblTimKiem", AnchorStyles.Top | AnchorStyles.Right);
        }

        private static void ConfigureIdentityTextBoxes(Control parent)
        {
            foreach (Control child in parent.Controls)
            {
                if (child is TextBox textBox && IsIdentityTextBoxName(textBox.Name))
                {
                    textBox.ReadOnly = true;
                    textBox.TabStop = false;
                    textBox.BackColor = Color.FromArgb(248, 250, 252);
                }

                ConfigureIdentityTextBoxes(child);
            }
        }

        private static bool IsIdentityTextBoxName(string name)
        {
            return name.StartsWith("txtMa", StringComparison.Ordinal)
                && name.Length > 5
                && char.IsUpper(name[5]);
        }

        private static void AnchorEditorInputs(Form form)
        {
            foreach (Control control in form.Controls)
            {
                AnchorEditorInputs(control);
            }
        }

        private static void AnchorEditorInputs(Control parent)
        {
            foreach (Control child in parent.Controls)
            {
                if (child is TextBox or ComboBox or NumericUpDown or DateTimePicker)
                {
                    child.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                }

                if (child is Label label)
                {
                    label.MaximumSize = new Size(Math.Max(label.MaximumSize.Width, 0), label.MaximumSize.Height);
                }

                AnchorEditorInputs(child);
            }
        }

        private static void AnchorMainDashboard(Form form)
        {
            if (form.Name != "frmTrangChu")
            {
                return;
            }

            SetAnchor(form, "btnDangXuat", AnchorStyles.Top | AnchorStyles.Right);
            SetAnchor(form, "panelWelcome", AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            SetAnchor(form, "panelWorkflow", AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            SetAnchor(form, "labelWelcomeNote", AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            SetAnchor(form, "labelWorkflowText", AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
        }

        private static void AnchorHoaDon(Form form)
        {
            if (form.Name != "frmHoaDon")
            {
                return;
            }

            SetAnchor(form, "grpLapHoaDon", AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left);
            SetAnchor(form, "grpLichSuHoaDon", AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            SetAnchor(form, "dgvChiTietTao", AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            SetAnchor(form, "grpThemSanPham", AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            SetAnchor(form, "cboNhanVien", AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            SetAnchor(form, "cboSanPham", AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            SetAnchor(form, "btnThemSanPham", AnchorStyles.Top | AnchorStyles.Right);
            SetAnchor(form, "lblTongTien", AnchorStyles.Bottom | AnchorStyles.Right);
            SetAnchor(form, "labelTongTien", AnchorStyles.Bottom | AnchorStyles.Left);
            SetAnchor(form, "btnBoSanPham", AnchorStyles.Bottom | AnchorStyles.Right);
            SetAnchor(form, "btnXoaGioHang", AnchorStyles.Bottom | AnchorStyles.Right);
            SetAnchor(form, "btnLuuHoaDon", AnchorStyles.Bottom | AnchorStyles.Right);
            SetAnchor(form, "btnDong", AnchorStyles.Bottom | AnchorStyles.Right);
            SetAnchor(form, "lblThongBao", AnchorStyles.Bottom | AnchorStyles.Left);
            SetAnchor(form, "dgvHoaDon", AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            SetAnchor(form, "dgvChiTietLichSu", AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            SetAnchor(form, "lblThongTinHoaDon", AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            SetAnchor(form, "txtTimKiem", AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            SetAnchor(form, "btnTimKiem", AnchorStyles.Top | AnchorStyles.Right);
            SetAnchor(form, "btnXoaHoaDon", AnchorStyles.Top | AnchorStyles.Right);
        }

        private static void AnchorChiTietHoaDon(Form form)
        {
            if (form.Name != "frmChiTietHoaDon")
            {
                return;
            }

            SetAnchor(form, "grpThongTin", AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left);
            SetAnchor(form, "grpDanhSach", AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            SetAnchor(form, "dgvChiTietHoaDon", AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            SetAnchor(form, "txtTimKiem", AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            SetAnchor(form, "btnTimKiem", AnchorStyles.Top | AnchorStyles.Right);
            SetAnchor(form, "btnLamMoi", AnchorStyles.Bottom | AnchorStyles.Right);
            SetAnchor(form, "btnXoa", AnchorStyles.Bottom | AnchorStyles.Right);
            SetAnchor(form, "btnDong", AnchorStyles.Bottom | AnchorStyles.Right);
            SetAnchor(form, "lblThongBao", AnchorStyles.Bottom | AnchorStyles.Left);
        }

        private static void AnchorThongKe(Form form)
        {
            if (form.Name != "frmThongKeDoanhThu")
            {
                return;
            }

            SetAnchor(form, "panelBoLoc", AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            SetAnchor(form, "btnThongKe", AnchorStyles.Top | AnchorStyles.Right);
            SetAnchor(form, "btnDong", AnchorStyles.Top | AnchorStyles.Right);
            SetAnchor(form, "panelTongHop", AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            SetAnchor(form, "dgvThongKe", AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            SetAnchor(form, "lblThongBao", AnchorStyles.Bottom | AnchorStyles.Left);

            form.Resize += (_, _) => ResizeThongKeCards(form);
            ResizeThongKeCards(form);
        }

        private static void ResizeThongKeCards(Form form)
        {
            var panelTongHop = Find(form, "panelTongHop");
            var cardSoHoaDon = Find(form, "cardSoHoaDon");
            var cardTongTien = Find(form, "cardTongTien");
            var cardTrungBinh = Find(form, "cardTrungBinh");

            if (panelTongHop == null || cardSoHoaDon == null || cardTongTien == null || cardTrungBinh == null)
            {
                return;
            }

            const int gap = 33;
            const int left = 26;
            var width = Math.Max(180, (panelTongHop.ClientSize.Width - (left * 2) - (gap * 2)) / 3);

            cardSoHoaDon.SetBounds(left, 10, width, cardSoHoaDon.Height);
            cardTongTien.SetBounds(left + width + gap, 10, width, cardTongTien.Height);
            cardTrungBinh.SetBounds(left + (width + gap) * 2, 10, width, cardTrungBinh.Height);
        }

        private static void AnchorDangNhap(Form form)
        {
            if (form.Name != "frmDangNhap")
            {
                return;
            }

            SetAnchor(form, "txtTenDangNhap", AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            SetAnchor(form, "txtMatKhau", AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            SetAnchor(form, "cboQuyen", AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            SetAnchor(form, "lblThongBao", AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
        }

        private static void SetAnchor(Control root, string name, AnchorStyles anchor)
        {
            var control = Find(root, name);
            if (control != null)
            {
                control.Anchor = anchor;
            }
        }

        private static Control? Find(Control root, string name)
        {
            if (root.Name == name)
            {
                return root;
            }

            var matches = root.Controls.Find(name, true);
            return matches.Length > 0 ? matches[0] : null;
        }
    }
}
