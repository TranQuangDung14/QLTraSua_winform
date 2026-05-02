using QuanLyBanHang.DAL;
using QuanLyBanHang.DTO;

namespace QuanLyBanHang.BUS
{
    internal class SanPhamBUS
    {
        private readonly SanPhamDAL _sanPhamDal = new();

        internal Task<List<SanPhamDTO>> GetDanhSachAsync(string tuKhoa = "")
        {
            return _sanPhamDal.GetDanhSachAsync(tuKhoa.Trim());
        }

        internal Task ThemAsync(string tenSP, int maLoai, int maNCC, decimal donGia, int soLuong, string moTa)
        {
            KiemTraHopLe(tenSP, maLoai, maNCC, donGia, soLuong);

            return _sanPhamDal.ThemAsync(new SanPhamDTO
            {
                TenSP = tenSP.Trim(),
                MaLoai = maLoai,
                MaNCC = maNCC,
                DonGia = donGia,
                SoLuong = soLuong,
                MoTa = moTa.Trim()
            });
        }

        internal Task CapNhatAsync(int maSP, string tenSP, int maLoai, int maNCC, decimal donGia, int soLuong, string moTa)
        {
            if (maSP <= 0)
            {
                throw new ArgumentException("Vui lòng chọn sản phẩm cần cập nhật.");
            }

            KiemTraHopLe(tenSP, maLoai, maNCC, donGia, soLuong);

            return _sanPhamDal.CapNhatAsync(new SanPhamDTO
            {
                MaSP = maSP,
                TenSP = tenSP.Trim(),
                MaLoai = maLoai,
                MaNCC = maNCC,
                DonGia = donGia,
                SoLuong = soLuong,
                MoTa = moTa.Trim()
            });
        }

        internal Task XoaAsync(int maSP)
        {
            if (maSP <= 0)
            {
                throw new ArgumentException("Vui lòng chọn sản phẩm cần xóa.");
            }

            return _sanPhamDal.XoaAsync(maSP);
        }

        private static void KiemTraHopLe(string tenSP, int maLoai, int maNCC, decimal donGia, int soLuong)
        {
            if (string.IsNullOrWhiteSpace(tenSP))
            {
                throw new ArgumentException("Vui lòng nhập tên sản phẩm.");
            }

            if (maLoai <= 0)
            {
                throw new ArgumentException("Vui lòng chọn loại sản phẩm.");
            }

            if (maNCC <= 0)
            {
                throw new ArgumentException("Vui lòng chọn nhà cung cấp.");
            }

            if (donGia < 0)
            {
                throw new ArgumentException("Đơn giá không được âm.");
            }

            if (soLuong < 0)
            {
                throw new ArgumentException("Số lượng không được âm.");
            }
        }
    }
}
