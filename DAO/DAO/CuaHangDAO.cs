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
    public class CuaHangDAO
    {
        public DataTable ThongTinCuaHangTheoMaSanPham(string MaSanPham)
        {
            SqlCommand _SqlCommand = new SqlCommand();
            _SqlCommand.CommandText = "sp_ThongTinCuaHangTheoMaSanPham";
            _SqlCommand.Parameters.Add("MaSanPham", MaSanPham);
            return DBConnection2.TruyVanLoadDanhSach(_SqlCommand);
        }
    }
}
