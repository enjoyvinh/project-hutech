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
    public class ItemSale
    {
        private Guid _ItemSaleGuid;

        private Guid _DanhMucGuid;

        private Guid _DonViTinhGuid;

        private String _ItemSaleID;

        private String _TenGoi;

        private Decimal _GiaBan;

        private Decimal _GiaKhuyenMai;

        private Boolean _TrangThai;

        private String _URLHinhAnh;

        private Int32 _ThoiGianBaoHanh;

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

        public String ItemSaleID
        {
            get
            {
                return _ItemSaleID;
            }
            set
            {
                _ItemSaleID = value;
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

        public Decimal GiaBan
        {
            get
            {
                return _GiaBan;
            }
            set
            {
                _GiaBan = value;
            }
        }

        public Decimal GiaKhuyenMai
        {
            get
            {
                return _GiaKhuyenMai;
            }
            set
            {
                _GiaKhuyenMai = value;
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

        public Int32 ThoiGianBaoHanh
        {
            get
            {
                return _ThoiGianBaoHanh;
            }
            set
            {
                _ThoiGianBaoHanh = value;
            }
        }
    }
}
