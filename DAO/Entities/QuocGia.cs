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
    public class QuocGia
    {
        private Guid _QuocGiaGuid;

        private String _MaQuocGia;

        private String _TenVietTat;

        private String _TenQuocGia;

        private String _DinhDangSo;

        private String _DinhDangTienTe;

        private String _DinhDangNgayThang;

        private String _URLCoQuocGia;

        private Boolean _TrangThai;
 
        public Guid QuocGiaGuid
        {
            get
            {
                return _QuocGiaGuid;
            }
            set
            {
                    _QuocGiaGuid = value;
            }
        }

        public String MaQuocGia
        {
            get
            {
                return _MaQuocGia;
            }
            set
            {
                _MaQuocGia = value;
            }
        }

        public String TenVietTat
        {
            get
            {
                return _TenVietTat;
            }
            set
            {
                _TenVietTat = value;
            }
        }

        public String TenQuocGia
        {
            get
            {
                return _TenQuocGia;
            }
            set
            {
                _TenQuocGia = value;
            }
        }

        public String DinhDangSo
        {
            get
            {
                return _DinhDangSo;
            }
            set
            {
                _DinhDangSo = value;
            }
        }

        public String DinhDangTienTe
        {
            get
            {
                return _DinhDangTienTe;
            }
            set
            {
                _DinhDangTienTe = value;
            }
        }

        public String DinhDangNgayThang
        {
            get
            {
                return _DinhDangNgayThang;
            }
            set
            {
                _DinhDangNgayThang = value;
            }
        }

        public String URLCoQuocGia
        {
            get
            {
                return _URLCoQuocGia;
            }
            set
            {
                _URLCoQuocGia = value;
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
