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
//    public class BanTinDAO : DBConnection
//    {
//        public List<View_QuanLyBanTin_BanTin> getDanhSachBanTin(Request_QuanLyBanTin_ParamTimKiem param)
//        {
//            List<View_QuanLyBanTin_BanTin> dsBanTin = new List<View_QuanLyBanTin_BanTin>();

//            using (SqlCommand cmd = new SqlCommand())
//            {
//                openConnection();

//                SqlDataReader dataReader;
//                dataReader = null;

//                cmd.CommandText = @"SELECT BT.MABANTIN
//                                          ,BT.MATHELOAI
//                                          ,BT.TIEUDE
//                                          ,BT.NOIDUNGTOMTAT
//                                          ,BT.NOIDUNG
//                                          ,BT.NGAYDANG
//                                          ,BT.HINHANH
//                                          ,BT.TENTACGIA
//                                          ,BT.SLUG AS BANTINSLUG
//                                          ,BT.LIKES
//                                          ,TL.TENTHELOAI
//                                          ,TL.MOTA
//                                          ,TL.SLUG AS THELOAISLUG
//                                    FROM BANTIN AS BT LEFT JOIN THELOAI AS TL
//                                      ON BT.MATHELOAI = TL.MATHELOAI
//                                    WHERE BT.NGAYDANG >= @TUNGAY
//                                      AND BT.NGAYDANG <= @DENNGAY ";

//                cmd.Parameters.Add("@TUNGAY", SqlDbType.DateTime).Value = param.TUNGAY;
//                cmd.Parameters.Add("@DENNGAY", SqlDbType.DateTime).Value = param.DENNGAY;

//                if (param.MATHELOAI != null)
//                {
//                    cmd.CommandText += " AND BT.MATHELOAI IN ( "+param.MATHELOAI[0];
                    
//                    foreach(int item in param.MATHELOAI)
//                    {
//                         cmd.CommandText += "," + Convert.ToString(item);
//                    }

//                    cmd.CommandText += ")";
//                }
//                if (!CheckValid.ValidIsEmpty(param.TIEUDE))
//                {
//                    cmd.CommandText += " AND BT.TIEUDE LIKE @TIEUDE ";
//                    cmd.Parameters.Add("@TIEUDE", SqlDbType.NVarChar).Value = "%" + param.TIEUDE + "%";
//                }
//                if (!CheckValid.ValidIsEmpty(param.TACGIA))
//                {
//                    cmd.CommandText += " AND BT.TACGIA LIKE @TACGIA ";
//                    cmd.Parameters.Add("@TACGIA", SqlDbType.NVarChar).Value = "%" + param.TACGIA + "%";
//                }
//                if (!CheckValid.ValidIsEmpty(param.NOIDUNGTOMTAT))
//                {
//                    cmd.CommandText += " AND BT.NOIDUNGTOMTAT LIKE @NOIDUNGTOMTAT ";
//                    cmd.Parameters.Add("@NOIDUNGTOMTAT", SqlDbType.NVarChar).Value = "%" + param.NOIDUNGTOMTAT + "%";
//                }

//                cmd.CommandText += " ORDER BY BT.NGAYDANG DESC;";

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
//                            View_QuanLyBanTin_BanTin bantin = new View_QuanLyBanTin_BanTin();

//                            bantin.MABANTIN = (Int32)dataReader["MABANTIN"];
//                            bantin.MATHELOAI = (Int32)dataReader["MATHELOAI"];
//                            bantin.TIEUDE = (String)dataReader["TIEUDE"];
//                            bantin.NOIDUNGTOMTAT = (String)dataReader["NOIDUNGTOMTAT"];
//                            bantin.NGAYDANG = (DateTime)dataReader["NGAYDANG"];
//                            bantin.HINHANH = (String)dataReader["HINHANH"];
//                            bantin.TENTACGIA = (String)dataReader["TENTACGIA"];
//                            bantin.BANTINSLUG = (String)dataReader["BANTINSLUG"];
//                            bantin.LIKES = (Int32)dataReader["LIKES"];
//                            bantin.TENTHELOAI = (String)dataReader["TENTHELOAI"];
//                            bantin.MOTA = (String)dataReader["MOTA"];
//                            bantin.THELOAISLUG = (String)dataReader["THELOAISLUG"];

//                            dsBanTin.Add(bantin);
//                        }
//                    }

//                    return dsBanTin;
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

//        public List<View_QuanLyBanTin_BanTin> getDanhSachSuKienMoiNhat()
//        {
//            List<View_QuanLyBanTin_BanTin> dsBanTin = new List<View_QuanLyBanTin_BanTin>();

//            using (SqlCommand cmd = new SqlCommand())
//            {
//                openConnection();

//                SqlDataReader dataReader;
//                dataReader = null;

//                cmd.CommandText = @"SELECT TOP 4 BT.MABANTIN
//                                          ,BT.MATHELOAI
//                                          ,BT.TIEUDE
//                                          ,BT.NOIDUNGTOMTAT
//                                          ,BT.NOIDUNG
//                                          ,BT.NGAYDANG
//                                          ,BT.HINHANH
//                                          ,BT.TENTACGIA
//                                          ,BT.SLUG AS BANTINSLUG
//                                          ,BT.LIKES
//                                          ,TL.TENTHELOAI
//                                          ,TL.MOTA
//                                          ,TL.SLUG AS THELOAISLUG
//                                    FROM BANTIN AS BT LEFT JOIN THELOAI AS TL
//                                      ON BT.MATHELOAI = TL.MATHELOAI ";

//                cmd.CommandText += " ORDER BY BT.LIKES DESC;";

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
//                            View_QuanLyBanTin_BanTin bantin = new View_QuanLyBanTin_BanTin();

//                            bantin.MABANTIN = (Int32)dataReader["MABANTIN"];
//                            bantin.MATHELOAI = (Int32)dataReader["MATHELOAI"];
//                            bantin.TIEUDE = (String)dataReader["TIEUDE"];
//                            bantin.NOIDUNGTOMTAT = (String)dataReader["NOIDUNGTOMTAT"];
//                            bantin.NGAYDANG = (DateTime)dataReader["NGAYDANG"];
//                            bantin.HINHANH = (String)dataReader["HINHANH"];
//                            bantin.TENTACGIA = (String)dataReader["TENTACGIA"];
//                            bantin.BANTINSLUG = (String)dataReader["BANTINSLUG"];
//                            bantin.LIKES = (Int32)dataReader["LIKES"];
//                            bantin.TENTHELOAI = (String)dataReader["TENTHELOAI"];
//                            bantin.MOTA = (String)dataReader["MOTA"];
//                            bantin.THELOAISLUG = (String)dataReader["THELOAISLUG"];

//                            dsBanTin.Add(bantin);
//                        }
//                    }

//                    return dsBanTin;
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

//        public List<View_QuanLyBanTin_BanTin> getDanhSachBanTinMoiNhat()
//        {
//            List<View_QuanLyBanTin_BanTin> dsBanTin = new List<View_QuanLyBanTin_BanTin>();

//            using (SqlCommand cmd = new SqlCommand())
//            {
//                openConnection();

//                SqlDataReader dataReader;
//                dataReader = null;

//                cmd.CommandText = @"SELECT TOP 10 BT.MABANTIN
//                                          ,BT.MATHELOAI
//                                          ,BT.TIEUDE
//                                          ,BT.NOIDUNGTOMTAT
//                                          ,BT.NOIDUNG
//                                          ,BT.NGAYDANG
//                                          ,BT.HINHANH
//                                          ,BT.TENTACGIA
//                                          ,BT.SLUG AS BANTINSLUG
//                                          ,BT.LIKES
//                                          ,TL.TENTHELOAI
//                                          ,TL.MOTA
//                                          ,TL.SLUG AS THELOAISLUG
//                                    FROM BANTIN AS BT LEFT JOIN THELOAI AS TL
//                                      ON BT.MATHELOAI = TL.MATHELOAI ";

//                cmd.CommandText += " ORDER BY BT.NGAYDANG DESC;";

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
//                            View_QuanLyBanTin_BanTin bantin = new View_QuanLyBanTin_BanTin();

//                            bantin.MABANTIN = (Int32)dataReader["MABANTIN"];
//                            bantin.MATHELOAI = (Int32)dataReader["MATHELOAI"];
//                            bantin.TIEUDE = (String)dataReader["TIEUDE"];
//                            bantin.NOIDUNGTOMTAT = (String)dataReader["NOIDUNGTOMTAT"];
//                            bantin.NGAYDANG = (DateTime)dataReader["NGAYDANG"];
//                            bantin.HINHANH = (String)dataReader["HINHANH"];
//                            bantin.TENTACGIA = (String)dataReader["TENTACGIA"];
//                            bantin.BANTINSLUG = (String)dataReader["BANTINSLUG"];
//                            bantin.LIKES = (Int32)dataReader["LIKES"];
//                            bantin.TENTHELOAI = (String)dataReader["TENTHELOAI"];
//                            bantin.MOTA = (String)dataReader["MOTA"];
//                            bantin.THELOAISLUG = (String)dataReader["THELOAISLUG"];

//                            dsBanTin.Add(bantin);
//                        }
//                    }

//                    return dsBanTin;
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

//        public List<View_QuanLyBanTin_BanTin> getDanhSachBanTinDocNhieu(Int32 MaTheLoai)
//        {
//            List<View_QuanLyBanTin_BanTin> dsBanTin = new List<View_QuanLyBanTin_BanTin>();

//            using (SqlCommand cmd = new SqlCommand())
//            {
//                openConnection();

//                SqlDataReader dataReader;
//                dataReader = null;

//                cmd.CommandText = @"SELECT TOP 5 BT.MABANTIN
//                                          ,BT.MATHELOAI
//                                          ,BT.TIEUDE
//                                          ,BT.NOIDUNGTOMTAT
//                                          ,BT.NOIDUNG
//                                          ,BT.NGAYDANG
//                                          ,BT.HINHANH
//                                          ,BT.TENTACGIA
//                                          ,BT.SLUG AS BANTINSLUG
//                                          ,BT.LIKES
//                                          ,TL.TENTHELOAI
//                                          ,TL.MOTA
//                                          ,TL.SLUG AS THELOAISLUG
//                                    FROM BANTIN AS BT LEFT JOIN THELOAI AS TL
//                                      ON BT.MATHELOAI = TL.MATHELOAI 
//                                    WHERE BT.MATHELOAI = @MATHELOAI ";

//                cmd.Parameters.Add("@MATHELOAI", SqlDbType.Int).Value = MaTheLoai;

//                cmd.CommandText += " ORDER BY BT.LIKES DESC;";

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
//                            View_QuanLyBanTin_BanTin bantin = new View_QuanLyBanTin_BanTin();

//                            bantin.MABANTIN = (Int32)dataReader["MABANTIN"];
//                            bantin.MATHELOAI = (Int32)dataReader["MATHELOAI"];
//                            bantin.TIEUDE = (String)dataReader["TIEUDE"];
//                            bantin.NOIDUNGTOMTAT = (String)dataReader["NOIDUNGTOMTAT"];
//                            bantin.NGAYDANG = (DateTime)dataReader["NGAYDANG"];
//                            bantin.HINHANH = (String)dataReader["HINHANH"];
//                            bantin.TENTACGIA = (String)dataReader["TENTACGIA"];
//                            bantin.BANTINSLUG = (String)dataReader["BANTINSLUG"];
//                            bantin.LIKES = (Int32)dataReader["LIKES"];
//                            bantin.TENTHELOAI = (String)dataReader["TENTHELOAI"];
//                            bantin.MOTA = (String)dataReader["MOTA"];
//                            bantin.THELOAISLUG = (String)dataReader["THELOAISLUG"];

//                            dsBanTin.Add(bantin);
//                        }
//                    }

//                    return dsBanTin;
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

//        public List<View_QuanLyBanTin_BanTin> getDanhSachBanTinMoiTheoTheLoai(Int32 MaTheLoai)
//        {
//            List<View_QuanLyBanTin_BanTin> dsBanTin = new List<View_QuanLyBanTin_BanTin>();

//            using (SqlCommand cmd = new SqlCommand())
//            {
//                openConnection();

//                SqlDataReader dataReader;
//                dataReader = null;

//                cmd.CommandText = @"SELECT TOP 1 BT.MABANTIN
//                                          ,BT.MATHELOAI
//                                          ,BT.TIEUDE
//                                          ,BT.NOIDUNGTOMTAT
//                                          ,BT.NOIDUNG
//                                          ,BT.NGAYDANG
//                                          ,BT.HINHANH
//                                          ,BT.TENTACGIA
//                                          ,BT.SLUG AS BANTINSLUG
//                                          ,BT.LIKES
//                                          ,TL.TENTHELOAI
//                                          ,TL.MOTA
//                                          ,TL.SLUG AS THELOAISLUG
//                                    FROM BANTIN AS BT LEFT JOIN THELOAI AS TL
//                                      ON BT.MATHELOAI = TL.MATHELOAI 
//                                    WHERE BT.MATHELOAI = @MATHELOAI ";

//                cmd.Parameters.Add("@MATHELOAI", SqlDbType.Int).Value = MaTheLoai;

//                cmd.CommandText += " ORDER BY BT.NGAYDANG DESC;";

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
//                            View_QuanLyBanTin_BanTin bantin = new View_QuanLyBanTin_BanTin();

//                            bantin.MABANTIN = (Int32)dataReader["MABANTIN"];
//                            bantin.MATHELOAI = (Int32)dataReader["MATHELOAI"];
//                            bantin.TIEUDE = (String)dataReader["TIEUDE"];
//                            bantin.NOIDUNGTOMTAT = (String)dataReader["NOIDUNGTOMTAT"];
//                            bantin.NGAYDANG = (DateTime)dataReader["NGAYDANG"];
//                            bantin.HINHANH = (String)dataReader["HINHANH"];
//                            bantin.TENTACGIA = (String)dataReader["TENTACGIA"];
//                            bantin.BANTINSLUG = (String)dataReader["BANTINSLUG"];
//                            bantin.LIKES = (Int32)dataReader["LIKES"];
//                            bantin.TENTHELOAI = (String)dataReader["TENTHELOAI"];
//                            bantin.MOTA = (String)dataReader["MOTA"];
//                            bantin.THELOAISLUG = (String)dataReader["THELOAISLUG"];

//                            dsBanTin.Add(bantin);
//                        }
//                    }

//                    return dsBanTin;
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

//        public List<View_QuanLyBanTin_BanTin> getDanhSachBanTin_TrangChu(Int32 MaTheLoai)
//        {
//            List<View_QuanLyBanTin_BanTin> dsBanTin = new List<View_QuanLyBanTin_BanTin>();

//            using (SqlCommand cmd = new SqlCommand())
//            {
//                openConnection();

//                SqlDataReader dataReader;
//                dataReader = null;

//                cmd.CommandText = @"SELECT TOP 4 BT.MABANTIN
//                                          ,BT.MATHELOAI
//                                          ,BT.TIEUDE
//                                          ,BT.NOIDUNGTOMTAT
//                                          ,BT.NOIDUNG
//                                          ,BT.NGAYDANG
//                                          ,BT.HINHANH
//                                          ,BT.TENTACGIA
//                                          ,BT.SLUG AS BANTINSLUG
//                                          ,BT.LIKES
//                                          ,TL.TENTHELOAI
//                                          ,TL.MOTA
//                                          ,TL.SLUG AS THELOAISLUG
//                                    FROM BANTIN AS BT LEFT JOIN THELOAI AS TL
//                                      ON BT.MATHELOAI = TL.MATHELOAI
//                                    WHERE BT.MATHELOAI = @MATHELOAI ";

//                cmd.Parameters.Add("@MATHELOAI", SqlDbType.Int).Value = MaTheLoai;
                
//                cmd.CommandText += " ORDER BY BT.NGAYDANG DESC;";

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
//                            View_QuanLyBanTin_BanTin bantin = new View_QuanLyBanTin_BanTin();

//                            bantin.MABANTIN = (Int32)dataReader["MABANTIN"];
//                            bantin.MATHELOAI = (Int32)dataReader["MATHELOAI"];
//                            bantin.TIEUDE = (String)dataReader["TIEUDE"];
//                            bantin.NOIDUNGTOMTAT = (String)dataReader["NOIDUNGTOMTAT"];
//                            bantin.NGAYDANG = (DateTime)dataReader["NGAYDANG"];
//                            bantin.HINHANH = (String)dataReader["HINHANH"];
//                            bantin.TENTACGIA = (String)dataReader["TENTACGIA"];
//                            bantin.BANTINSLUG = (String)dataReader["BANTINSLUG"];
//                            bantin.LIKES = (Int32)dataReader["LIKES"];
//                            bantin.TENTHELOAI = (String)dataReader["TENTHELOAI"];
//                            bantin.MOTA = (String)dataReader["MOTA"];
//                            bantin.THELOAISLUG = (String)dataReader["THELOAISLUG"];

//                            dsBanTin.Add(bantin);
//                        }
//                    }

//                    return dsBanTin;
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

//        public Int32 getNewMaBanTin()
//        {
//            Int32 maBanTin = 1;

//            using (SqlCommand cmd = new SqlCommand())
//            {
//                openConnection();
//                SqlDataReader dataReader;
//                dataReader = null;
//                cmd.CommandText = @"SELECT TOP 1 MABANTIN
//                                      FROM BANTIN 
//                                   ORDER BY MABANTIN DESC;";

//                cmd.Connection = conn;
//                cmd.Transaction = transaction;
//                cmd.CommandType = CommandType.Text;

//                try
//                {
//                    maBanTin = Convert.ToInt32(cmd.ExecuteScalar());

//                    return maBanTin;
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

//            return maBanTin;
//        }

//        public Hashtable themBanTin(BanTin entityBanTin)
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

//                    cmd.CommandText = @"INSERT INTO [BANTIN]
//                                               ([MABANTIN]
//                                               ,[MATHELOAI]
//                                               ,[TIEUDE]
//                                               ,[NOIDUNGTOMTAT]
//                                               ,[NOIDUNG]
//                                               ,[NGAYDANG]
//                                               ,[HINHANH]
//                                               ,[TENTACGIA]
//                                               ,[SLUG]
//                                               ,[LIKES]
//                                               ,[XOA])
//                                         VALUES
//                                               (@MABANTIN 
//                                               ,@MATHELOAI
//                                               ,@TIEUDE
//                                               ,@NOIDUNGTOMTAT
//                                               ,@NOIDUNG
//                                               ,@NGAYDANG
//                                               ,@HINHANH
//                                               ,@TENTACGIA
//                                               ,@SLUG
//                                               ,@LIKES
//                                               ,@XOA);";

//                    cmd.Parameters.Add("@MABANTIN", SqlDbType.Int).Value = entityBanTin.MABANTIN + 1;
//                    cmd.Parameters.Add("@MATHELOAI", SqlDbType.Int).Value = entityBanTin.MATHELOAI;
//                    cmd.Parameters.Add("@TIEUDE", SqlDbType.NVarChar).Value = entityBanTin.TIEUDE;
//                    cmd.Parameters.Add("@NOIDUNGTOMTAT", SqlDbType.NVarChar).Value = entityBanTin.NOIDUNGTOMTAT;
//                    cmd.Parameters.Add("@NOIDUNG", SqlDbType.NVarChar).Value = entityBanTin.NOIDUNG;
//                    cmd.Parameters.Add("@NGAYDANG", SqlDbType.DateTime).Value = entityBanTin.NGAYDANG;
//                    cmd.Parameters.Add("@HINHANH", SqlDbType.NVarChar).Value = entityBanTin.HINHANH;
//                    cmd.Parameters.Add("@TENTACGIA", SqlDbType.NVarChar).Value = entityBanTin.TENTACGIA;
//                    cmd.Parameters.Add("@SLUG", SqlDbType.NVarChar).Value = entityBanTin.SLUG;
//                    cmd.Parameters.Add("@LIKES", SqlDbType.Int).Value = 0;
//                    if (entityBanTin.XOA.Equals(1))
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

//        public Hashtable xoaBanTin(Request_QuanLyBanTin_ParamXoa param)
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

//                    cmd.CommandText = @"DELETE FROM BANTIN
//                                        WHERE MABANTIN = @MABANTIN";

//                    cmd.Parameters.Add("@MABANTIN", SqlDbType.Int).Value = param.MABANTIN;

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

//        public View_QuanLyBanTin_BanTin getChiTietBanTin(Request_QuanLyBanTin_ParamTimKiem param)
//        {
//            View_QuanLyBanTin_BanTin ctBanTin = new View_QuanLyBanTin_BanTin();

//            using (SqlCommand cmd = new SqlCommand())
//            {
//                openConnection();
//                SqlDataReader dataReader;
//                dataReader = null;
//                cmd.CommandText = @"SELECT BT.MABANTIN
//                                          ,BT.MATHELOAI
//                                          ,BT.TIEUDE
//                                          ,BT.NOIDUNGTOMTAT
//                                          ,BT.NOIDUNG
//                                          ,BT.NGAYDANG
//                                          ,BT.HINHANH
//                                          ,BT.TENTACGIA
//                                          ,BT.SLUG AS BANTINSLUG
//                                          ,BT.LIKES
//                                          ,BT.XOA
//                                          ,TL.TENTHELOAI
//                                          ,TL.MOTA
//                                          ,TL.SLUG AS THELOAISLUG
//                                    FROM BANTIN AS BT LEFT JOIN THELOAI AS TL
//                                      ON BT.MATHELOAI = TL.MATHELOAI ";

//                cmd.CommandText += "WHERE MABANTIN = @MABANTIN ;";
//                cmd.Parameters.Add("@MABANTIN", SqlDbType.Int).Value = param.MABANTIN;

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
//                            ctBanTin.MABANTIN = (Int32)dataReader["MABANTIN"];
//                            ctBanTin.MATHELOAI = (Int32)dataReader["MATHELOAI"];
//                            ctBanTin.TIEUDE = (String)dataReader["TIEUDE"];
//                            ctBanTin.NOIDUNGTOMTAT = (String)dataReader["NOIDUNGTOMTAT"];
//                            ctBanTin.NOIDUNG = (String)dataReader["NOIDUNG"];
//                            ctBanTin.NGAYDANG = (DateTime)dataReader["NGAYDANG"];
//                            ctBanTin.HINHANH = (String)dataReader["HINHANH"];
//                            ctBanTin.TENTACGIA = (String)dataReader["TENTACGIA"];
//                            ctBanTin.BANTINSLUG = (String)dataReader["BANTINSLUG"];
//                            ctBanTin.LIKES = (Int32)dataReader["LIKES"];
//                            ctBanTin.TENTHELOAI = (String)dataReader["TENTHELOAI"];
//                            ctBanTin.MOTA = (String)dataReader["MOTA"];
//                            ctBanTin.THELOAISLUG = (String)dataReader["THELOAISLUG"];
//                            ctBanTin.XOA = (Boolean)dataReader["XOA"];
//                        }
//                    }

//                    return ctBanTin;
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

//        public Hashtable capnhatTheLoai(BanTin entityBanTin)
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

//                cmd.CommandText += "WHERE MABANTIN = @MABANTIN ";

//                cmd.Parameters.Add("@MABANTIN", SqlDbType.Int).Value = entityBanTin.MABANTIN;

//                cmd.Connection = conn;
//                cmd.Transaction = transaction;
//                cmd.CommandType = CommandType.Text;

//                try
//                {
//                    Int32 soLuongBaiViet = Convert.ToInt32(cmd.ExecuteScalar());

//                    if (soLuongBaiViet <= 0)
//                    {
//                        result[AppConstraints.WARNING] = "Bản Tin Không Tồn Tại.";
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

//                    cmd.CommandText = @"UPDATE BANTIN
//                                           SET MATHELOAI = @MATHELOAI
//                                              ,TIEUDE = @TIEUDE
//                                              ,NOIDUNGTOMTAT = @NOIDUNGTOMTAT
//                                              ,NOIDUNG = @NOIDUNG
//                                              ,NGAYDANG = @NGAYDANG
//                                              ,HINHANH = @HINHANH
//                                              ,TENTACGIA = @TENTACGIA
//                                              ,SLUG = @SLUG
//                                              ,XOA = @XOA ";

//                    cmd.Parameters.Add("@MATHELOAI", SqlDbType.Int).Value = entityBanTin.MATHELOAI;
//                    cmd.Parameters.Add("@TIEUDE", SqlDbType.NVarChar).Value = entityBanTin.TIEUDE;
//                    cmd.Parameters.Add("@NOIDUNGTOMTAT", SqlDbType.NVarChar).Value = entityBanTin.NOIDUNGTOMTAT;
//                    cmd.Parameters.Add("@NOIDUNG", SqlDbType.NVarChar).Value = entityBanTin.NOIDUNG;
//                    cmd.Parameters.Add("@NGAYDANG", SqlDbType.DateTime).Value = entityBanTin.NGAYDANG;
//                    cmd.Parameters.Add("@TENTACGIA", SqlDbType.NVarChar).Value = entityBanTin.TENTACGIA;
//                    cmd.Parameters.Add("@SLUG", SqlDbType.NVarChar).Value = entityBanTin.SLUG;
//                    cmd.Parameters.Add("@HINHANH", SqlDbType.NVarChar).Value = entityBanTin.HINHANH;
//                    if (entityBanTin.XOA.Equals(1))
//                    {
//                        cmd.Parameters.Add("@XOA", SqlDbType.Bit).Value = true;
//                    }
//                    else
//                    {
//                        cmd.Parameters.Add("@XOA", SqlDbType.Bit).Value = false;
//                    }

//                    cmd.CommandText += " WHERE MABANTIN = @MABANTINCT ";

//                    cmd.Parameters.Add("@MABANTINCT", SqlDbType.Int).Value = entityBanTin.MABANTIN;

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
