using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
/*
 *  
 *  Author:     Vinh Nguyễn - 1216061133
 *  Class:      12LDTHC2
 *  Version:    1.0
 *  Copyright @ 2015 HUTECH
 * 
 */

namespace DAOs.DTO
{
    public class View_NhanVien
    {
        private Guid _NhanVienGuid;

        private String _MaNhanVien;

        private String _Ho;

        private String _Ten;

        private String _TenLot;

        private DateTime _NgaySinh;

        private String _SoCMND;

        private Int32 _Phai;

        private String _DiaChiLienHe;

        private String _DienThoai;

        private String _Email;

        private String _URLHinhAnh;

        private Int32 _UserId;
		
		public View_NhanVien(){
			
		NhanVienGuid=  Guid.Empty;

        MaNhanVien=  String.Empty;

        Ho=  String.Empty;

        Ten=  String.Empty;

        TenLot= String.Empty;

        NgaySinh=  DateTime.Now;

        SoCMND=  String.Empty;

        Phai=  0;

        DiaChiLienHe= String.Empty;

        DienThoai= String.Empty;

        Email=String.Empty;

        URLHinhAnh=  String.Empty;

        UserId=  0;
		}
		public View_NhanVien(SqlDataReader dataReader){
			
		NhanVienGuid= dataReader["NhanVienGuid"] != null ? (Guid)dataReader["NhanVienGuid"] : Guid.Empty;

        MaNhanVien= dataReader["MaNhanVien"] != null ? (String)dataReader["MaNhanVien"] : String.Empty;

        Ho= dataReader["Ho"] != null ? (String)dataReader["Ho"] : String.Empty;

        Ten= dataReader["Ten"] != null ? (String)dataReader["Ten"] : String.Empty;

        TenLot= dataReader["TenLot"] != null ? (String)dataReader["TenLot"] : String.Empty;

        NgaySinh= dataReader["NgaySinh"] != null ? (DateTime)dataReader["NgaySinh"] : DateTime.Now;

        SoCMND= dataReader["SoCMND"] != null ? (String)dataReader["SoCMND"] : String.Empty;

        Phai= dataReader["Phai"] != null ? (Int32)dataReader["Phai"] : 0;

        DiaChiLienHe= dataReader["DiaChiLienHe"] != null ? (String)dataReader["DiaChiLienHe"] : String.Empty;

        DienThoai= dataReader["DienThoai"] != null ? (String)dataReader["DienThoai"] : String.Empty;

        Email= dataReader["Email"] != null ? (String)dataReader["Email"] : String.Empty;

        URLHinhAnh= dataReader["URLHinhAnh"] != null ? (String)dataReader["URLHinhAnh"] : String.Empty;

        UserId= dataReader["UserId"] != null ? (Int32)dataReader["UserId"] : 0;
		}
        public Int32 UserId
        {
            get
            {
                return _UserId;
            }
            set
            {
                _UserId = value;
            }
        }



        public Guid NhanVienGuid
        {
            get
            {
                return _NhanVienGuid;
            }
            set
            {
                _NhanVienGuid = value;
            }
        }

        public String MaNhanVien
        {
            get
            {
                return _MaNhanVien;
            }
            set
            {
                _MaNhanVien = value;
            }
        }

        public String Ho
        {
            get
            {
                return _Ho;
            }
            set
            {
                _Ho = value;
            }
        }

        public String Ten
        {
            get
            {
                return _Ten;
            }
            set
            {
                _Ten = value;
            }
        }

        public String TenLot
        {
            get
            {
                return _TenLot;
            }
            set
            {
                _TenLot = value;
            }
        }

        public DateTime NgaySinh
        {
            get
            {
                return _NgaySinh;
            }
            set
            {
                _NgaySinh = value;
            }
        }

        public String SoCMND
        {
            get
            {
                return _SoCMND;
            }
            set
            {
                _SoCMND = value;
            }
        }

        public Int32 Phai
        {
            get
            {
                return _Phai;
            }
            set
            {
                _Phai = value;
            }
        }

        public String DiaChiLienHe
        {
            get
            {
                return _DiaChiLienHe;
            }
            set
            {
                _DiaChiLienHe = value;
            }
        }

        public String DienThoai
        {
            get
            {
                return _DienThoai;
            }
            set
            {
                _DienThoai = value;
            }
        }

        public String Email
        {
            get
            {
                return _Email;
            }
            set
            {
                _Email = value;
            }
        }

        public String URLHinhAnh
        {
            get
            {
                return _URLHinhAnh;
            }
            set
            {
                _URLHinhAnh = value;
            }
        }
    }
}
