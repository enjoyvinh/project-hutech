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
    public class HoaDonBanHang
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
