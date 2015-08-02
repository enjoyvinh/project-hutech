using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DAOs.Common
{
    public class DBConnection2
    {
        public static string Chuoi_Ket_Noi = @"Data Source=WINDOWS\SQLEXPRESS;Initial Catalog=TMDTDB11;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //private static String Chuoi_Ket_Noi = System.Configuration.ConfigurationSettings.AppSettings.con
        public static SqlConnection _SqlConnection;
        public static SqlTransaction transaction;

        #region Kết nối
        public static void errorTransaction(Exception ex)
        {
            //transaction.Rollback();
            _SqlConnection.Close();
        }
        public void closeConnection() // database connection close
        {
            transaction.Commit();
            _SqlConnection.Close();
        }
        public static SqlConnection GetConnection()
        {
            if (_SqlConnection == null)
            {
                _SqlConnection = new SqlConnection(Chuoi_Ket_Noi);

            }
            if (_SqlConnection.State == ConnectionState.Closed)
            {
                _SqlConnection.Open();
                //transaction = _SqlConnection.BeginTransaction();
            }
            return _SqlConnection;
        }

        #endregion

        #region Thực thi truy vấn

        public static int TruyVanScalar(SqlCommand command)
        {
            try
            {
                SqlConnection conn = GetConnection();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                return Convert.ToInt32(command.ExecuteScalar());

            }
            catch (Exception ex)
            {
                errorTransaction(ex);
                return -1;
            }
        }
        public static int TruyVanThemXoaSua(SqlCommand command)
        {
            try
            {
                SqlConnection conn = GetConnection();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;

                int kq = command.ExecuteNonQuery();
                return kq;
            }
            catch (Exception ex)
            {
                errorTransaction(ex);
                return -1;
            }
        }
        public static int TruyVanThemXoaSuaDS(List<SqlCommand> DScommand)
        {
            //transaction = _SqlConnection.BeginTransaction();
            int kq = 0;
            SqlConnection conn = GetConnection();
            transaction = conn.BeginTransaction();
            foreach (SqlCommand cmd in DScommand)
            {
                cmd.Connection = conn;
                cmd.Transaction = transaction;
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    kq = cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    errorTransaction(ex);
                    return -1;
                }
            }
            //conn.Close();
            return kq;
        }
        public static DataTable TruyVanLoadDanhSach(SqlCommand command)
        {
            try
            {
                SqlConnection conn = GetConnection();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader _SqlDataReader = command.ExecuteReader();
                DataTable tbl = new DataTable(); // tạo mới 1 biến tbl có kiểu DataTable
                tbl.Load(_SqlDataReader);
                return tbl;
            }
            catch (Exception ex)
            {
                errorTransaction(ex);
                return null;
            }
        }


        #endregion
    }
}
