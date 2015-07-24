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

namespace DAOs.DTO
{
    public class Request_Xoa_DanhMucDTO
    {

        private Guid _DanhMucGuid;

        public Guid DanhMucGuid
        {
            get { return _DanhMucGuid; }
            set { _DanhMucGuid = value; }
        }

    }
}
