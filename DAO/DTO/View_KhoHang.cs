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
    public class View_KhoHang
    {
        private Guid _KhoHangGuid;

        private Guid _ChiNhanhGuid;

        private String _KhoHangID;

        private String _TenKhoHang;

        private String _DiaChi;

        private String _SoDienThoai;
		
		
		public View_KhoHang(){
			
		KhoHangGuid=  Guid.Empty;

        ChiNhanhGuid=  Guid.Empty;

        KhoHangID=  String.Empty;

        TenKhoHang=  String.Empty;

        DiaChi=  String.Empty;

        SoDienThoai=  String.Empty;
			
		}
		public View_KhoHang(SqlDataReader dataReader){
			
		KhoHangGuid= dataReader["KhoHangGuid"] != null ? (Guid)dataReader["KhoHangGuid"] : Guid.Empty;

        ChiNhanhGuid= dataReader["ChiNhanhGuid"] != null ? (Guid)dataReader["ChiNhanhGuid"] : Guid.Empty;

        KhoHangID= dataReader["KhoHangID"] != null ? (String)dataReader["KhoHangID"] : String.Empty;

        TenKhoHang= dataReader["TenKhoHang"] != null ? (String)dataReader["TenKhoHang"] : String.Empty;

        DiaChi= dataReader["DiaChi"] != null ? (String)dataReader["DiaChi"] : String.Empty;

        SoDienThoai= dataReader["SoDienThoai"] != null ? (String)dataReader["SoDienThoai"] : String.Empty;
			
		}
        public Guid KhoHangGuid
        {
            get
            {
                return _KhoHangGuid;
            }
            set
            {
                    _KhoHangGuid = value;
                
            }
        }

        public Guid ChiNhanhGuid
        {
            get
            {
                return _ChiNhanhGuid;
            }
            set
            {
                _ChiNhanhGuid = value;
            }
        }

        public String KhoHangID
        {
            get
            {
                return _KhoHangID;
            }
            set
            {
                _KhoHangID = value;
            }
        }

        public String TenKhoHang
        {
            get
            {
                return _TenKhoHang;
            }
            set
            {
                _TenKhoHang = value;
            }
        }

        public String DiaChi
        {
            get
            {
                return _DiaChi;
            }
            set
            {
                _DiaChi = value;
            }
        }

        public String SoDienThoai
        {
            get
            {
                return _SoDienThoai;
            }
            set
            {
                _SoDienThoai = value;
            }
        }
    }
}
