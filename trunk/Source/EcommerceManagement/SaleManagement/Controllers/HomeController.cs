using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace eCommerceManagement.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Login()
        {
            try
            {
                if (!WebSecurity.Initialized)
                {

                    WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "Email", autoCreateTables: true);

                    if (WebSecurity.IsAuthenticated)
                    {
                        WebSecurity.Logout();
                    }
                }

            }
            catch (Exception e)
            {
                Response.Redirect("~/Error/ServerError?emess=" + e.Message);
            }


            return View();
        }

        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult QuanLyTheLoai()
        {
            return View();
        }

        public ActionResult QuanLyThemTheLoai()
        {
            return View();
        }

        public ActionResult QuanLyCapNhatTheLoai()
        {
            return View();
        }

        public ActionResult QuanLyBanTin()
        {
            return View();
        }

        public ActionResult QuanLyThemBanTin()
        {
            return View();
        }
        public ActionResult QuanLyCapNhatBanTin()
        {
            return View();
        }
        public ActionResult QuanLyDanhMuc()
        {
            return View();
        }

        public ActionResult QuanLyThemNhanVien()
        {
            return View();
        }
        public ActionResult QuanLyCapNhatNhanVien()
        {
            return View();
        }
        public ActionResult QuanLyNhanVien()
        {
            return View();
        }
    }
}
