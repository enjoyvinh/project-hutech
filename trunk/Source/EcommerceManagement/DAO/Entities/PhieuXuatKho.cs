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
    public class PhieuXuatKho
    {
        private Guid _PhieuXuatKhoGuid;

        private Guid _HoaDonBanHangGuid;

        private Guid _NhanVienGuid;

        private Guid _KhoHangGuid;

        private String _SoPhieu;

        private DateTime _ThoiGianLapPhieu;

        public Guid PhieuXuatKhoGuid
        {
            get
            {
                return _PhieuXuatKhoGuid;
            }
            set
            {
                _PhieuXuatKhoGuid = value;
            }
        }

        public Guid HoaDonBanHangGuid
        {
            get
            {
                return _HoaDonBanHangGuid;
            }
            set
            {
                _HoaDonBanHangGuid = value;
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

        public String SoPhieu
        {
            get
            {
                return _SoPhieu;
            }
            set
            {
                _SoPhieu = value;
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
    }
}
