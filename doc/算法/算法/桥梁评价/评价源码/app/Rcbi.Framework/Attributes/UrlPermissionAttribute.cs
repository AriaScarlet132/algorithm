using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Rcbi.Framework.Attributes
{
    public class UrlPermissionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            /*
            if (filterContext.IsChildAction)
                return;

            var workContext = EngineContext.Current.Resolve<IWorkContext>();

            if (workContext.CurrentUser == null)
                return;

            var baseController = filterContext.Controller as BaseWebController;

            if (baseController == null)
                return;
            
            var url = filterContext.HttpContext.Request.Url.AbsolutePath;

            if (url.EndsWith("/"))
                url = url.Remove(url.Length - 1);

            //项目角色权限和非项目角色只要有一个有权限即可。
            var allowAccess = baseController.CurrentProject != null ?
                             MenuBll.IsUserHasMenu(workContext.CurrentUser, url, baseController.CurrentProject.ProjectId) || MenuBll.IsUserHasMenu(workContext.CurrentUser, url) :
                             MenuBll.IsUserHasMenu(workContext.CurrentUser, url);


            if (!allowAccess) {
                var routeData = new RouteData();
                routeData.Values.Add("controller", "Common");
                routeData.Values.Add("action", "AccessDenied");
                filterContext.Result = new ContentResult();
                IController controller = EngineContext.Current.Resolve<CommonController>();
                controller.Execute(new RequestContext(filterContext.HttpContext, routeData));
            }
            */
            //allow access
        }
    }
}
