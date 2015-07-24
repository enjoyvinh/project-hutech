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
    public class VIew_PhieuXuatKho
    {
        private Guid _PhieuXuatKhoGuid;

        private Guid _HoaDonBanHangGuid;

        private Guid _NhanVienGuid;

        private Guid _KhoHangGuid;

        private String _SoPhieu;

        private DateTime _ThoiGianLapPhieu;
		
		public VIew_PhieuXuatKho(){
			
		PhieuXuatKhoGuid=  Guid.Empty;

        HoaDonBanHangGuid=  Guid.Empty;

        NhanVienGuid=  Guid.Empty;

        KhoHangGuid=  Guid.Empty;

        SoPhieu=  String.Empty;

        ThoiGianLapPhieu= DateTime.Now;
		}
		public VIew_PhieuXuatKho(SqlDataReader dataReader){
			
		PhieuXuatKhoGuid= dataReader["PhieuXuatKhoGuid"] != null ? (Guid)dataReader["PhieuXuatKhoGuid"] : Guid.Empty;

        HoaDonBanHangGuid= dataReader["HoaDonBanHangGuid"] != null ? (Guid)dataReader["HoaDonBanHangGuid"] : Guid.Empty;

        NhanVienGuid= dataReader["NhanVienGuid"] != null ? (Guid)dataReader["NhanVienGuid"] : Guid.Empty;

        KhoHangGuid= dataReader["KhoHangGuid"] != null ? (Guid)dataReader["KhoHangGuid"] : Guid.Empty;

        SoPhieu= dataReader["SoPhieu"] != null ? (String)dataReader["SoPhieu"] : String.Empty;

        ThoiGianLapPhieu= dataReader["ThoiGianLapPhieu"] != null ? (DateTime)dataReader["ThoiGianLapPhieu"] : DateTime.Now;
		}
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
