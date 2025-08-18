using System;
using System.Web;
/*
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Mvc.Filters;
using System.Web.Routing;

using Rcbi.Core;
using Rcbi.Core.Infrastructure;
using Rcbi.Framework.Response;
using Rcbi.Framework.Resource;
using Rcbi.Common.Enums;
using Rcbi.Common.Extensions;
using Rcbi.Common;*/
using System.IO;
using System.Globalization;

namespace Rcbi.Framework.Controllers
{
    /*
    public abstract class BaseAuthController : BaseController
    {
        private const int maxSize = 1024 * 1024 * 4;
        private const string savePath = "/temp/";
        private static readonly string DisableAuth = ConfigManager.AppSettings["disableAuth"];

        protected IWorkContext WorkContext;

        protected override void Initialize(RequestContext requestContext)
        {
            this.WorkContext = EngineContext.Current.Resolve<IWorkContext>();
            ViewBag.User = this.WorkContext.CurrentUser;
            base.Initialize(requestContext);
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.Exception != null)
                LogException(filterContext.Exception);
            base.OnException(filterContext);
        }

        private void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = this.Request.IsAjaxRequest() ?
                this.AjaxError(Resource.GetResource(ResourceKeys.SYS_LOGIN_TIMEOUT)) : new RedirectResult(FormsAuthentication.LoginUrl + "?returnUrl=" + HttpUtility.UrlEncode(this.Request.Url.AbsoluteUri)); 
        }

        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext == null)
                throw new ArgumentNullException("filterContext");

            if (filterContext.IsChildAction)
                return;

            if (!this.AllowAccess(filterContext)) 
                this.HandleUnauthorizedRequest(filterContext);
           
        }

        public virtual bool AllowAccess(AuthorizationContext filterContext)
        {
            bool disableAuth = false;
            if (bool.TryParse(DisableAuth, out disableAuth) && disableAuth == true)
                return true;
           
            return WorkContext != null && WorkContext.CurrentUser != null;
        }

        /// <summary>
        /// 上传到临时文件夹
        /// </summary>
        /// <param name="postedFile"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static bool UploadToTempFile(HttpPostedFileBase postedFile, ref string message)
        {
            byte[] file;
            string localname = string.Empty,
                   inputname = string.Empty;

            HttpPostedFileBase postedfile = postedFile;

            // 读取原始文件名
            localname = postedfile.FileName;
            // 初始化byte长度.
            file = new Byte[postedfile.ContentLength];

            // 转换为byte类型
            System.IO.Stream stream = postedfile.InputStream;
            stream.Read(file, 0, postedfile.ContentLength);
            stream.Close();

            var resource = EngineContext.Current.Resolve<IResourceService>();

            if (file.Length == 0)
            {
                message = resource.GetResource(ResourceKeys.UPLOAD_FILE_EMPTY);
                return false;
            }

            var rootPath = System.Web.HttpContext.Current.Server.MapPath(savePath);
            if (!Directory.Exists(rootPath))
            {
                message = resource.GetResource(ResourceKeys.UPLOAD_DIR_NOTEXISTS);
                return false;
            }

            if (file.Length > maxSize)
            {
                message = resource.GetResource(ResourceKeys.UPLOAD_MAX_SIZE);
                return false;
            }

            String fileExt = Path.GetExtension(localname).ToLower();

            String ymd = DateTime.Now.ToString("yyyyMMdd", DateTimeFormatInfo.InvariantInfo);
            var dirPath = rootPath + ymd + "/";

            try
            {
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }
                String fileName = Path.GetFileNameWithoutExtension(localname);
                string CreateFile = DateTime.Now.ToString("yyyyMMddHHmmss_ffff", DateTimeFormatInfo.InvariantInfo);
                String newFileName = CreateFile + "_" + fileName + fileExt;
                String filePath = dirPath + newFileName;

                FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                fs.Write(file, 0, file.Length);
                fs.Flush();
                fs.Close();

                message = filePath;
                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }
    }*/
}
