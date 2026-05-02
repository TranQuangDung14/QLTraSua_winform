using QuanLyBanHang.DAL;
using QuanLyBanHang.DTO;

namespace QuanLyBanHang.BUS
{
    internal class LoaiSanPhamBUS
    {
        private readonly LoaiSanPhamDAL _loaiSanPhamDal = new();

        internal Task<List<LoaiSanPhamDTO>> GetDanhSachAsync(string tuKhoa = "")
        {
            return _loaiSanPhamDal.GetDanhSachAsync(tuKhoa.Trim());
        }

        internal Task ThemAsync(string tenLoai)
        {
            if (string.IsNullOrWhiteSpace(tenLoai))
            {
                throw new ArgumentException("Vui lòng nhập tên loại sản phẩm.");
            }

            return _loaiSanPhamDal.ThemAsync(new LoaiSanPhamDTO
            {
                TenLoai = tenLoai.Trim()
            });
        }

        internal Task CapNhatAsync(int maLoai, string tenLoai)
        {
            if (maLoai <= 0)
            {
                throw new ArgumentException("Vui lòng chọn loại sản phẩm cần cập nhật.");
            }

            if (string.IsNullOrWhiteSpace(tenLoai))
            {
                throw new ArgumentException("Vui lòng nhập tên loại sản phẩm.");
            }

            return _loaiSanPhamDal.CapNhatAsync(new LoaiSanPhamDTO
            {
                MaLoai = maLoai,
                TenLoai = tenLoai.Trim()
            });
        }

        internal Task XoaAsync(int maLoai)
        {
            if (maLoai <= 0)
            {
                throw new ArgumentException("Vui lòng chọn loại sản phẩm cần xóa.");
            }

            return _loaiSanPhamDal.XoaAsync(maLoai);
        }
    }
}
