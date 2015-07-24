using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Xml.Serialization;
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
    public class ChiTietPhieuXuatKho
    {
        private Guid _PhieuXuatKhoGuid;

        private Guid _ItemStoreGuid;

        private Guid _HoaDonBanHangGuid;

        private Decimal _SoLuong;

        public ChiTietPhieuXuatKho()
        {
            PhieuXuatKhoGuid = Guid.Empty;
            ItemStoreGuid = Guid.Empty;
            HoaDonBanHangGuid = Guid.Empty;
            SoLuong = Decimal.Zero;
        }
        public ChiTietPhieuXuatKho(SqlDataReader dataReader)
        {
            PhieuXuatKhoGuid = dataReader["PhieuXuatKhoGuid"] != null ? (Guid)dataReader["PhieuXuatKhoGuid"] : Guid.Empty;
            ItemStoreGuid = dataReader["ItemStoreGuid"] != null ? (Guid)dataReader["ItemStoreGuid"] : Guid.Empty;
            HoaDonBanHangGuid = dataReader["HoaDonBanHangGuid"] != null ? (Guid)dataReader["HoaDonBanHangGuid"] : Guid.Empty;
            SoLuong = dataReader["SoLuong"] != null ? (Int32)dataReader["SoLuong"] : 0;
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
