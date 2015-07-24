using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 *  
 *  Author:     Vinh Nguyễn - 1216061133
 *  Class:      12LDTHC2
 *  Version:    1.0
 *  Copyright @ 2015 HUTECH
 * 
 */

namespace TruyXuatDB.Entities
{
    public class CustomerGroup
    {
        private Guid _CustomerGroupGuid;

        private String _ChinhSachCuaGroup;

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
