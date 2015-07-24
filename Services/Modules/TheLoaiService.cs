//using DAOs.Common;
//using DAOs.DAO;
//using DAOs.DTO;
//using DAOs.Entities;
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


//namespace Services.Modules
//{
//    public class TheLoaiService
//    {
//        TheLoaiDAO theLoaiDAO = new TheLoaiDAO();

//        public List<View_QuanLyTheLoai_TheLoai> getDanhSachTheLoai(Request_QuanLyTheLoai_ParamTimKiem param)
//        {
//            return theLoaiDAO.getDanhSachTheLoai(param);
//        }

//        public Hashtable xoaTheLoai(Request_QuanLyTheLoai_ParamXoa param)
//        {
//            return theLoaiDAO.xoaTheLoai(param);
//        }

//        public Hashtable themTheLoai(Request_QuanLyTheLoai_ParamThem param)
//        {
//            Hashtable result = new Hashtable();
//            result.Add(AppConstraints.SUCCESS, String.Empty);
//            result.Add(AppConstraints.WARNING, String.Empty);
//            result.Add(AppConstraints.ERROR, String.Empty);

//            if (CheckValid.ValidIsEmpty(param.TENTHELOAI))
//            {
//                result[AppConstraints.WARNING] = "Vui Lòng Nhập Tên Thể Loại";
//                return result;
//            }

//            TheLoai entityTheLoai = new TheLoai();

//            Int32 maTheLoai = theLoaiDAO.getNewMaTheLoai();
//            entityTheLoai.MATHELOAI = maTheLoai;
//            entityTheLoai.MOTA = param.MOTA;
//            entityTheLoai.NGAYTAO = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
//            entityTheLoai.SAPXEP = 1;
//            entityTheLoai.TENTHELOAI = param.TENTHELOAI;
//            var slug = StringHelper.StringHandle(param.TENTHELOAI);
//            entityTheLoai.SLUG = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + slug;
//            entityTheLoai.XOA = param.XOA;

//            result = theLoaiDAO.themTheLoai(entityTheLoai);

//            return result;
//        }

//        public View_QuanLyTheLoai_TheLoai getChiTietTheLoai(Request_QuanLyTheLoai_ParamTimKiem param)
//        {
//            return theLoaiDAO.getChiTietTheLoai(param);
//        }

//        public Hashtable capnhatTheLoai(Request_QuanLyTheLoai_ParamCapNhat param)
//        {
//            Hashtable result = new Hashtable();
//            result.Add(AppConstraints.SUCCESS, String.Empty);
//            result.Add(AppConstraints.WARNING, String.Empty);
//            result.Add(AppConstraints.ERROR, String.Empty);

//            if (CheckValid.ValidIsEmpty(param.MATHELOAI.ToString()))
//            {
//                result[AppConstraints.WARNING] = "Mã Thể Loại Không Có.";
//                return result;
//            }
//            if (CheckValid.ValidIsEmpty(param.TENTHELOAI))
//            {
//                result[AppConstraints.WARNING] = "Vui Lòng Nhập Tên Thể Loại.";
//                return result;
//            }

//            TheLoai entityTheLoai = new TheLoai();

//            entityTheLoai.MATHELOAI = param.MATHELOAI;
//            entityTheLoai.MOTA = param.MOTA;
//            entityTheLoai.SAPXEP = 1;
//            entityTheLoai.TENTHELOAI = param.TENTHELOAI;
//            String slug = StringHelper.StringHandle(param.TENTHELOAI);
//            entityTheLoai.SLUG = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() + "-" + slug;
//            entityTheLoai.XOA = param.XOA;

//            result = theLoaiDAO.capnhatTheLoai(entityTheLoai);

//            return result;
//        }
//    }
//}
