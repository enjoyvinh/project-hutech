using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Runtime.Serialization;
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
    public class View_ChiNhanhCongTy
    {
        private Guid _ChiNhanhGuid;

        private Guid _TinhThanhPhoGuid;

        private String _ChiNhanhID;

        private String _TenChiNhanh;

        private String _DiaChi;

        private String _SoDienThoai;

        private Boolean _TrangThai;

        public View_ChiNhanhCongTy()
        {
            ChiNhanhGuid = Guid.Empty;
            TinhThanhPhoGuid = Guid.Empty;
            ChiNhanhID = String.Empty;
            TenChiNhanh = String.Empty;
            DiaChi = String.Empty;
            SoDienThoai = String.Empty;
            TrangThai = true;
        }

        public View_ChiNhanhCongTy(SqlDataReader dataReader)
        {
            ChiNhanhGuid = dataReader["ChiNhanhGuid"] != null ? (Guid)dataReader["ChiNhanhGuid"] : Guid.Empty;
            TinhThanhPhoGuid = dataReader["TinhThanhPhoGuid"] != null ? (Guid)dataReader["TinhThanhPhoGuid"] : Guid.Empty;
            ChiNhanhID = dataReader["ChiNhanhID"] != null ? (String)dataReader["ChiNhanhID"] : String.Empty;
            TenChiNhanh = dataReader["ChiNhanhID"] != null ? (String)dataReader["ChiNhanhID"] : String.Empty;
            DiaChi = dataReader["ChiNhanhID"] != null ? (String)dataReader["ChiNhanhID"] : String.Empty;
            SoDienThoai = dataReader["ChiNhanhID"] != null ? (String)dataReader["ChiNhanhID"] : String.Empty;
            TrangThai = dataReader["TrangThai"] != null ? (Boolean)dataReader["TrangThai"] : true;
        }

        public Guid ChiNhanhGuid
        {
            get
            {
                return _ChiNhanhGuid;
            }
            set
            {
                _ChiNhanhGuid = value;
            }
        }

        public Guid TinhThanhPhoGuid
        {
            get
            {
                return _TinhThanhPhoGuid;
            }
            set
            {
                _TinhThanhPhoGuid = value;
            }
        }

        public String ChiNhanhID
        {
            get
            {
                return _ChiNhanhID;
            }
            set
            {
                _ChiNhanhID = value;
            }
        }

        public String TenChiNhanh
        {
            get
            {
                return _TenChiNhanh;
            }
            set
            {
                _TenChiNhanh = value;
            }
        }

        public global::System.String DiaChi
        {
            get
            {
                return _DiaChi;
            }
            set
            {
                _DiaChi = value;
            }
        }

        public global::System.String SoDienThoai
        {
            get
            {
                return _SoDienThoai;
            }
            set
            {
                _SoDienThoai = value;
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
