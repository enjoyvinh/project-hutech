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
    public class SF_HoaDonDAO : DBConnection
    {
        public Int64 getTongHoaDonTheoThang(Int16 thang, Int16 trangThaiHoaDon)
        {
            Int64 result = 0;

            using (SqlCommand cmd = new SqlCommand())
            {
                openConnection();

                cmd.CommandText = @"SELECT COUNT([SOHOADON])
                                      FROM [SF_HOADON]
                                    WHERE [TRANGTHAIHOADON] = @TrangThaiHoaDon
                                    AND MONTH([NGAYLAP]) = @Thang
                                    AND YEAR([NGAYLAP]) = @Nam";

                cmd.Parameters.Add("@TrangThaiHoaDon", SqlDbType.Int).Value = trangThaiHoaDon;
                cmd.Parameters.Add("@Thang", SqlDbType.Int).Value = thang;
                cmd.Parameters.Add("@Nam", SqlDbType.Int).Value = DateTime.Now.Year;

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

        public Int64 getTongHoaDonTheoNam(Int16 Nam, Int16 trangThaiHoaDon)
        {
            Int64 result = 0;

            using (SqlCommand cmd = new SqlCommand())
            {
                openConnection();

                cmd.CommandText = @"SELECT COUNT([SOHOADON])
                                      FROM [SF_HOADON]
                                    WHERE [TRANGTHAIHOADON] = @TrangThaiHoaDon
                                    AND YEAR([NGAYLAP]) = @Nam;";

                cmd.Parameters.Add("@TrangThaiHoaDon", SqlDbType.Int).Value = trangThaiHoaDon;
                cmd.Parameters.Add("@Nam", SqlDbType.Int).Value = Nam;

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

        public Decimal getTongGiaTriHoaDonTheoNam(Int16 Nam, Int16 trangThaiHoaDon)
        {
            Decimal result = Decimal.Zero;

            using (SqlCommand cmd = new SqlCommand())
            {
                openConnection();

                cmd.CommandText = @"SELECT COALESCE(SUM([TONGTIEN]),0)
                                      FROM [SF_HOADON]
                                    WHERE [TRANGTHAIHOADON] = @TrangThaiHoaDon
                                    AND YEAR([NGAYLAP]) = @Nam;";

                cmd.Parameters.Add("@TrangThaiHoaDon", SqlDbType.Int).Value = trangThaiHoaDon;
                cmd.Parameters.Add("@Nam", SqlDbType.Int).Value = Nam;

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

        public List<VIEW_HOADON_DASHBOARD_GIATRICAONHATDTO> getHoaDonGiaTriCaoNhat(REQUEST_NGAYTHANGNAMDTO param)
        {
            List<VIEW_HOADON_DASHBOARD_GIATRICAONHATDTO> dsHoaDon = new List<VIEW_HOADON_DASHBOARD_GIATRICAONHATDTO>();

            using (SqlCommand cmd = new SqlCommand())
            {
                openConnection();
                SqlDataReader dataReader;
                dataReader = null;
                cmd.CommandText = @"SELECT DISTINCT TOP 5 
                                             HD.SOHOADON
		                                    ,HD.NGAYLAP
		                                    ,HD.TONGTIEN
                                            ,CH.MACUAHANG
		                                    ,COALESCE(CH.HINHLOGO,'SHOP_NOIMAGE') AS HINHLOGO
                                    FROM SF_HOADON AS HD LEFT JOIN SF_CUAHANG AS CH
                                    ON HD.MACUAHANG = CH.MACUAHANG
                                    WHERE HD.TRANGTHAIHOADON = 1 ";

                if(CheckValid.ValidIsNumeric(param.THANG.ToString()))
                {
                    cmd.CommandText += @" AND MONTH(NGAYTAO) = @Month ";
                    cmd.Parameters.Add("@Month", SqlDbType.Int).Value = param.THANG;
                }
                if (CheckValid.ValidIsNumeric(param.THANG.ToString()))
                {
                    cmd.CommandText += @" AND YEAR(NGAYTAO) = @Year ";
                    cmd.Parameters.Add("@Year", SqlDbType.Int).Value = param.NAM;
                }

                cmd.CommandText += @"ORDER BY TONGTIEN DESC";

                cmd.Connection = conn;
                cmd.Transaction = transaction;
                cmd.CommandType = CommandType.Text;

                try
                {
                    dataReader = cmd.ExecuteReader();

                    if (dataReader != null)
                    {
                        while (dataReader.Read())
                        {
                            VIEW_HOADON_DASHBOARD_GIATRICAONHATDTO item = new VIEW_HOADON_DASHBOARD_GIATRICAONHATDTO();

                            item.MACUAHANG = (String)dataReader["MACUAHANG"];
                            item.AVATARCUAHANG = (String)dataReader["HINHLOGO"];
                            item.NGAYLAP = (DateTime)dataReader["NGAYLAP"];
                            item.SOHOADON = (String)dataReader["SOHOADON"];
                            item.TONGTIEN = (Decimal)dataReader["TONGTIEN"];

                            dsHoaDon.Add(item);
                        }
                    }

                    return dsHoaDon;
                }
                catch (Exception ex)
                {
                    errorTransaction(ex);
                    return new List<VIEW_HOADON_DASHBOARD_GIATRICAONHATDTO>();
                }
                finally
                {
                    dataReader.Close();
                    closeConnection();
                }
            }
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
