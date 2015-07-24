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
    public class View_DonViTinh
    {
        private Guid _DonViTinhGuid;

        private String _DonViTinhName;
		
		public View_DonViTinh(){
			
		DonViTinhGuid =  Guid.Empty;

        DonViTinhName=  String.Empty;
		}
		public View_DonViTinh(SqlDataReader dataReader){
			
		DonViTinhGuid = dataReader["DonViTinhGuid"] != null ? (Guid)dataReader["DonViTinhGuid"] : Guid.Empty;

        DonViTinhName= dataReader["DonViTinhName"] != null ? (String)dataReader["DonViTinhName"] : String.Empty;
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

        public String DonViTinhName
        {
            get
            {
                return _DonViTinhName;
            }
            set
            {
                _DonViTinhName = value;
            }
        }
    }
}
