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
    public class View_QuocGia
    {
        private Guid _QuocGiaGuid;

        private String _MaQuocGia;

        private String _TenVietTat;

        private String _TenQuocGia;

        private String _DinhDangSo;

        private String _DinhDangTienTe;

        private String _DinhDangNgayThang;

        private String _URLCoQuocGia;

        private Boolean _TrangThai;
		
		public View_QuocGia(){
			
		QuocGiaGuid=  Guid.Empty;

        MaQuocGia=  String.Empty;

        TenVietTat=  String.Empty;

        TenQuocGia= String.Empty;

        DinhDangSo=  String.Empty;

        DinhDangTienTe=  String.Empty;

        DinhDangNgayThang=  String.Empty;

        URLCoQuocGia=  String.Empty;

        TrangThai=  true;
		}
		public View_QuocGia(SqlDataReader dataReader){
			
		QuocGiaGuid= dataReader["QuocGiaGuid"] != null ? (Guid)dataReader["QuocGiaGuid"] : Guid.Empty;

        MaQuocGia= dataReader["MaQuocGia"] != null ? (String)dataReader["MaQuocGia"] : String.Empty;

        TenVietTat= dataReader["TenVietTat"] != null ? (String)dataReader["TenVietTat"] : String.Empty;

        TenQuocGia= dataReader["TenQuocGia"] != null ? (String)dataReader["TenQuocGia"] : String.Empty;

        DinhDangSo= dataReader["DinhDangSo"] != null ? (String)dataReader["DinhDangSo"] : String.Empty;

        DinhDangTienTe= dataReader["DinhDangTienTe"] != null ? (String)dataReader["DinhDangTienTe"] : String.Empty;

        DinhDangNgayThang= dataReader["DinhDangNgayThang"] != null ? (String)dataReader["DinhDangNgayThang"] : String.Empty;

        URLCoQuocGia= dataReader["URLCoQuocGia"] != null ? (String)dataReader["URLCoQuocGia"] : String.Empty;

        TrangThai= dataReader["TrangThai"] != null ? (Boolean)dataReader["TrangThai"] : true;
		}
        public Guid QuocGiaGuid
        {
            get
            {
                return _QuocGiaGuid;
            }
            set
            {
                    _QuocGiaGuid = value;
            }
        }

        public String MaQuocGia
        {
            get
            {
                return _MaQuocGia;
            }
            set
            {
                _MaQuocGia = value;
            }
        }

        public String TenVietTat
        {
            get
            {
                return _TenVietTat;
            }
            set
            {
                _TenVietTat = value;
            }
        }

        public String TenQuocGia
        {
            get
            {
                return _TenQuocGia;
            }
            set
            {
                _TenQuocGia = value;
            }
        }

        public String DinhDangSo
        {
            get
            {
                return _DinhDangSo;
            }
            set
            {
                _DinhDangSo = value;
            }
        }

        public String DinhDangTienTe
        {
            get
            {
                return _DinhDangTienTe;
            }
            set
            {
                _DinhDangTienTe = value;
            }
        }

        public String DinhDangNgayThang
        {
            get
            {
                return _DinhDangNgayThang;
            }
            set
            {
                _DinhDangNgayThang = value;
            }
        }

        public String URLCoQuocGia
        {
            get
            {
                return _URLCoQuocGia;
            }
            set
            {
                _URLCoQuocGia = value;
            }
        }

        public Boolean TrangThai
        {
            get
            {
                return _TrangThai;
            }
            set
            {
                _TrangThai = value;
            }
        }
 
    }
}
