using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs.DAO
{
    public class ItemStoreDAO : DBConnection
    {
        public int demDanhSach(Guid guid)
        {
            Int32 count = 0;

            using (SqlCommand cmd = new SqlCommand())
            {
                openConnection();

                cmd.CommandText = @"SELECT COUNT(ItemStoreGuid) FROM ItemStore;";

                cmd.Connection = conn;
                cmd.Transaction = transaction;
                cmd.CommandType = CommandType.Text;

                try
                {
                    count = Convert.ToInt32(cmd.ExecuteScalar());

                    return count;
                }
                catch (Exception ex)
                {
                    errorTransaction(ex);
                }
                finally
                {
                    closeConnection();
                }
            }

            return count;
        }

    }
}
