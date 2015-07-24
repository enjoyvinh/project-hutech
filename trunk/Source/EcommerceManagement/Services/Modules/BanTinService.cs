//using DAOs.Common;
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using DAOs.DAO;
//using DAOs.DTO;
//using DAOs.Entities;

//namespace Services.Modules
//{
//    public class BanTinService
//    {
//        BanTinDAO banTinDAO = new BanTinDAO();
//        public List<View_QuanLyBanTin_BanTin> getDanhSachBanTin(Request_QuanLyBanTin_ParamTimKiem param)
//        {
//            return banTinDAO.getDanhSachBanTin(param);
//        }

//        public Hashtable themBanTin(Request_QuanLyBanTin_ParamThem param)
//        {
//            Hashtable result = new Hashtable();
//            result.Add(AppConstraints.SUCCESS, String.Empty);
//            result.Add(AppConstraints.WARNING, String.Empty);
//            result.Add(AppConstraints.ERROR, String.Empty);

//            if (param.MATHELOAI == null)
//            {
//                result[AppConstraints.WARNING] = "Vui Lòng Chọn Thể Loại";
//                return result;
//            }
//            if (CheckValid.ValidIsEmpty(param.TIEUDE))
//            {
//                result[AppConstraints.WARNING] = "Vui Lòng Nhập Tiêu Đề";
//                return result;
//            }
//            if (CheckValid.ValidIsEmpty(param.NOIDUNGTOMTAT))
//            {
//                result[AppConstraints.WARNING] = "Vui Lòng Nhập Nội Dung Tóm Tắt";
//                return result;
//            }
//            if (CheckValid.ValidIsEmpty(param.NOIDUNG))
//            {
//                result[AppConstraints.WARNING] = "Vui Lòng Nhập Nội Dung";
//                return result;
//            }
//            if (CheckValid.ValidIsEmpty(param.TENTACGIA))
//            {
//                result[AppConstraints.WARNING] = "Vui Lòng Nhập Tên Tác Giả";
//                return result;
//            }
//            if (CheckValid.ValidIsEmpty(param.HINHANH))
//            {
//                result[AppConstraints.WARNING] = "Vui Lòng Chọn Hình Ảnh";
//                return result;
//            }

//            BanTin entityBanTin = new BanTin();

//            entityBanTin.MATHELOAI = param.MATHELOAI;
//            entityBanTin.MABANTIN = banTinDAO.getNewMaBanTin();
//            entityBanTin.LIKES = 0;
//            entityBanTin.HINHANH = param.HINHANH;
//            entityBanTin.NGAYDANG = param.NGAYDANG;
//            entityBanTin.NOIDUNG = param.NOIDUNG;
//            entityBanTin.NOIDUNGTOMTAT = param.NOIDUNGTOMTAT;
//            entityBanTin.TENTACGIA = param.TENTACGIA;
//            entityBanTin.TIEUDE = param.TIEUDE;
//            entityBanTin.XOA = param.XOA;
//            String slug = StringHelper.StringHandle(param.TIEUDE);
//            entityBanTin.SLUG = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + slug;


//            result = banTinDAO.themBanTin(entityBanTin);

//            return result;
//        }

//        public Hashtable xoaBanTin(Request_QuanLyBanTin_ParamXoa param)
//        {
//            return banTinDAO.xoaBanTin(param);
//        }

//        public View_QuanLyBanTin_BanTin getChiTietBanTin(Request_QuanLyBanTin_ParamTimKiem param)
//        {
//            return banTinDAO.getChiTietBanTin(param);
//        }

//        public Hashtable capnhatTheLoai(Request_QuanLyBanTin_ParamCapNhat param)
//        {
//            Hashtable result = new Hashtable();
//            result.Add(AppConstraints.SUCCESS, String.Empty);
//            result.Add(AppConstraints.WARNING, String.Empty);
//            result.Add(AppConstraints.ERROR, String.Empty);

//            if (param.MATHELOAI == null)
//            {
//                result[AppConstraints.WARNING] = "Vui Lòng Chọn Thể Loại";
//                return result;
//            }
//            if (CheckValid.ValidIsEmpty(param.TIEUDE))
//            {
//                result[AppConstraints.WARNING] = "Vui Lòng Nhập Tiêu Đề";
//                return result;
//            }
//            if (CheckValid.ValidIsEmpty(param.NOIDUNGTOMTAT))
//            {
//                result[AppConstraints.WARNING] = "Vui Lòng Nhập Nội Dung Tóm Tắt";
//                return result;
//            }
//            if (CheckValid.ValidIsEmpty(param.NOIDUNG))
//            {
//                result[AppConstraints.WARNING] = "Vui Lòng Nhập Nội Dung";
//                return result;
//            }
//            if (CheckValid.ValidIsEmpty(param.TENTACGIA))
//            {
//                result[AppConstraints.WARNING] = "Vui Lòng Nhập Tên Tác Giả";
//                return result;
//            }
//            if (CheckValid.ValidIsEmpty(param.HINHANH))
//            {
//                result[AppConstraints.WARNING] = "Vui Lòng Chọn Hình Ảnh";
//                return result;
//            }

//            BanTin entityBanTin = new BanTin();

//            entityBanTin.MATHELOAI = param.MATHELOAI;
//            entityBanTin.MABANTIN = banTinDAO.getNewMaBanTin();
//            entityBanTin.LIKES = 0;
//            entityBanTin.HINHANH = param.HINHANH;
//            entityBanTin.NGAYDANG = param.NGAYDANG;
//            entityBanTin.NOIDUNG = param.NOIDUNG;
//            entityBanTin.NOIDUNGTOMTAT = param.NOIDUNGTOMTAT;
//            entityBanTin.TENTACGIA = param.TENTACGIA;
//            entityBanTin.TIEUDE = param.TIEUDE;
//            entityBanTin.XOA = param.XOA;
//            String slug = StringHelper.StringHandle(param.TIEUDE);
//            entityBanTin.SLUG = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + slug;


//            result = banTinDAO.capnhatTheLoai(entityBanTin);

//            return result;
//        }
//    }
//}
