using DAOs.Common;
using DAOs.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruyXuatDB.Entities;

namespace DAOs.DAO
{
    public class SF_SanPhamDAO : DBConnection
    {
        public Int64 getTongSanPham()
        {
            Int64 result = 0;

            using (SqlCommand cmd = new SqlCommand())
            {
                openConnection();

                cmd.CommandText = @"SELECT COUNT([MASANPHAM])
                                      FROM [SF_SANPHAM]
                                    WHERE YEAR([NGAYTAO]) >= YEAR(GETDATE())";

                cmd.Connection = conn;
                cmd.Transaction = transaction;
                cmd.CommandType = CommandType.Text;

                try
                {
                    result = Convert.ToInt64(cmd.ExecuteScalar());

                    return result;
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

            return result;
        }

        //public Hashtable xoaDanhMuc(Request_Xoa_DanhMucDTO param)
        //{
        //    Hashtable result = new Hashtable();
        //    result.Add(AppConstraints.SUCCESS, String.Empty);
        //    result.Add(AppConstraints.WARNING, String.Empty);
        //    result.Add(AppConstraints.ERROR, String.Empty);

        //    using (SqlCommand cmd = new SqlCommand())
        //    {
        //        try
        //        {
        //            openConnection();

        //            SqlCommand cmdDate = new SqlCommand(" SET DATEFORMAT dmy", conn, transaction);
        //            cmdDate.ExecuteNonQuery();

        //            cmd.CommandText = @"DELETE FROM DanhMuc
        //                                WHERE DanhMucGuid = @DanhMucGuid";

        //            cmd.Parameters.Add("@DanhMucGuid", SqlDbType.UniqueIdentifier).Value = param.DanhMucGuid;

        //            cmd.Connection = conn;
        //            cmd.Transaction = transaction;
        //            cmd.CommandType = CommandType.Text;

        //            int check = cmd.ExecuteNonQuery();

        //            if (check > 0)
        //            {
        //                result[AppConstraints.SUCCESS] = AppConstraints.SUCCESS_DELETE_MESSAGE;
        //                return result;
        //            }
        //            else
        //            {
        //                result[AppConstraints.WARNING] = AppConstraints.WARNING_MESSAGE;
        //                return result;
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            errorTransaction();
        //            result[AppConstraints.ERROR] = AppConstraints.ERROR_MESSAGE + ex;
        //            return result;
        //        }
        //        finally
        //        {
        //            closeConnection();
        //        }
        //    }
        //}


        //public Hashtable themDanhMuc(Request_Them_DanhMucDTO param)
        //{
        //    Hashtable result = new Hashtable();
        //    result.Add(AppConstraints.SUCCESS, String.Empty);
        //    result.Add(AppConstraints.WARNING, String.Empty);
        //    result.Add(AppConstraints.ERROR, String.Empty);

        //    using (SqlCommand cmd = new SqlCommand())
        //    {
        //        try
        //        {
        //            openConnection();

        //            SqlCommand cmdDate = new SqlCommand(" SET DATEFORMAT dmy", conn, transaction);
        //            cmdDate.ExecuteNonQuery();

        //            cmd.CommandText = @"INSERT INTO [DanhMuc]
        //                               ([DanhMucGuid]
        //                               ,[DanhMucName]
        //                               ,[TrangThai])
        //                         VALUES
        //                               (NEWID()
        //                               ,@DanhMucName
        //                               ,1)";

        //            cmd.Parameters.Add("@DanhMucName", SqlDbType.NVarChar).Value = param.DanhMucName;

        //            cmd.Connection = conn;
        //            cmd.Transaction = transaction;
        //            cmd.CommandType = CommandType.Text;

        //            int check = cmd.ExecuteNonQuery();

        //            if (check > 0)
        //            {
        //                result[AppConstraints.SUCCESS] = AppConstraints.SUCCESS_DELETE_MESSAGE;
        //                return result;
        //            }
        //            else
        //            {
        //                result[AppConstraints.WARNING] = AppConstraints.WARNING_MESSAGE;
        //                return result;
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            errorTransaction();
        //            result[AppConstraints.ERROR] = AppConstraints.ERROR_MESSAGE + ex;
        //            return result;
        //        }
        //        finally
        //        {
        //            closeConnection();
        //        }
        //    }
        //}
    }
}
