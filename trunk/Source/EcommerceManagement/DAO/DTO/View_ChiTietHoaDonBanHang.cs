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
    public class View_ChiTietHoaDonBanHang
    {
        private Guid _HoaDonBanHangGuid;

        private Guid _ItemSaleGuid;

        private Int32 _SoLuong;

        private Decimal _DonGia;

        private Decimal _TienChietKhau;

        private Int32 _ThoiGianBaoHanh;

        public View_ChiTietHoaDonBanHang()
        {
            HoaDonBanHangGuid = Guid.Empty;
            ItemSaleGuid = Guid.Empty;
            SoLuong = 0;
            DonGia = Decimal.Zero;
            TienChietKhau = Decimal.Zero;
            ThoiGianBaoHanh = 0;
        }

        public View_ChiTietHoaDonBanHang(SqlDataReader dataReader)
        {
            HoaDonBanHangGuid = dataReader["HoaDonBanHangGuid"] != null ? (Guid)dataReader["HoaDonBanHangGuid"] : Guid.Empty;
            ItemSaleGuid = dataReader["ItemSaleGuid"] != null ? (Guid)dataReader["ItemSaleGuid"] : Guid.Empty;
            SoLuong = dataReader["SoLuong"] != null ? (Int32)dataReader["SoLuong"] : 0;
            DonGia = dataReader["DonGia"] != null ? (Decimal)dataReader["DonGia"] : Decimal.Zero;
            TienChietKhau = dataReader["TienChietKhau"] != null ? (Decimal)dataReader["TienChietKhau"] : Decimal.Zero;
            ThoiGianBaoHanh = dataReader["ThoiGianBaoHanh"] != null ? (Int32)dataReader["ThoiGianBaoHanh"] : 0;
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

        public Int32 SoLuong
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

        public Decimal DonGia
        {
            get
            {
                return _DonGia;
            }
            set
            {
                _DonGia = value;
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
