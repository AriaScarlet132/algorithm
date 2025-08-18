using Microsoft.AspNetCore.Mvc.Filters;
using Rcbi.AspNetCore.Helper;
using Rcbi.Entity.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Rcbi.Framework.Filter
{
    public class ApiFilterAttribute : Attribute, IActionFilter, IAsyncResourceFilter
    {
        /// <summary>
        /// 请求Api 资源时
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            // 执行前
            try
            {
                await next.Invoke();
            }
            catch
            {
            }
            // 执行后
            await OnResourceExecutedAsync(context);
        }

        /// <summary>
        /// 记录Http请求上下文
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task OnResourceExecutedAsync(ResourceExecutingContext context)
        {

            //获取请求的Body
            string RequestBody = string.Empty;
            //数据流倒带 context.HttpContext.Request.EnableRewind();
            if (context.HttpContext.Request.Body.CanSeek)
            {
                using (var requestSm = context.HttpContext.Request.Body)
                {
                    requestSm.Position = 0;
                    var reader = new StreamReader(requestSm, Encoding.UTF8);
                    RequestBody = reader.ReadToEnd();
                }
            }
            string ResponseBody = string.Empty;
            //将当前 http 响应Body 转换为 IReadableBody
            if (context.HttpContext.Response.Body is IReadableBody body)
            {
                if (body.IsRead)
                {
                    ResponseBody = await body.ReadAsStringAsync();
                }
            }


            //用户id
            int UserId = -1;
            Claim claim = (context.HttpContext.User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.NameIdentifier);
            if (claim != null)
            {
                var sub = claim.Value;
                if (int.TryParse(sub, out int userId))
                {
                    UserId = userId;
                }
            }
            var log = new
            {
                RequestMethod = context.HttpContext.Request.Method,
                ResponseStatusCode = context.HttpContext.Response.StatusCode,
                RequestQurey = context.HttpContext.Request.QueryString.ToString(),
                RequestContextType = context.HttpContext.Request.ContentType,
                RequestHost = context.HttpContext.Request.Host.ToString(),
                RequestPath = context.HttpContext.Request.Path,
                RequestScheme = context.HttpContext.Request.Scheme,
                RequestLocalIp = (context.HttpContext.Request.HttpContext.Connection.LocalIpAddress.MapToIPv4().ToString() + ":" + context.HttpContext.Request.HttpContext.Connection.LocalPort),
                RequestRemoteIp = (context.HttpContext.Request.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString() + ":" + context.HttpContext.Request.HttpContext.Connection.RemotePort),
                RequestBody = RequestBody,
                ResponseBody = ResponseBody
            };

            string LogMsg = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n"
                + "用户ID：" + UserId + "\r\n"
                + "用户IP：" + log.RequestLocalIp + "\r\n"
                + "请求方式：" + log.RequestMethod + "\r\n"
                + "请求地址：" + log.RequestHost + "/" + log.RequestPath.Value + log.RequestQurey + "\r\n"
                + "请求内容：" + log.RequestBody + "\r\n"
                + "响应内容：" + log.ResponseBody + "\r\n\r\n";
            LogHelper.Info(LogMsg);
        }

        /// <summary>
        /// Action 执行前
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            //设置 Http请求响应内容设为可读
            if (context.HttpContext.Response.Body is IReadableBody responseBody)
            {
                responseBody.IsRead = true;
            }
        }

        /// <summary>
        /// Action 执行后
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
