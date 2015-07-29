using Services.Modules;
using System.Collections;
using System.Web.Http;
using DAOs.DTO;
using System;

namespace eCommerceManagement.Controllers
{

    public class API_HeThong_DangNhapController : ApiController
    {
        DangNhapService dangNhapService = new DangNhapService();

        // POST api/<controller>
        [HttpPost]
        [AllowAnonymous]
        public Hashtable doLogin([FromBody]DtoControllerDangNhap param)
        {
            //WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "Email",false);
            //WebSecurity.CreateUserAndAccount("manager@skyfire.vn", "123@abc");
            //System.Web.Security.Roles.CreateRole("administrator");
            //System.Web.Security.Roles.CreateRole("manager");
            //System.Web.Security.Roles.CreateRole("sales");
            //System.Web.Security.Roles.CreateRole("storekeepers");

            //System.Web.Security.Roles.AddUserToRole("manager@skyfire.vn", "administrator");
            //Hashtable result = dangNhapService.doLogin(param);

            Hashtable result = new Hashtable();
            result.Add("SUCCESS", "Thành Công");
            result.Add("TaiKhoanNhanVien", "manager@skyfire.vn");
            result.Add("TenNhanVien", "Thành Vinh");
            result.Add("PhanQuyen", "99");
            result.Add("ThoiGianDangNhap", DateTime.Now);

            return result;
        }

        [HttpPost]
        [AllowAnonymous]
        public Hashtable doLogout()
        {
            Hashtable result = dangNhapService.doLogout();

            return result;
        }


    }
}