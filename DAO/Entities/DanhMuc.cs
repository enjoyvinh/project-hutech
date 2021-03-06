﻿using System;
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
    public class DanhMuc
    {
        private Guid _DanhMucGuid;

        private Int32 _DanhMucID;

        private String _DanhMucName;

        private Boolean _TrangThai;

        private String _LuuVetDanhMucGuid;

        private String _LuuVetDanhMucID;

        private String _LuuVetDanhMucName;

        private Guid _DanhMucChaGuid;

        private String _DanhMucChaName;

        private String _URLHinhAnh;

        public Guid DanhMucGuid
        {
            get
            {
                return _DanhMucGuid;
            }
            set
            {
                    _DanhMucGuid = value;
            }
        }

        public Int32 DanhMucID
        {
            get
            {
                return _DanhMucID;
            }
            set
            {
                _DanhMucID = value;
            }
        }

        public String DanhMucName
        {
            get
            {
                return _DanhMucName;
            }
            set
            {
                _DanhMucName = value;
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

        public String LuuVetDanhMucGuid
        {
            get
            {
                return _LuuVetDanhMucGuid;
            }
            set
            {
                _LuuVetDanhMucGuid = value;
            }
        }

        public String LuuVetDanhMucID
        {
            get
            {
                return _LuuVetDanhMucID;
            }
            set
            {
                _LuuVetDanhMucID = value;
            }
        }

        public String LuuVetDanhMucName
        {
            get
            {
                return _LuuVetDanhMucName;
            }
            set
            {
                _LuuVetDanhMucName = value;
            }
        }

        public Guid DanhMucChaGuid
        {
            get
            {
                return _DanhMucChaGuid;
            }
            set
            {
                _DanhMucChaGuid = value;
            }
        }

        public String DanhMucChaName
        {
            get
            {
                return _DanhMucChaName;
            }
            set
            {
                _DanhMucChaName = value;
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
