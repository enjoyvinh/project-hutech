using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.ComponentModel;
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
    public class View_Customer
    {
        private Guid _CustomerGuid;

        private Guid _CustomerGroupGuid;

        private String _Ho;

        private String _DiaChi;

        private String _DienThoai;

        private String _Email;

        private Int32 _Phai;

        private String _DiaChiNhanHang;

        private DateTime _NgayTao;

        private String _Ten;

        private String _TenLot;
		
		public View_Customer()
		{
			CustomerGuid  = Guid.Empty;
			CustomerGroupGuid  =  Guid.Empty;
			Ho =  String.Empty;
			DiaChi =  String.Empty;
			DienThoai = String.Empty;
			Email =  String.Empty;
			Phai =  0;
			DiaChiNhanHang = String.Empty;
			NgayTao = DateTime.Now;
			Ten =  String.Empty;
			TenLot = String.Empty;
		}
		
		public View_Customer(SqlDataReader dataReader)
		{
			CustomerGuid  = dataReader["CustomerGuid"] != null ? (Guid)dataReader["CustomerGuid"] : Guid.Empty;
			CustomerGroupGuid  = dataReader["CustomerGroupGuid"] != null ? (Guid)dataReader["CustomerGroupGuid"] : Guid.Empty;
			Ho = dataReader["Ho"] != null ? (String)dataReader["Ho"] : String.Empty;
			DiaChi = dataReader["DiaChi"] != null ? (String)dataReader["DiaChi"] : String.Empty;
			DienThoai = dataReader["DienThoai"] != null ? (String)dataReader["DienThoai"] : String.Empty;
			Email = dataReader["Email"] != null ? (String)dataReader["Email"] : String.Empty;
			Phai = dataReader["Phai"] != null ? (Int32)dataReader["Phai"] : 0;
			DiaChiNhanHang = dataReader["DiaChiNhanHang"] != null ? (String)dataReader["DiaChiNhanHang"] : String.Empty;
            NgayTao = dataReader["NgayTao"] != null ? (DateTime)dataReader["NgayTao"] : DateTime.Now;
			Ten = dataReader["Ten"] != null ? (String)dataReader["Ten"] : String.Empty;
			TenLot = dataReader["TenLot"] != null ? (String)dataReader["TenLot"] : String.Empty;
		}
		
		

        public Guid CustomerGuid
        {
            get
            {
                return _CustomerGuid;
            }
            set
            {
                    _CustomerGuid = value;
            }
        }

        public Guid CustomerGroupGuid
        {
            get
            {
                return _CustomerGroupGuid;
            }
            set
            {
                _CustomerGroupGuid = value;
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

        public String DiaChiNhanHang
        {
            get
            {
                return _DiaChiNhanHang;
            }
            set
            {
                _DiaChiNhanHang = value;
            }
        }

        public DateTime NgayTao
        {
            get
            {
                return _NgayTao;
            }
            set
            {
                _NgayTao = value;
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
    }
}
