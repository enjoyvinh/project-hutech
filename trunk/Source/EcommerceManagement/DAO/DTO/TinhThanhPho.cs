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

namespace DAOs.DTO
{
    public class TinhThanhPho
    {
        private Guid _TinhThanhPhoGuid;

        private Guid _QuocGiaGuid;

        private String _MaTinh;

        private String _TenTinh;

        private Boolean _TrangThai;

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

        public String MaTinh
        {
            get
            {
                return _MaTinh;
            }
            set
            {
                _MaTinh = value;
            }
        }

        public String TenTinh
        {
            get
            {
                return _TenTinh;
            }
            set
            {
                _TenTinh = value;
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
