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
    public class DanhMucDAO : DBConnection
    {
        //public List<View_DanhMucDTO> getDanhSachDanhMuc(Request_TimKiem_DanhMucDTO param)
        //{
        //    List<View_DanhMucDTO> dsDanhMuc = new List<View_DanhMucDTO>();

        //    using (SqlCommand cmd = new SqlCommand())
        //    {
        //        openConnection();
        //        SqlDataReader dataReader;
        //        dataReader = null;
        //        cmd.CommandText = @"SELECT [DanhMucGuid]
        //                                  ,[DanhMucID]
        //                                  ,[DanhMucName]
        //                                  ,[TrangThai]
        //                                  ,[LuuVetDanhMucGuid]
        //                                  ,[LuuVetDanhMucID]
        //                                  ,[LuuVetDanhMucName]
        //                                  ,[DanhMucChaGuid]
        //                                  ,[DanhMucChaName]
        //                                  ,[URLHinhAnh]
        //                              FROM [DanhMuc]
        //                              WHERE [TrangThai] <> 0";

        //        if (!CheckValid.ValidIsEmpty(param.DanhMucName))
        //        {
        //            cmd.CommandText += " [DanhMucName] LIKE @DanhMucName ";
        //            cmd.Parameters.Add("@DanhMucName", SqlDbType.NVarChar).Value = "%" + param.DanhMucName + "%";
        //        }

        //        cmd.CommandText += " ORDER BY DanhMucID DESC;";

        //        cmd.Connection = conn;
        //        cmd.Transaction = transaction;
        //        cmd.CommandType = CommandType.Text;

        //        try
        //        {
        //            dataReader = cmd.ExecuteReader();

        //            if (dataReader != null)
        //            {
        //                while (dataReader.Read())
        //                {
        //                    View_DanhMucDTO item = new View_DanhMucDTO(dataReader);

        //                    //item.DanhMucGuid = (Guid)dataReader["DanhMucGuid"];
        //                    //item.DanhMucID = (Int32)dataReader["DanhMucID"];
        //                    //item.DanhMucName = (String)dataReader["DanhMucName"];
        //                    //item.TrangThai = (Boolean)dataReader["TrangThai"];
        //                    dsDanhMuc.Add(item);
        //                }
        //            }

        //            return dsDanhMuc;
        //        }
        //        catch (Exception ex)
        //        {
        //            errorTransaction(ex);
        //            return null;
        //        }
        //        finally
        //        {
        //            dataReader.Close();
        //            closeConnection();
        //        }
        //    }
        //}

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
