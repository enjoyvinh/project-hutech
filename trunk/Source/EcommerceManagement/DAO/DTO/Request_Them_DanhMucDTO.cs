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
    public class Request_Them_DanhMucDTO
    {

        private String _DanhMucName;

        public String DanhMucName
        {
            get
            {
                return _DanhMucName;
            }
            set
            {
                _DanhMucName = value;
            }
        }

    }
}
