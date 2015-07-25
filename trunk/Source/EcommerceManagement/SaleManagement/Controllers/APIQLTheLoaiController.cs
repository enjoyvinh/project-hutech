//using DAOs.DTO;
//using Services.Modules;
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;
//using WebMatrix.WebData;

//namespace eCommerceManagement.Controllers
//{

//    public class APIQLTheLoaiController : ApiController
//    {
//        TheLoaiService theLoaiService = new TheLoaiService();

//        [HttpPost]
//        [AllowAnonymous]
//        public Hashtable getDanhSachTheLoai([FromBody]Request_QuanLyTheLoai_ParamTimKiem param)
//        {
//            Hashtable result = new Hashtable();

//            List<View_QuanLyTheLoai_TheLoai> dsTheLoai = theLoaiService.getDanhSachTheLoai(param);

//            result.Add("dsTheLoai", dsTheLoai);

//            return result;
//        }

//        [HttpPost]
//        [AllowAnonymous]
//        public Hashtable xoaTheLoai([FromBody]Request_QuanLyTheLoai_ParamXoa param)
//        {
//            Hashtable result = new Hashtable();

//            result = theLoaiService.xoaTheLoai(param);

//            return result;
//        }

//        [HttpPost]
//        [AllowAnonymous]
//        public Hashtable themTheLoai([FromBody]Request_QuanLyTheLoai_ParamThem param)
//        {
//            Hashtable result = new Hashtable();

//            result = theLoaiService.themTheLoai(param);

//            return result;
//        }

//        [HttpPost]
//        [AllowAnonymous]
//        public Hashtable capnhatTheLoai([FromBody]Request_QuanLyTheLoai_ParamCapNhat param)
//        {
//            Hashtable result = new Hashtable();

//            result = theLoaiService.capnhatTheLoai(param);

//            return result;
//        }

//        [HttpPost]
//        [AllowAnonymous]
//        public Hashtable getChiTietTheLoai([FromBody]Request_QuanLyTheLoai_ParamTimKiem param)
//        {
//            Hashtable result = new Hashtable();

//            View_QuanLyTheLoai_TheLoai ctTheLoai = theLoaiService.getChiTietTheLoai(param);

//            result.Add("ctTheLoai", ctTheLoai);

//            return result;
//        }

//    }
//}