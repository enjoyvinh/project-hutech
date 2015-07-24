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
    public class View_KhuVucBanHang
    {
        private Guid _KhuVucBanHangGuid;

        private String _KhuVucBanName;

        private String _KhuVucBanID;

        private Guid _KhuVucChaGuid;

        private String _KhuVucChaID;

        private String _KhuVucChaName;

        private String _LuuVetKhuVucGuid;

        private String _LuuVetKhuVucID;

        private String _LuuVetKhuVucName;

        private Boolean _TrangThai;
		
		
		public View_KhuVucBanHang(){
			
		KhuVucBanHangGuid=  Guid.Empty;

        KhuVucBanName=  String.Empty;

        KhuVucBanID=  String.Empty;

        KhuVucChaGuid=  Guid.Empty;

        KhuVucChaID=  String.Empty;

        KhuVucChaName=  String.Empty;

        LuuVetKhuVucGuid=  String.Empty;

        LuuVetKhuVucID= String.Empty;

        LuuVetKhuVucName=  String.Empty;

        TrangThai=  true;
		}
		
		public View_KhuVucBanHang(SqlDataReader dataReader){
			
		KhuVucBanHangGuid= dataReader["KhuVucBanHangGuid"] != null ? (Guid)dataReader["KhuVucBanHangGuid"] : Guid.Empty;

        KhuVucBanName= dataReader["KhuVucBanName"] != null ? (String)dataReader["KhuVucBanName"] : String.Empty;

        KhuVucBanID= dataReader["KhuVucBanID"] != null ? (String)dataReader["KhuVucBanID"] : String.Empty;

        KhuVucChaGuid= dataReader["KhuVucChaGuid"] != null ? (Guid)dataReader["KhuVucChaGuid"] : Guid.Empty;

        KhuVucChaID= dataReader["KhuVucChaID"] != null ? (String)dataReader["KhuVucChaID"] : String.Empty;

        KhuVucChaName= dataReader["KhuVucChaName"] != null ? (String)dataReader["KhuVucChaName"] : String.Empty;

        LuuVetKhuVucGuid= dataReader["LuuVetKhuVucGuid"] != null ? (String)dataReader["LuuVetKhuVucGuid"] : String.Empty;

        LuuVetKhuVucID= dataReader["LuuVetKhuVucID"] != null ? (String)dataReader["LuuVetKhuVucID"] : String.Empty;

        LuuVetKhuVucName= dataReader["LuuVetKhuVucName"] != null ? (String)dataReader["LuuVetKhuVucName"] : String.Empty;

        TrangThai= dataReader["TrangThai"] != null ? (Boolean)dataReader["TrangThai"] : true;
		}
        public Guid KhuVucBanHangGuid
        {
            get
            {
                return _KhuVucBanHangGuid;
            }
            set
            {
                _KhuVucBanHangGuid = value;
            }
        }

        public String KhuVucBanName
        {
            get
            {
                return _KhuVucBanName;
            }
            set
            {
                _KhuVucBanName = value;
            }
        }

        public String KhuVucBanID
        {
            get
            {
                return _KhuVucBanID;
            }
            set
            {
                _KhuVucBanID = value;
            }
        }

        public Guid KhuVucChaGuid
        {
            get
            {
                return _KhuVucChaGuid;
            }
            set
            {
                _KhuVucChaGuid = value;
            }
        }

        public String KhuVucChaID
        {
            get
            {
                return _KhuVucChaID;
            }
            set
            {
                _KhuVucChaID = value;
            }
        }

        public String KhuVucChaName
        {
            get
            {
                return _KhuVucChaName;
            }
            set
            {
                _KhuVucChaName = value;
            }
        }

        public String LuuVetKhuVucGuid
        {
            get
            {
                return _LuuVetKhuVucGuid;
            }
            set
            {
                _LuuVetKhuVucGuid = value;
            }
        }

        public String LuuVetKhuVucID
        {
            get
            {
                return _LuuVetKhuVucID;
            }
            set
            {
                _LuuVetKhuVucID = value;
            }
        }

        public String LuuVetKhuVucName
        {
            get
            {
                return _LuuVetKhuVucName;
            }
            set
            {
                _LuuVetKhuVucName = value;
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
