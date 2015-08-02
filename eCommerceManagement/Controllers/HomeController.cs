using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerceManagement.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult TrangChu()
        {
            return View();
        }
        public ActionResult ChiTietSanPham(string id)
        {
            Session["MaSanPham"] = id;
            ViewData["MaSanPham"] = id;
            return View();
        }
    }
}