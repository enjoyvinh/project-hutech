﻿using Services.Modules;
using System.Collections;
using System.Web.Http;
using DAOs.DTO;

namespace eCommerceManagement.Controllers
{

    public class APIDangNhapController : ApiController
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
            Hashtable result = dangNhapService.doLogin(param);

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