/*
using System;
using System.Web.Mvc;

using Rcbi.Framework.Resource;

namespace Rcbi.Framework.Controllers
{
    public partial class CommonController : BasePublicController
    {
        //header links
        [ChildActionOnly]
        public ActionResult HeaderLinks()
        {
            return PartialView();
        }
        [ChildActionOnly]
        public ActionResult AdminHeaderLinks()
        {
            return PartialView();
        }

        //footer
        [ChildActionOnly]
        public ActionResult Footer()
        {
            return PartialView();
        }
        //page not found
        public ActionResult PageNotFound()
        {
            this.Response.StatusCode = 404;
            this.Response.TrySkipIisCustomErrors = true;

            return View();
        }
        //error page
        public ActionResult Error() 
        {
            this.Response.StatusCode = 500;
            this.Response.TrySkipIisCustomErrors = true;

            return View();
        }
        //access denied 
        public ActionResult AccessDenied()
        {
            this.Response.StatusCode = 400;
            this.Response.TrySkipIisCustomErrors = true;

            if (this.Request.IsAjaxRequest()) {
                return Json(new {
                    code = 1,
                    msg = this.Resource.GetResource(ResourceKeys.COMMON_AUTH_ACCESSDENIED)
                }, 
                JsonRequestBehavior.AllowGet);
            }

            return View();
        }

        [ChildActionOnly]
        public ActionResult Favicon()
        {
            return PartialView();
        }
    }
}
*/