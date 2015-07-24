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
    public class View_TinhThanhPho
    {
        private Guid _TinhThanhPhoGuid;

        private Guid _QuocGiaGuid;

        private String _MaTinh;

        private String _TenTinh;

        private Boolean _TrangThai;
		
		public View_TinhThanhPho(){
			
		TinhThanhPhoGuid=  Guid.Empty;

        QuocGiaGuid=  Guid.Empty;

        MaTinh=  String.Empty;

        TenTinh=  String.Empty;

        TrangThai=  true;
		}
		
		public View_TinhThanhPho(SqlDataReader dataReader){
			
		TinhThanhPhoGuid= dataReader["TinhThanhPhoGuid"] != null ? (Guid)dataReader["TinhThanhPhoGuid"] : Guid.Empty;

        QuocGiaGuid= dataReader["QuocGiaGuid"] != null ? (Guid)dataReader["QuocGiaGuid"] : Guid.Empty;

        MaTinh= dataReader["MaTinh"] != null ? (String)dataReader["MaTinh"] : String.Empty;

        TenTinh= dataReader["TenTinh"] != null ? (String)dataReader["TenTinh"] : String.Empty;

        TrangThai= dataReader["TrangThai"] != null ? (Boolean)dataReader["TrangThai"] : true;
		}
        public Guid TinhThanhPhoGuid
        {
            get
            {
                return _TinhThanhPhoGuid;
            }
            set
            {
                    _TinhThanhPhoGuid = value;
            }
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

        public String MaTinh
        {
            get
            {
                return _MaTinh;
            }
            set
            {
                _MaTinh = value;
            }
        }

        public String TenTinh
        {
            get
            {
                return _TenTinh;
            }
            set
            {
                _TenTinh = value;
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
