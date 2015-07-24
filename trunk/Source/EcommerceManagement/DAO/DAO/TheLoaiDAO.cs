//using DAOs.Common;
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using DAOs.DTO;
//using DAOs.Entities;

//namespace DAOs.DAO
//{
//    public class TheLoaiDAO : DBConnection
//    {

//        public List<View_QuanLyTheLoai_TheLoai> getDanhSachTheLoai(Request_QuanLyTheLoai_ParamTimKiem param)
//        {
//            List<View_QuanLyTheLoai_TheLoai> dsTheLoai = new List<View_QuanLyTheLoai_TheLoai>();

//            using (SqlCommand cmd = new SqlCommand())
//            {
//                openConnection();
//                SqlDataReader dataReader;
//                dataReader = null;
//                cmd.CommandText = @"SELECT MATHELOAI
//                                          ,TENTHELOAI
//                                          ,MOTA
//                                          ,SAPXEP
//                                          ,SLUG
//                                          ,NGAYTAO
//                                      FROM THELOAI ";

//                if (!CheckValid.ValidIsEmpty(param.TENTHELOAI))
//                {
//                    cmd.CommandText += "WHERE TENTHELOAI LIKE @TENTHELOAI ";
//                    cmd.Parameters.Add("@TENTHELOAI", SqlDbType.NVarChar).Value = "%" + param.TENTHELOAI + "%";
//                }

//                cmd.CommandText += " ORDER BY SAPXEP ASC;";

//                cmd.Connection = conn;
//                cmd.Transaction = transaction;
//                cmd.CommandType = CommandType.Text;

//                try
//                {
//                    dataReader = cmd.ExecuteReader();

//                    if (dataReader != null)
//                    {
//                        while (dataReader.Read())
//                        {
//                            View_QuanLyTheLoai_TheLoai item = new View_QuanLyTheLoai_TheLoai();
//                            item.MATHELOAI = (Int32)dataReader["MATHELOAI"];
//                            item.TENTHELOAI = (String)dataReader["TENTHELOAI"];
//                            if (dataReader["MOTA"] != null)
//                            {
//                                item.MOTA = (String)dataReader["MOTA"];
//                            }
//                            else
//                            {
//                                item.MOTA = String.Empty;
//                            }
//                            item.SAPXEP = (Int32)dataReader["SAPXEP"];
//                            item.SLUG = (String)dataReader["SLUG"];
//                            item.NGAYTAO = (DateTime)dataReader["NGAYTAO"];

//                            dsTheLoai.Add(item);
//                        }
//                    }

//                    return dsTheLoai;
//                }
//                catch (Exception ex)
//                {
//                    errorTransaction(ex);
//                    return null;
//                }
//                finally
//                {
//                    dataReader.Close();
//                    closeConnection();
//                }
//            }
//        }

//        public Hashtable xoaTheLoai(Request_QuanLyTheLoai_ParamXoa param)
//        {
//            Hashtable result = new Hashtable();
//            result.Add(AppConstraints.SUCCESS, String.Empty);
//            result.Add(AppConstraints.WARNING, String.Empty);
//            result.Add(AppConstraints.ERROR, String.Empty);

//            using (SqlCommand cmd = new SqlCommand())
//            {
//                openConnection();

//                cmd.CommandText = @"SELECT COUNT(MABANTIN)
//                                      FROM BANTIN ";

//                cmd.CommandText += "WHERE MATHELOAI = @MATHELOAI ";

//                cmd.Parameters.Add("@MATHELOAI", SqlDbType.Int).Value = param.MATHELOAI;

//                cmd.Connection = conn;
//                cmd.Transaction = transaction;
//                cmd.CommandType = CommandType.Text;

//                try
//                {
//                    Int32 soLuongBaiViet = Convert.ToInt32(cmd.ExecuteScalar());

//                    if (soLuongBaiViet > 0)
//                    {
//                        result[AppConstraints.WARNING] = "Không Thể Xóa Thể Loại Này, Vui Lòng Xóa Bản Tin Trước.";
//                        return result;
//                    }
//                }
//                catch (Exception ex)
//                {
//                    errorTransaction(ex);
//                    return null;
//                }
//                finally
//                {
//                    closeConnection();
//                }
//            }

//            using (SqlCommand cmd = new SqlCommand())
//            {
//                try
//                {
//                    openConnection();

//                    SqlCommand cmdDate = new SqlCommand(" SET DATEFORMAT dmy", conn, transaction);
//                    cmdDate.ExecuteNonQuery();

//                    cmd.CommandText = @"DELETE FROM THELOAI
//                                        WHERE MATHELOAI = @MATHELOAI";

//                    cmd.Parameters.Add("@MATHELOAI", SqlDbType.Int).Value = param.MATHELOAI;

//                    cmd.Connection = conn;
//                    cmd.Transaction = transaction;
//                    cmd.CommandType = CommandType.Text;

//                    int check = cmd.ExecuteNonQuery();

//                    if (check > 0)
//                    {
//                        result[AppConstraints.SUCCESS] = AppConstraints.SUCCESS_DELETE_MESSAGE;
//                        return result;
//                    }
//                    else
//                    {
//                        result[AppConstraints.WARNING] = AppConstraints.WARNING_MESSAGE;
//                        return result;
//                    }
//                }
//                catch (Exception ex)
//                {
//                    errorTransaction();
//                    result[AppConstraints.ERROR] = AppConstraints.ERROR_MESSAGE + ex;
//                    return result;
//                }
//                finally
//                {
//                    closeConnection();
//                }
//            }

//            result[AppConstraints.ERROR] = AppConstraints.ERROR_MESSAGE;
//            return result;
//        }

//        public Hashtable themTheLoai(TheLoai entityTheLoai)
//        {
//            Hashtable result = new Hashtable();
//            result.Add(AppConstraints.SUCCESS, String.Empty);
//            result.Add(AppConstraints.WARNING, String.Empty);
//            result.Add(AppConstraints.ERROR, String.Empty);

//            using (SqlCommand cmd = new SqlCommand())
//            {
//                try
//                {
//                    openConnection();

//                    SqlCommand cmdDate = new SqlCommand(" SET DATEFORMAT dmy", conn, transaction);
//                    cmdDate.ExecuteNonQuery();

//                    cmd.CommandText = @"INSERT INTO THELOAI
//                                            (MATHELOAI
//                                            ,TENTHELOAI
//                                            ,MOTA
//                                            ,SAPXEP
//                                            ,SLUG
//                                            ,NGAYTAO
//                                            ,XOA)
//                                     VALUES
//                                           (@MATHELOAI
//                                           ,@TENTHELOAI
//                                           ,@MOTA
//                                           ,@SAPXEP
//                                           ,@SLUG
//                                           ,@NGAYTAO
//                                           ,@XOA)";

//                    cmd.Parameters.Add("@MATHELOAI", SqlDbType.Int).Value = entityTheLoai.MATHELOAI+1;
//                    cmd.Parameters.Add("@TENTHELOAI", SqlDbType.NVarChar).Value = entityTheLoai.TENTHELOAI;
//                    cmd.Parameters.Add("@MOTA", SqlDbType.NVarChar).Value = entityTheLoai.MOTA;
//                    cmd.Parameters.Add("@SAPXEP", SqlDbType.Int).Value = entityTheLoai.SAPXEP;
//                    cmd.Parameters.Add("@SLUG", SqlDbType.NVarChar).Value = entityTheLoai.SLUG;
//                    cmd.Parameters.Add("@NGAYTAO", SqlDbType.DateTime).Value = entityTheLoai.NGAYTAO;
//                    if (entityTheLoai.XOA.Equals(1))
//                    {
//                        cmd.Parameters.Add("@XOA", SqlDbType.Bit).Value = true;
//                    }
//                    else
//                    {
//                        cmd.Parameters.Add("@XOA", SqlDbType.Bit).Value = false;
//                    }
                    

//                    cmd.Connection = conn;
//                    cmd.Transaction = transaction;
//                    cmd.CommandType = CommandType.Text;

//                    int check = cmd.ExecuteNonQuery();

//                    if (check > 0)
//                    {
//                        result[AppConstraints.SUCCESS] = AppConstraints.SUCCESS_INSERT_MESSAGE;
//                        return result;
//                    }
//                    else
//                    {
//                        result[AppConstraints.WARNING] = AppConstraints.WARNING_MESSAGE;
//                        return result;
//                    }
//                }
//                catch (Exception ex)
//                {
//                    errorTransaction();
//                    result[AppConstraints.ERROR] = AppConstraints.ERROR_MESSAGE + ex;
//                    return result;
//                }
//                finally
//                {
//                    closeConnection();
//                }
//            }

//            result[AppConstraints.ERROR] = AppConstraints.ERROR_MESSAGE;
//            return result;
//        }

//        public Int32 getNewMaTheLoai()
//        {
//            Int32 maTheLoai = 1;

//            using (SqlCommand cmd = new SqlCommand())
//            {
//                openConnection();
//                SqlDataReader dataReader;
//                dataReader = null;
//                cmd.CommandText = @"SELECT TOP 1 MATHELOAI
//                                      FROM THELOAI 
//                                   ORDER BY MATHELOAI DESC;";

//                cmd.Connection = conn;
//                cmd.Transaction = transaction;
//                cmd.CommandType = CommandType.Text;

//                try
//                {
//                    maTheLoai = Convert.ToInt32(cmd.ExecuteScalar());

//                    return maTheLoai;
//                }
//                catch (Exception ex)
//                {
//                    errorTransaction(ex);
//                }
//                finally
//                {
//                    closeConnection();
//                }
//            }

//            return maTheLoai;
//        }

//        public View_QuanLyTheLoai_TheLoai getChiTietTheLoai(Request_QuanLyTheLoai_ParamTimKiem param)
//        {
//            View_QuanLyTheLoai_TheLoai ctTheLoai = new View_QuanLyTheLoai_TheLoai();

//            using (SqlCommand cmd = new SqlCommand())
//            {
//                openConnection();
//                SqlDataReader dataReader;
//                dataReader = null;
//                cmd.CommandText = @"SELECT MATHELOAI
//                                          ,TENTHELOAI
//                                          ,MOTA
//                                          ,SAPXEP
//                                          ,SLUG
//                                          ,NGAYTAO
//                                          ,XOA
//                                      FROM THELOAI ";

//                cmd.CommandText += "WHERE MATHELOAI = @MATHELOAI ";
//                cmd.Parameters.Add("@MATHELOAI", SqlDbType.Int).Value = param.MATHELOAI;

//                cmd.Connection = conn;
//                cmd.Transaction = transaction;
//                cmd.CommandType = CommandType.Text;

//                try
//                {
//                    dataReader = cmd.ExecuteReader();

//                    if (dataReader != null)
//                    {
//                        while (dataReader.Read())
//                        {
//                            ctTheLoai.MATHELOAI = (Int32)dataReader["MATHELOAI"];
//                            ctTheLoai.TENTHELOAI = (String)dataReader["TENTHELOAI"];
//                            if (dataReader["MOTA"] != null)
//                            {
//                                ctTheLoai.MOTA = (String)dataReader["MOTA"];
//                            }
//                            else
//                            {
//                                ctTheLoai.MOTA = String.Empty;
//                            }
//                            ctTheLoai.SAPXEP = (Int32)dataReader["SAPXEP"];
//                            ctTheLoai.SLUG = (String)dataReader["SLUG"];
//                            ctTheLoai.NGAYTAO = (DateTime)dataReader["NGAYTAO"];
//                            ctTheLoai.XOA = (Boolean)dataReader["XOA"];
//                        }
//                    }

//                    return ctTheLoai;
//                }
//                catch (Exception ex)
//                {
//                    errorTransaction(ex);
//                    return null;
//                }
//                finally
//                {
//                    dataReader.Close();
//                    closeConnection();
//                }
//            }
//        }

//        public Hashtable capnhatTheLoai(TheLoai entityTheLoai)
//        {
//            Hashtable result = new Hashtable();
//            result.Add(AppConstraints.SUCCESS, String.Empty);
//            result.Add(AppConstraints.WARNING, String.Empty);
//            result.Add(AppConstraints.ERROR, String.Empty);

//            using (SqlCommand cmd = new SqlCommand())
//            {
//                try
//                {
//                    openConnection();

//                    SqlCommand cmdDate = new SqlCommand(" SET DATEFORMAT dmy ", conn, transaction);
//                    cmdDate.ExecuteNonQuery();

//                    cmd.CommandText = @"UPDATE THELOAI
//                                        SET    TENTHELOAI = @TENTHELOAI
//                                              ,MOTA = @MOTA
//                                              ,SLUG = @SLUG
//                                              ,XOA = @XOA
//                                         WHERE MATHELOAI = @MATHELOAI;";

//                    cmd.Parameters.Add("@MATHELOAI", SqlDbType.Int).Value = entityTheLoai.MATHELOAI;
//                    cmd.Parameters.Add("@TENTHELOAI", SqlDbType.NVarChar).Value = entityTheLoai.TENTHELOAI;
//                    cmd.Parameters.Add("@MOTA", SqlDbType.NVarChar).Value = entityTheLoai.MOTA;
//                    cmd.Parameters.Add("@SLUG", SqlDbType.NVarChar).Value = entityTheLoai.SLUG;
//                    if (entityTheLoai.XOA.Equals(1))
//                    {
//                        cmd.Parameters.Add("@XOA", SqlDbType.Bit).Value = true;
//                    }
//                    else
//                    {
//                        cmd.Parameters.Add("@XOA", SqlDbType.Bit).Value = false;
//                    }

//                    cmd.Connection = conn;
//                    cmd.Transaction = transaction;
//                    cmd.CommandType = CommandType.Text;

//                    int check = cmd.ExecuteNonQuery();

//                    if (check > 0)
//                    {
//                        result[AppConstraints.SUCCESS] = AppConstraints.SUCCESS_UPDATE_MESSAGE;
//                        return result;
//                    }
//                    else
//                    {
//                        result[AppConstraints.WARNING] = AppConstraints.WARNING_MESSAGE;
//                        return result;
//                    }
//                }
//                catch (Exception ex)
//                {
//                    errorTransaction();
//                    result[AppConstraints.ERROR] = AppConstraints.ERROR_MESSAGE + ex;
//                    return result;
//                }
//                finally
//                {
//                    closeConnection();
//                }
//            }

//            result[AppConstraints.ERROR] = AppConstraints.ERROR_MESSAGE;
//            return result;
//        }

//    }
//}
