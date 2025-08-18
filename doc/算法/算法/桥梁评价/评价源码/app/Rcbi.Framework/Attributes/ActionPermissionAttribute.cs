using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Rcbi.Framework.Attributes
{
    public class ActionPermissionAttribute : ActionFilterAttribute
    {
        private string _action;
        private string _url;
        public ActionPermissionAttribute(string action, string url = null) : 
            base()
        {
            this._action = action;
            this._url = url;
        }

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
            
            if (this._url.IsNullOrEmpty()) {
                this._url = filterContext.HttpContext.Request.Url.AbsolutePath;
                var action = "/" + this._action;
                if (this._url.EndsWith(action)) {
                    this._url = this._url.Remove(this._url.Length - action.Length);
                }
            }
            
            //项目角色权限和非项目角色权限有一个即可
            var allowAccess = baseController.CurrentProject != null ?
                     MenuBll.IsUserHasAction(workContext.CurrentUser, this._url, this._action, baseController.CurrentProject.ProjectId)|| MenuBll.IsUserHasAction(workContext.CurrentUser, this._url, this._action) :
                     MenuBll.IsUserHasAction(workContext.CurrentUser, this._url, this._action);

            if (!allowAccess)
            {
                var routeData = new RouteData();
                routeData.Values.Add("controller", "Common");
                routeData.Values.Add("action", "AccessDenied");
                filterContext.Result = new ContentResult();
                IController controller = EngineContext.Current.Resolve<CommonController>();
                controller.Execute(new RequestContext(filterContext.HttpContext, routeData));
            }*/
        }
    }
}
