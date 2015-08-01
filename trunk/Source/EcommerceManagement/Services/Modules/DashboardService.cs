using DAOs.DAO;
using DAOs.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruyXuatDB.Entities;

namespace Services.Modules
{
    public class DashboardService
    {
        SF_CuaHangDAO cuaHangDAO = new SF_CuaHangDAO();
        SF_SanPhamDAO sanPhamDAO = new SF_SanPhamDAO();
        SF_KhachHangDAO khachHangDAO = new SF_KhachHangDAO();
        SF_DanhGiaSanPhamDAO danhGiaSanPhamDAO = new SF_DanhGiaSanPhamDAO();
        SF_BinhLuanDAO binhLuanDAO = new SF_BinhLuanDAO();
        SF_HoaDonDAO hoaDonDAO = new SF_HoaDonDAO();

        public Int64 getTongCuaHang()
        {
            Int64 tongCuaHang = cuaHangDAO.getTongCuaHang();

            return tongCuaHang;
        }

        public Int64 getTongSanPham()
        {
            Int64 tongSanPham = sanPhamDAO.getTongSanPham();
            return tongSanPham;
        }

        public Int64 getTongKhachHang()
        {
            Int64 tongKhachHang = khachHangDAO.getTongKhachHang() ;
            return tongKhachHang;
        }

        public Int64 getTongDanhGia()
        {
            Int64 tongDanhGia = danhGiaSanPhamDAO.getTongDanhGia() + binhLuanDAO.getTongBinhLuan();
            return tongDanhGia;
        }

        public long getTongHoaDonTheoThang(Int16 thang, Int16 trangThaiHoaDon)
        {
            Int64 tongHoaDonTheoThang = hoaDonDAO.getTongHoaDonTheoThang(thang, trangThaiHoaDon);
            return tongHoaDonTheoThang;
        }

        public Int64 getPhanTramTongGiaTri()
        {
            Int64 result = 100;

            DateTime lastYear = DateTime.Today.AddYears(-1);

            Decimal tongGiaTriNamTruoc = sanPhamDAO.getTongGiaTriSanPhamTheoNam(lastYear.Year);

            Decimal tongGiaTriNamHienTai = sanPhamDAO.getTongGiaTriSanPhamTheoNam(DateTime.Now.Year);

            if(!tongGiaTriNamTruoc.Equals(Decimal.Zero))
            {
                Decimal temp = ((tongGiaTriNamHienTai - tongGiaTriNamTruoc) * 100) / tongGiaTriNamTruoc;

                result = Convert.ToInt64(temp);
            }

            return result;
        }

        public Decimal getTongGiaTri()
        {
            Decimal result = sanPhamDAO.getTongGiaTriSanPhamTheoNam(DateTime.Now.Year);

            return result;
        }

        public Int64 getPhanTramKhoiLuong()
        {
            Int64 result = 100;

            DateTime lastYear = DateTime.Today.AddYears(-1);

            Int64 tongKhoiLuongNamTruoc = hoaDonDAO.getTongHoaDonTheoNam(Convert.ToInt16(lastYear.Year),1);

            Int64 tongKhoiLuongNamHienTai = hoaDonDAO.getTongHoaDonTheoNam(Convert.ToInt16(DateTime.Now.Year),1);

            if (!tongKhoiLuongNamTruoc.Equals(0))
            {
                result = ((tongKhoiLuongNamHienTai - tongKhoiLuongNamTruoc) * 100) / tongKhoiLuongNamTruoc;
            }

            return result;
        }

        public Int64 getTongKhoiLuong()
        {
            Int64 result = hoaDonDAO.getTongHoaDonTheoNam(Convert.ToInt16(DateTime.Now.Year),1);

            return result;
        }

        public Int64 getPhanTramGiaoDich()
        {
            Int64 result = 100;

            DateTime lastYear = DateTime.Today.AddYears(-1);

            Decimal tongKhoiLuongNamTruoc = hoaDonDAO.getTongGiaTriHoaDonTheoNam(Convert.ToInt16(lastYear.Year), 1);

            Decimal tongKhoiLuongNamHienTai = hoaDonDAO.getTongGiaTriHoaDonTheoNam(Convert.ToInt16(DateTime.Now.Year), 1);

            if (!tongKhoiLuongNamTruoc.Equals(0))
            {
                Decimal temp = ((tongKhoiLuongNamHienTai - tongKhoiLuongNamTruoc) * 100) / tongKhoiLuongNamTruoc;

                result = Convert.ToInt64(temp);
            }

            return result;
        }

        public Decimal getTongGiaTriGiaoDich()
        {
            Decimal result = hoaDonDAO.getTongGiaTriHoaDonTheoNam(Convert.ToInt16(DateTime.Now.Year), 1);

            return result;
        }
    }
}
