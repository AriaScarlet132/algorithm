using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

using Newtonsoft.Json;

using Rcbi.Business;
using Rcbi.Entity.Domain;
using Rcbi.Core.Extensions;
using Rcbi.Framework.Controllers;

namespace Rcbi.Framework.Extensions
{
    public static class HmtlHelperExtension
    {
        public static IHtmlContent Action(this IHtmlHelper helper, string action, object parameters = null)
        {
            var controller = (string)helper.ViewContext.RouteData.Values["controller"];

            return Action(helper, action, controller, parameters);
        }

        public static IHtmlContent Action(this IHtmlHelper helper, string action, string controller, object parameters = null)
        {
            var area = (string)helper.ViewContext.RouteData.Values["area"];

            return Action(helper, action, controller, area, parameters);
        }

        public static User GetUser(this IHtmlHelper helper)
        {
            var userClaims = (ClaimsIdentity)helper.ViewContext.HttpContext.User.Identities.FirstOrDefault();

            if (userClaims == null || userClaims.Claims == null || userClaims.Claims.Count() <= 0)
                return null;

            return JsonConvert.DeserializeObject<User>(userClaims.Claims.First().Value);
            
        }

        public static IHtmlContent Action(this IHtmlHelper helper, string action, string controller, string area, object parameters = null)
        {
            if (action == null)
                throw new ArgumentNullException("action");

            if (controller == null)
                throw new ArgumentNullException("controller");


            var task = RenderActionAsync(helper, action, controller, area, parameters);

            return task.Result;
        }

        private static async Task<IHtmlContent> RenderActionAsync(this IHtmlHelper helper, string action, string controller, string area, object parameters = null)
        {
            // fetching required services for invocation
            var serviceProvider = helper.ViewContext.HttpContext.RequestServices;
            var actionContextAccessor = helper.ViewContext.HttpContext.RequestServices.GetRequiredService<IActionContextAccessor>();
            var httpContextAccessor = helper.ViewContext.HttpContext.RequestServices.GetRequiredService<IHttpContextAccessor>();
            var actionSelector = serviceProvider.GetRequiredService<IActionSelector>();

            // creating new action invocation context
            var routeData = new RouteData();
            foreach (var router in helper.ViewContext.RouteData.Routers)
            {
                routeData.PushState(router, null, null);
            }
            routeData.PushState(null, new RouteValueDictionary(new { controller = controller, action = action, area = area }), null);
            routeData.PushState(null, new RouteValueDictionary(parameters ?? new { }), null);

            //get the actiondescriptor
            RouteContext routeContext = new RouteContext(helper.ViewContext.HttpContext) { RouteData = routeData };
            var candidates = actionSelector.SelectCandidates(routeContext);
            var actionDescriptor = actionSelector.SelectBestCandidate(routeContext, candidates);

            var originalActionContext = actionContextAccessor.ActionContext;
            var originalhttpContext = httpContextAccessor.HttpContext;
            try
            {
                var newHttpContext = serviceProvider.GetRequiredService<IHttpContextFactory>().Create(helper.ViewContext.HttpContext.Features);
                if (newHttpContext.Items.ContainsKey(typeof(IUrlHelper)))
                {
                    newHttpContext.Items.Remove(typeof(IUrlHelper));
                }
                newHttpContext.Response.Body = new MemoryStream();
                var actionContext = new ActionContext(newHttpContext, routeData, actionDescriptor);
                actionContextAccessor.ActionContext = actionContext;
                var invoker = serviceProvider.GetRequiredService<IActionInvokerFactory>().CreateInvoker(actionContext);
                await invoker.InvokeAsync();
                newHttpContext.Response.Body.Position = 0;
                using (var reader = new StreamReader(newHttpContext.Response.Body))
                {
                    return new HtmlString(reader.ReadToEnd());
                }
            }
            catch (Exception ex)
            {
                return new HtmlString(ex.Message);
            }
            finally
            {
                actionContextAccessor.ActionContext = originalActionContext;
                httpContextAccessor.HttpContext = originalhttpContext;
                if (helper.ViewContext.HttpContext.Items.ContainsKey(typeof(IUrlHelper)))
                {
                    helper.ViewContext.HttpContext.Items.Remove(typeof(IUrlHelper));
                }
            }
        }
      
        public static IHtmlContent DropDownListByGeneral(this IHtmlHelper helper,
            string generalCode,
            string name,
            object htmlAttributes = null,
            string selectedValue = null)
        {
            var items = new List<SelectListItem>();
            items.Add(new SelectListItem());
           
            GeneralBll.GetGeneralsByCode(generalCode).ForEach((item) =>
            {
                items.Add(new SelectListItem()
                {
                    Value = item.GeneralKey,
                    Text = item.Content,
                    Selected = selectedValue == item.GeneralKey
                });
            });

            return helper.DropDownList(name, items, htmlAttributes);
        }

        public static IHtmlContent DropDownListWithTipsByGeneral(this IHtmlHelper helper,
           string generalCode,
           string name,
           string tips,
           object htmlAttributes = null,
           string selectedValue = null)
        {
            var items = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = string.Empty,
                    Text = tips
                }
            };

            GeneralBll.GetGeneralsByCode(generalCode).ForEach((item) =>
            {
                items.Add(new SelectListItem
                {
                    Value = item.GeneralKey,
                    Text = item.Content,
                    Selected = selectedValue == item.GeneralKey
                });
            });

            return helper.DropDownList(name, items, htmlAttributes);
        }
      /*
        public static bool IsActionPermission(this IHtmlHelper helper, string action, string url = null)
        {
            var workContext = EngineContext.Current.Resolve<IWorkContext>();
    
            var baseController = helper.ViewContext.Controller as BaseWebController;

            if (baseController == null)
                return true;

            if (url == null)
            {
                url = new Uri(workContext.ThisPageUrl).AbsolutePath;
                var _action = "/" + action;
                if (url.EndsWith(_action))
                {
                    url = url.Remove(url.Length - _action.Length);
                }
            }

            var ret = baseController.CurrentProject != null ?
                     MenuBll.IsUserHasAction(workContext.CurrentUser, url, action, baseController.CurrentProject.ProjectId) :
                     MenuBll.IsUserHasAction(workContext.CurrentUser, url, action);

            return ret;
        }*/
    }
}
