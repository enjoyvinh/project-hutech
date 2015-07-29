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
    }
}
