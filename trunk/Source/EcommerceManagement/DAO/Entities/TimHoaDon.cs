using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruyXuatDB.Entities
{
    public class TimHoaDon
    {
        private DateTime tuNgay;

        private DateTime denNgay;

        private Guid khuVucBanHangGuid;

        private Guid customerGuid;

        private Guid nhanVienGuid;

        private Decimal tuTongTien;

        private Decimal denTongTien;

        public DateTime TuNgay
        {
            get
            {
                return tuNgay;
            }
            set
            {
                tuNgay = value;
            }
        }

        public DateTime DenNgay
        {
            get
            {
                return denNgay;
            }
            set
            {
                denNgay = value;
            }
        }

        public Guid KhuVucBanHangGuid
        {
            get
            {
                return khuVucBanHangGuid;
            }
            set
            {
                khuVucBanHangGuid = value;
            }
        }

        public Guid CustomerGuid
        {
            get
            {
                return customerGuid;
            }
            set
            {
                customerGuid = value;
            }
        }

        public Guid NhanVienGuid
        {
            get
            {
                return nhanVienGuid;
            }
            set
            {
                nhanVienGuid = value;
            }
        }

        public Decimal TuTongTien
        {
            get
            {
                return tuTongTien;
            }
            set
            {
                tuTongTien = value;
            }
        }

        public Decimal DenTongTien
        {
            get
            {
                return denTongTien;
            }
            set
            {
                denTongTien = value;
            }
        }
    }
}
