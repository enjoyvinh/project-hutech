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
    public class KhuVucBanHang
    {
        private Guid _KhuVucBanHangGuid;

        private String _KhuVucBanName;

        private String _KhuVucBanID;

        private Guid _KhuVucChaGuid;

        private String _KhuVucChaID;

        private String _KhuVucChaName;

        private String _LuuVetKhuVucGuid;

        private String _LuuVetKhuVucID;

        private String _LuuVetKhuVucName;

        private Boolean _TrangThai;

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

        public String KhuVucBanName
        {
            get
            {
                return _KhuVucBanName;
            }
            set
            {
                _KhuVucBanName = value;
            }
        }

        public String KhuVucBanID
        {
            get
            {
                return _KhuVucBanID;
            }
            set
            {
                _KhuVucBanID = value;
            }
        }

        public Guid KhuVucChaGuid
        {
            get
            {
                return _KhuVucChaGuid;
            }
            set
            {
                _KhuVucChaGuid = value;
            }
        }

        public String KhuVucChaID
        {
            get
            {
                return _KhuVucChaID;
            }
            set
            {
                _KhuVucChaID = value;
            }
        }

        public String KhuVucChaName
        {
            get
            {
                return _KhuVucChaName;
            }
            set
            {
                _KhuVucChaName = value;
            }
        }

        public String LuuVetKhuVucGuid
        {
            get
            {
                return _LuuVetKhuVucGuid;
            }
            set
            {
                _LuuVetKhuVucGuid = value;
            }
        }

        public String LuuVetKhuVucID
        {
            get
            {
                return _LuuVetKhuVucID;
            }
            set
            {
                _LuuVetKhuVucID = value;
            }
        }

        public String LuuVetKhuVucName
        {
            get
            {
                return _LuuVetKhuVucName;
            }
            set
            {
                _LuuVetKhuVucName = value;
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
