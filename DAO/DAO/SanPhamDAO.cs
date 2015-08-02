using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAOs.Entities;
using DAOs.Common;
using System.Data.SqlClient;
using System.Data;
namespace DAOs.DAO
{
    public class SanPhamDAO : DBConnection2
    {
        public DataTable HinhAnhTheoMaSanPham(string MaSanPham)
        {
            SqlCommand _SqlCommand = new SqlCommand();
            _SqlCommand.CommandText = "sp_HinhAnhTheoMaSanPham";
            _SqlCommand.Parameters.Add("MaSanPham", MaSanPham);
            return DBConnection2.TruyVanLoadDanhSach(_SqlCommand);
        }
        public DataTable ChiTietSanPhamTheoMaSanPham(string MaSanPham)
        {
            SqlCommand _SqlCommand = new SqlCommand();
            _SqlCommand.CommandText = "sp_ChiTietSanPhamTheoMaSanPham";
            _SqlCommand.Parameters.Add("MaSanPham", MaSanPham);
            return DBConnection2.TruyVanLoadDanhSach(_SqlCommand);
        }
        public DataTable DSThuocTinhTheoMaSanPham(string MaSanPham)
        {
            SqlCommand _SqlCommand = new SqlCommand();
            _SqlCommand.CommandText = "sp_DSThuocTinhTheoMaSanPham";
            _SqlCommand.Parameters.Add("MaSanPham", MaSanPham);
            return DBConnection2.TruyVanLoadDanhSach(_SqlCommand);
        }
        public DataTable DSChiTietThuocTinhTheoMaSanPhamVaMaThuocTinh(string MaSanPham, string MaThuocTinh)
        {
            SqlCommand _SqlCommand = new SqlCommand();
            _SqlCommand.CommandText = "sp_DSChiTietThuocTinhTheoMaSanPhamVaMaThuocTinh";
            _SqlCommand.Parameters.Add("MaSanPham", MaSanPham);
            _SqlCommand.Parameters.Add("MaThuocTinh", MaThuocTinh);
            return DBConnection2.TruyVanLoadDanhSach(_SqlCommand);
        }
        public DataTable DSChiTietThuocTinhTheoMaSanPhamVaMauSac(string MaSanPham)
        {
            SqlCommand _SqlCommand = new SqlCommand();
            _SqlCommand.CommandText = "sp_DSChiTietThuocTinhTheoMaSanPhamVaMauSac";
            _SqlCommand.Parameters.Add("MaSanPham", MaSanPham);
            return DBConnection2.TruyVanLoadDanhSach(_SqlCommand);
        }
    }
}
