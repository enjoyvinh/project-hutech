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
    public class View_ItemStore
    {
        private Guid _ItemStoreGuid;

        private Guid _DanhMucGuid;

        private Guid _DonViTinhGuid;

        private String _ItemStoreID;

        private String _TenGoi;

        private String _URLHinhAnh;

        private Boolean _TrangThai;
		
		
		public View_ItemStore(){
			
		ItemStoreGuid=  Guid.Empty;

        DanhMucGuid=  Guid.Empty;

        DonViTinhGuid=  Guid.Empty;

        ItemStoreID=  String.Empty;

        TenGoi=  String.Empty;

        URLHinhAnh=  String.Empty;

        TrangThai=  true;
		}
		public View_ItemStore(SqlDataReader dataReader){
			
		ItemStoreGuid= dataReader["ItemStoreGuid"] != null ? (Guid)dataReader["ItemStoreGuid"] : Guid.Empty;

        DanhMucGuid= dataReader["DanhMucGuid"] != null ? (Guid)dataReader["DanhMucGuid"] : Guid.Empty;

        DonViTinhGuid= dataReader["DonViTinhGuid"] != null ? (Guid)dataReader["DonViTinhGuid"] : Guid.Empty;

        ItemStoreID= dataReader["ItemStoreID"] != null ? (String)dataReader["ItemStoreID"] : String.Empty;

        TenGoi= dataReader["TenGoi"] != null ? (String)dataReader["TenGoi"] : String.Empty;

        URLHinhAnh= dataReader["URLHinhAnh"] != null ? (String)dataReader["URLHinhAnh"] : String.Empty;

        TrangThai= dataReader["TrangThai"] != null ? (Boolean)dataReader["TrangThai"] : true;
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

        public Guid DanhMucGuid
        {
            get
            {
                return _DanhMucGuid;
            }
            set
            {
                _DanhMucGuid = value;
            }
        }

        public Guid DonViTinhGuid
        {
            get
            {
                return _DonViTinhGuid;
            }
            set
            {
                _DonViTinhGuid = value;
            }
        }

        public String ItemStoreID
        {
            get
            {
                return _ItemStoreID;
            }
            set
            {
                _ItemStoreID = value;
            }
        }

        public String TenGoi
        {
            get
            {
                return _TenGoi;
            }
            set
            {
                _TenGoi = value;
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
