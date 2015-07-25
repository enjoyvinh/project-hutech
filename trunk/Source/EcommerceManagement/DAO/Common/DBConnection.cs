using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.IO;

/*
 *  
 *  Filename:   DBConnection.cs
 *  Author:     Vinh Nguyễn - 1216061133
 *  Class:      12LDTHC2
 *  Version:    1.0
 *  Copyright @ 2015 HUTECH
 * 
 */

namespace DAOs
{
    public abstract class DBConnection
    {
        public SqlDataAdapter myAdapter;

        public SqlConnection conn;

        public SqlTransaction transaction;

        /// <constructor>
        /// Khởi tạo kết nối với Database Server
        /// </constructor>
        public DBConnection()
        {
            myAdapter = new SqlDataAdapter();
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
            
            //conn = new SqlConnection(@"Server=.;Database=NewsDatabase;User ID=sa;Password=123@abc");

            //conn = new SqlConnection(@"Server=1306VN073\SQLEXPRESS;
            //                                      Database=restaurantdatabase;
            //                                      User Id=sa;
            //                                      Password=Vinh.Nguyen@23.03/90!;");
        }

        /// <method>
        /// Open Database Connection if Closed or Broken
        /// </method>
        public void openConnection()
        {
            if (conn.State == ConnectionState.Closed || conn.State == ConnectionState.Broken)
            {
                conn.Close();
                conn.Open();
                transaction = conn.BeginTransaction();
            }
        }

        public void errorTransaction(Exception ex = null)
        {
            transaction.Rollback();
            conn.Close();
            throw new Exception();
        }

        /// <method>
        /// Close Database Connection if Open
        /// </method>
        public void closeConnection() // database connection close
        {
            transaction.Commit();
            conn.Close();
        }

        protected void ExecuteSQL(string sSQL)
        {
            SqlCommand cmdDate = new SqlCommand(" SET DATEFORMAT dmy", conn, transaction);
            cmdDate.ExecuteNonQuery();
            SqlCommand cmd = new SqlCommand(sSQL, conn, transaction);
            cmd.ExecuteNonQuery();
        }

        protected void OnlyExecuteSQL(string sSQL)
        {
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            cmd.ExecuteNonQuery();
        }

        protected DataSet FillData(string sSQL, string sTable)
        {
            SqlCommand cmd = new SqlCommand(sSQL, conn, transaction);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds, sTable);
            return ds;
        }

        protected SqlDataReader setDataReader(string sSQL)
        {
            SqlCommand cmd = new SqlCommand(sSQL, conn, transaction);
            cmd.CommandTimeout = 300;
            SqlDataReader rtnReader;
            rtnReader = cmd.ExecuteReader();
            return rtnReader;
        }

        public static void Log(string logMessage, TextWriter w)
        {
            w.Write("\r\nLog Entry : ");
            w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                DateTime.Now.ToLongDateString());
            w.WriteLine("  :");
            w.WriteLine("  :{0}", logMessage);
            w.WriteLine("-------------------------------");
        }

        public static void DumpLog(StreamReader r)
        {
            string line;
            while ((line = r.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }
    }
}
