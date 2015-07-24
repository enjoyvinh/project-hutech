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
    public class View_DanhMucDTO
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

        public View_DanhMucDTO()
        {

            DanhMucGuid = Guid.Empty;

            DanhMucID = 0;

            DanhMucName = String.Empty;

            TrangThai = true;

            LuuVetDanhMucGuid = String.Empty;

            LuuVetDanhMucID = String.Empty;

            LuuVetDanhMucName = String.Empty;

            DanhMucChaGuid = Guid.Empty;

            DanhMucChaName = String.Empty;

            URLHinhAnh = String.Empty;
        }

        public View_DanhMucDTO(SqlDataReader dataReader)
        {

            DanhMucGuid = dataReader["DanhMucGuid"] != null ? (Guid)dataReader["DanhMucGuid"] : Guid.Empty;
            DanhMucID = dataReader["DanhMucID"] != null ? (Int32)dataReader["DanhMucID"] : 0;
            DanhMucName = dataReader["DanhMucName"] != null ? (String)dataReader["DanhMucName"] : String.Empty;
            TrangThai = dataReader["TrangThai"] != null ? (Boolean)dataReader["TrangThai"] : true;
            //LuuVetDanhMucGuid = dataReader["LuuVetDanhMucGuid"] != null ? (String)dataReader["LuuVetDanhMucGuid"] : String.Empty;
            //LuuVetDanhMucID = dataReader["LuuVetDanhMucID"] != null ? (String)dataReader["LuuVetDanhMucID"] : String.Empty;
            //LuuVetDanhMucName = dataReader["LuuVetDanhMucName"] != null ? (String)dataReader["LuuVetDanhMucName"] : String.Empty;
            //DanhMucChaGuid = dataReader["DanhMucChaGuid"] != null ? (Guid)dataReader["DanhMucChaGuid"] : Guid.Empty;
            //DanhMucChaName = dataReader["DanhMucChaName"] != null ? (String)dataReader["DanhMucChaName"] : String.Empty;
            //URLHinhAnh = dataReader["URLHinhAnh"] != null ? (String)dataReader["URLHinhAnh"] : String.Empty;
        }

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
