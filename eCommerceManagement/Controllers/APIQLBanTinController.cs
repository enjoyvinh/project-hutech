//using DAOs.DTO;
//using Services.Modules;
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Configuration;
//using System.IO;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Threading.Tasks;
//using System.Web;
//using System.Web.Http;
//using WebMatrix.WebData;

//namespace eCommerceManagement.Controllers
//{

//    public class APIQLBanTinController : ApiController
//    {
//        BanTinService banTinService = new BanTinService();

//        [HttpPost]
//        [AllowAnonymous]
//        public Hashtable getDanhSachBanTin([FromBody]Request_QuanLyBanTin_ParamTimKiem param)
//        {
//            Hashtable result = new Hashtable();

//            List<View_QuanLyBanTin_BanTin> dsBanTin = banTinService.getDanhSachBanTin(param);

//            result.Add("dsBanTin", dsBanTin);

//            return result;
//        }

//        [HttpPost]
//        [AllowAnonymous]
//        public Hashtable themBanTin([FromBody]Request_QuanLyBanTin_ParamThem param)
//        {
//            Hashtable result = new Hashtable();

//            FileInfo finfo = (FileInfo)param.Attachment;

//            //var httpPostedFile = HttpContext.Current.Request.Files["UploadedImage"];

//            result = banTinService.themBanTin(param);

//            return result;
//        }

//        [HttpPost]
//        [AllowAnonymous]
//        public Hashtable xoaBanTin([FromBody]Request_QuanLyBanTin_ParamXoa param)
//        {
//            Hashtable result = new Hashtable();

//            result = banTinService.xoaBanTin(param);

//            return result;
//        }

//        [HttpPost]
//        [AllowAnonymous]
//        public Task<HttpResponseMessage> Upload(Object param)
//        {
//            HttpRequestMessage request = this.Request;
//            if (!request.Content.IsMimeMultipartContent())
//            {
//                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.UnsupportedMediaType));
//            }

//            string root = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/uploads");
//            var provider = new MultipartFormDataStreamProvider(root);

//            var task = request.Content.ReadAsMultipartAsync(provider).
//                ContinueWith<HttpResponseMessage>(o =>
//                {
//                    FileInfo finfo = new FileInfo(provider.FileData.First().LocalFileName);

//                    string guid = Guid.NewGuid().ToString();

//                    File.Move(finfo.FullName, Path.Combine(root, guid + "_" + provider.FileData.First().Headers.ContentDisposition.FileName.Replace("\"", "")));

//                    return new HttpResponseMessage()
//                    {
//                        Content = new StringContent("File uploaded.")
//                    };
//                }
//            );
//            return task;
//        }

//        [HttpPost]
//        [AllowAnonymous]
//        public Hashtable getChiTietBanTin([FromBody]Request_QuanLyBanTin_ParamTimKiem param)
//        {
//            Hashtable result = new Hashtable();

//            View_QuanLyBanTin_BanTin ctTheLoai = banTinService.getChiTietBanTin(param);

//            result.Add("ctBanTin", ctTheLoai);

//            return result;
//        }

//        [HttpPost]
//        [AllowAnonymous]
//        public Hashtable capnhatBanTin([FromBody]Request_QuanLyBanTin_ParamCapNhat param)
//        {
//            Hashtable result = new Hashtable();

//            result = banTinService.capnhatTheLoai(param);

//            return result;
//        }
//    }
//}