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
    public class View_ItemStoreDetail
    {
        private Guid _KhoHangGuid;

        private Guid _ItemStoreGuid;

        private Int32 _SoLuong;
		
		public View_ItemStoreDetail(){
			
		KhoHangGuid=  Guid.Empty;

        ItemStoreGuid= Guid.Empty;

        SoLuong=  0;
		}
		public View_ItemStoreDetail(SqlDataReader dataReader){
			
		KhoHangGuid= dataReader["KhoHangGuid"] != null ? (Guid)dataReader["KhoHangGuid"] : Guid.Empty;

        ItemStoreGuid= dataReader["ItemStoreGuid"] != null ? (Guid)dataReader["ItemStoreGuid"] : Guid.Empty;

        SoLuong= dataReader["SoLuong"] != null ? (Int32)dataReader["SoLuong"] : 0;
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

        public Guid ItemStoreGuid
        {
            get
            {
                return _ItemStoreGuid;
            }
            set
            {
                    _ItemStoreGuid = value;
            }
        }

        public Int32 SoLuong
        {
            get
            {
                return _SoLuong;
            }
            set
            {
                _SoLuong = value;
            }
        }
    }
}
