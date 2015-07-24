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
    public class DonViTinh
    {
        private Guid _DonViTinhGuid;

        private String _DonViTinhName;

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
