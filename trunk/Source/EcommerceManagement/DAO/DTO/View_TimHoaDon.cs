using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAOs.DTO
{
    public class View_TimHoaDon
    {
        private DateTime tuNgay;

        private DateTime denNgay;

        private Guid khuVucBanHangGuid;

        private Guid customerGuid;

        private Guid nhanVienGuid;

        private Decimal tuTongTien;

        private Decimal denTongTien;
		
		public View_TimHoaDon(){
			
		tuNgay=  DateTime.Now;

        denNgay=  DateTime.Now;

        khuVucBanHangGuid=  Guid.Empty;

        customerGuid=  Guid.Empty;

        nhanVienGuid=  Guid.Empty;

        tuTongTien=  Decimal.Zero;

        denTongTien=  Decimal.Zero;
		}
		public View_TimHoaDon(SqlDataReader dataReader){
			
		tuNgay= dataReader["tuNgay"] != null ? (DateTime)dataReader["tuNgay"] : DateTime.Now;

        denNgay= dataReader["denNgay"] != null ? (DateTime)dataReader["denNgay"] : DateTime.Now;

        khuVucBanHangGuid= dataReader["khuVucBanHangGuid"] != null ? (Guid)dataReader["khuVucBanHangGuid"] : Guid.Empty;

        customerGuid= dataReader["customerGuid"] != null ? (Guid)dataReader["customerGuid"] : Guid.Empty;

        nhanVienGuid= dataReader["nhanVienGuid"] != null ? (Guid)dataReader["nhanVienGuid"] : Guid.Empty;

        tuTongTien= dataReader["tuTongTien"] != null ? (Decimal)dataReader["tuTongTien"] : Decimal.Zero;

        denTongTien= dataReader["denTongTien"] != null ? (Decimal)dataReader["denTongTien"] : Decimal.Zero;
		}
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
