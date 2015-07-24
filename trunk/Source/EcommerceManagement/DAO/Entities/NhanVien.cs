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
    public class NhanVien
    {
        private Guid _NhanVienGuid;

        private String _MaNhanVien;

        private String _Ho;

        private String _Ten;

        private String _TenLot;

        private DateTime _NgaySinh;

        private String _SoCMND;

        private Int32 _Phai;

        private String _DiaChiLienHe;

        private String _DienThoai;

        private String _Email;

        private String _URLHinhAnh;

        private Int32 _UserId;

        public Int32 UserId
        {
            get
            {
                return _UserId;
            }
            set
            {
                _UserId = value;
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

        public String MaNhanVien
        {
            get
            {
                return _MaNhanVien;
            }
            set
            {
                _MaNhanVien = value;
            }
        }

        public String Ho
        {
            get
            {
                return _Ho;
            }
            set
            {
                _Ho = value;
            }
        }

        public String Ten
        {
            get
            {
                return _Ten;
            }
            set
            {
                _Ten = value;
            }
        }

        public String TenLot
        {
            get
            {
                return _TenLot;
            }
            set
            {
                _TenLot = value;
            }
        }

        public DateTime NgaySinh
        {
            get
            {
                return _NgaySinh;
            }
            set
            {
                _NgaySinh = value;
            }
        }

        public String SoCMND
        {
            get
            {
                return _SoCMND;
            }
            set
            {
                _SoCMND = value;
            }
        }

        public Int32 Phai
        {
            get
            {
                return _Phai;
            }
            set
            {
                _Phai = value;
            }
        }

        public String DiaChiLienHe
        {
            get
            {
                return _DiaChiLienHe;
            }
            set
            {
                _DiaChiLienHe = value;
            }
        }

        public String DienThoai
        {
            get
            {
                return _DienThoai;
            }
            set
            {
                _DienThoai = value;
            }
        }

        public String Email
        {
            get
            {
                return _Email;
            }
            set
            {
                _Email = value;
            }
        }

        public String URLHinhAnh
        {
            get
            {
                return _URLHinhAnh;
            }
            set
            {
                _URLHinhAnh = value;
            }
        }
    }
}
