using DAOs.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAOs;
using DAOs.DTO;
using WebMatrix.WebData;
using Servies.Modules;
using TruyXuatDB.Entities;

namespace SaleManagement.Controllers
{
    public class APIQLDanhMucController : ApiController
    {

        private DanhMucService danhMucService = new DanhMucServiceImpl();

        [HttpPost]
        [AllowAnonymous]
        public Hashtable getDanhSachDanhMuc([FromBody]Request_TimKiem_DanhMucDTO param)
        {
            Hashtable result = new Hashtable();

            List<View_DanhMucDTO> dsTheLoai = danhMucService.getDanhSachDanhMuc(param);

            result.Add("dsDanhMuc", dsTheLoai);

            return result;
        }

        [HttpPost]
        [AllowAnonymous]
        public Hashtable xoaDanhMuc([FromBody]Request_Xoa_DanhMucDTO param)
        {
            Hashtable result = danhMucService.xoaDanhMuc(param);

            return result;
        }

        [HttpPost]
        [AllowAnonymous]
        public Hashtable themDanhMuc([FromBody]Request_Them_DanhMucDTO param)
        {
            Hashtable result = danhMucService.themDanhMuc(param);

            return result;
        }
    }
}