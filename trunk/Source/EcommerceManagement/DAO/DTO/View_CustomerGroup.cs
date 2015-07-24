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
    public class View_CustomerGroup
    {
        private Guid _CustomerGroupGuid;

        private String _ChinhSachCuaGroup;

        public View_CustomerGroup()
        {

            CustomerGroupGuid = Guid.Empty;
            ChinhSachCuaGroup = String.Empty;
        }


        public View_CustomerGroup(SqlDataReader dataReader)
        {

            CustomerGroupGuid = dataReader["CustomerGroupGuid"] != null ? (Guid)dataReader["CustomerGroupGuid"] : Guid.Empty;
            ChinhSachCuaGroup = dataReader["ChinhSachCuaGroup"] != null ? (String)dataReader["ChinhSachCuaGroup"] : String.Empty;
        }

        public Guid CustomerGroupGuid
        {
            get
            {
                return _CustomerGroupGuid;
            }
            set
            {
                _CustomerGroupGuid = value;
            }
        }

        public String ChinhSachCuaGroup
        {
            get
            {
                return _ChinhSachCuaGroup;
            }
            set
            {
                _ChinhSachCuaGroup = value;
            }
        }
    }
}
