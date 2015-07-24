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
    public class ItemStoreDetail
    {
        private Guid _KhoHangGuid;

        private Guid _ItemStoreGuid;

        private Int32 _SoLuong;

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
