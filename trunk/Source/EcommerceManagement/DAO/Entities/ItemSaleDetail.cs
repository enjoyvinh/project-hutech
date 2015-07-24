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
    public class ItemSaleDetail
    {
        private Guid _ItemStoreGuid;

        private Guid _ItemSaleGuid;

        private Decimal _SoLuong;

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
