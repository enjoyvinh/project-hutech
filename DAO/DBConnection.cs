using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;

namespace TruyXuatDB
{
    public abstract class DBConnection
    {
        public SqlDataAdapter myAdapter;

        public SqlConnection conn;

        public SqlTransaction transaction;

        /// <constructor>
        /// Initialise Connection
        /// </constructor>
        public DBConnection()
        {
            myAdapter = new SqlDataAdapter();
            conn = new SqlConnection(@"Data Source=.;Initial Catalog=restaurantdatabase;Integrated Security=True");
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

        public void errorTransaction()
        {
            transaction.Rollback();
            conn.Close();
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
    }
}
