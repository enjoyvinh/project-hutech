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
    public class View_ItemSaleDetail
    {
        private Guid _ItemStoreGuid;

        private Guid _ItemSaleGuid;

        private Decimal _SoLuong;
		
		
		public View_ItemSaleDetail(){
			
		ItemStoreGuid= Guid.Empty;

        ItemSaleGuid=  Guid.Empty;

        SoLuong=  Decimal.Zero;
			
		}
		public View_ItemSaleDetail(SqlDataReader dataReader){
			
		ItemStoreGuid= dataReader["ItemStoreGuid"] != null ? (Guid)dataReader["ItemStoreGuid"] : Guid.Empty;

        ItemSaleGuid= dataReader["ItemSaleGuid"] != null ? (Guid)dataReader["ItemSaleGuid"] : Guid.Empty;

        SoLuong= dataReader["SoLuong"] != null ? (Decimal)dataReader["SoLuong"] : Decimal.Zero;
			
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

        public Guid ItemSaleGuid
        {
            get
            {
                return _ItemSaleGuid;
            }
            set
            {
                _ItemSaleGuid = value;

            }
        }

        public Decimal SoLuong
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
