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
    public class KhoHang
    {
        private Guid _KhoHangGuid;

        private Guid _ChiNhanhGuid;

        private String _KhoHangID;

        private String _TenKhoHang;

        private String _DiaChi;

        private String _SoDienThoai;

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

        public String KhoHangID
        {
            get
            {
                return _KhoHangID;
            }
            set
            {
                _KhoHangID = value;
            }
        }

        public String TenKhoHang
        {
            get
            {
                return _TenKhoHang;
            }
            set
            {
                _TenKhoHang = value;
            }
        }

        public String DiaChi
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

        public String SoDienThoai
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
    }
}
