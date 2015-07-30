using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace eCommerceManagement.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult NotFound()
        {
            Response.StatusCode = (int)HttpStatusCode.NotFound;
            return View();
        }

        public ActionResult ServerError()
        {
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return View();
        }

        public ActionResult ThrowError()
        {
            throw new NotImplementedException("Pew ^ Pew");
        }
    }
}
