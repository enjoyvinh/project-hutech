using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
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
    public class View_HoaDonBanHang
    {
        private Guid _HoaDonBanHangGuid;

        private Guid _KhuVucBanHangGuid;

        private Guid _CustomerGuid;

        private Guid _NhanVienGuid;

        private String _SoHoaDon;

        private Decimal _GiaTriDonHang;

        private DateTime _ThoiGianLapPhieu;

        private Decimal _TienVAT;

        private Decimal _TienChietKhau;

        private String _GhiChu;

        private Int32 _TrangThaiHoaDon;
		
		
		public View_HoaDonBanHang(){
			
		HoaDonBanHangGuid=  Guid.Empty;

        KhuVucBanHangGuid= Guid.Empty;

        CustomerGuid=  Guid.Empty;

        NhanVienGuid=  Guid.Empty;

        SoHoaDon=  String.Empty;

        GiaTriDonHang =  Decimal.Zero;

        ThoiGianLapPhieu =  DateTime.Now;

        TienVAT=  Decimal.Zero;

        TienChietKhau=  Decimal.Zero;

        GhiChu=  String.Empty;

        TrangThaiHoaDon= 0;
		}
		public View_HoaDonBanHang(SqlDataReader dataReader){
			
		HoaDonBanHangGuid= dataReader["HoaDonBanHangGuid"] != null ? (Guid)dataReader["HoaDonBanHangGuid"] : Guid.Empty;

        KhuVucBanHangGuid= dataReader["KhuVucBanHangGuid"] != null ? (Guid)dataReader["KhuVucBanHangGuid"] : Guid.Empty;

        CustomerGuid= dataReader["CustomerGuid"] != null ? (Guid)dataReader["CustomerGuid"] : Guid.Empty;

        NhanVienGuid= dataReader["NhanVienGuid"] != null ? (Guid)dataReader["NhanVienGuid"] : Guid.Empty;

        SoHoaDon= dataReader["SoHoaDon"] != null ? (String)dataReader["SoHoaDon"] : String.Empty;

        GiaTriDonHang = dataReader["GiaTriDonHang"] != null ? (Decimal)dataReader["GiaTriDonHang"] : Decimal.Zero;

        ThoiGianLapPhieu = dataReader["ThoiGianLapPhieu"] != null ? (DateTime)dataReader["ThoiGianLapPhieu"] : DateTime.Now;

        TienVAT= dataReader["TienVAT"] != null ? (Decimal)dataReader["TienVAT"] : Decimal.Zero;

        TienChietKhau= dataReader["TienChietKhau"] != null ? (Decimal)dataReader["TienChietKhau"] : Decimal.Zero;

        GhiChu= dataReader["GhiChu"] != null ? (String)dataReader["GhiChu"] : String.Empty;

        TrangThaiHoaDon= dataReader["TrangThaiHoaDon"] != null ? (Int32)dataReader["TrangThaiHoaDon"] : 0;
		}
        public Guid HoaDonBanHangGuid
        {
            get
            {
                return _HoaDonBanHangGuid;
            }
            set
            {
                if (_HoaDonBanHangGuid != value)
                {
                    _HoaDonBanHangGuid = value;
                }
            }
        }

        public Guid KhuVucBanHangGuid
        {
            get
            {
                return _KhuVucBanHangGuid;
            }
            set
            {
                _KhuVucBanHangGuid = value;
            }
        }

        public Guid CustomerGuid
        {
            get
            {
                return _CustomerGuid;
            }
            set
            {
                _CustomerGuid = value;

            }
        }

        public Guid NhanVienGuid
        {
            get
            {
                return _NhanVienGuid;
            }
            set
            {
                _NhanVienGuid = value;
            }
        }

        public String SoHoaDon
        {
            get
            {
                return _SoHoaDon;
            }
            set
            {
                _SoHoaDon = value;
            }
        }

        public Decimal GiaTriDonHang
        {
            get
            {
                return _GiaTriDonHang;
            }
            set
            {
                _GiaTriDonHang = value;
            }
        }
  
        public DateTime ThoiGianLapPhieu
        {
            get
            {
                return _ThoiGianLapPhieu;
            }
            set
            {
                _ThoiGianLapPhieu = value;
            }
        }

        public Decimal TienVAT
        {
            get
            {
                return _TienVAT;
            }
            set
            {
                _TienVAT = value;
            }
        }

        public Decimal TienChietKhau
        {
            get
            {
                return _TienChietKhau;
            }
            set
            {
                _TienChietKhau = value;
            }
        }

        public String GhiChu
        {
            get
            {
                return _GhiChu;
            }
            set
            {
                _GhiChu = value;
            }
        }

        public Int32 TrangThaiHoaDon
        {
            get
            {
                return _TrangThaiHoaDon;
            }
            set
            {
                _TrangThaiHoaDon = value;
            }
        }

    }
}
