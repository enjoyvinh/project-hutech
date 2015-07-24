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
    public class ItemStore
    {
        private Guid _ItemStoreGuid;

        private Guid _DanhMucGuid;

        private Guid _DonViTinhGuid;

        private String _ItemStoreID;

        private String _TenGoi;

        private String _URLHinhAnh;

        private Boolean _TrangThai;

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
