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
    public class ChuyenMucDAO
    {
        public DataTable DSChuyenMucLv1()
        {
            SqlCommand _SqlCommand = new SqlCommand();
            _SqlCommand.CommandText = "sp_DSChuyenMucLv1";
            return DBConnection2.TruyVanLoadDanhSach(_SqlCommand);
        }
        public DataTable DSChuyenMucCon(string MaChuyenMuc)
        {
            SqlCommand _SqlCommand = new SqlCommand();
            _SqlCommand.CommandText = "sp_DSChuyenMucCon";
            _SqlCommand.Parameters.Add("MaChuyenMuc", MaChuyenMuc);
            return DBConnection2.TruyVanLoadDanhSach(_SqlCommand);
        }
        public DataTable DSChuyenMucTheoId(string MaChuyenMuc)
        {
            SqlCommand _SqlCommand = new SqlCommand();
            _SqlCommand.CommandText = "sp_DSChuyenMucTheoId";
            _SqlCommand.Parameters.Add("MaChuyenMuc", MaChuyenMuc);
            return DBConnection2.TruyVanLoadDanhSach(_SqlCommand);
        }
        public DataTable DSChuyenMucChaTheoTen(string TenChuyenMuc)
        {
            SqlCommand _SqlCommand = new SqlCommand();
            _SqlCommand.CommandText = "sp_DSChuyenMucChaTheoTen";
            _SqlCommand.Parameters.Add("TenChuyenMuc", TenChuyenMuc);
            return DBConnection2.TruyVanLoadDanhSach(_SqlCommand);
        }
        public DataTable SanPhamGiamGiaTheoMaChuyenMuc(string MaChuyenMuc)
        {
            SqlCommand _SqlCommand = new SqlCommand();
            _SqlCommand.CommandText = "sp_SanPhamGiamGiaTheoMaChuyenMuc";
            _SqlCommand.Parameters.Add("MaChuyenMuc", MaChuyenMuc);
            return DBConnection2.TruyVanLoadDanhSach(_SqlCommand);
        }
        public DataTable SanPhamBanChayTheoMaChuyenMuc(string MaChuyenMuc)
        {
            SqlCommand _SqlCommand = new SqlCommand();
            _SqlCommand.CommandText = "sp_SanPhamBanChayTheoMaChuyenMuc";
            _SqlCommand.Parameters.Add("MaChuyenMuc", MaChuyenMuc);
            return DBConnection2.TruyVanLoadDanhSach(_SqlCommand);
        }
    }
}
