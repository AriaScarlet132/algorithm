using System;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Rcbi.AspNetCore.Helper;
using Rcbi.Entity.Enums;
using Rcbi.Entity.OpenApi;
using Rcbi.Exceptionless.Extensions;
using Rcbi.Exceptionless.Model;
using Rcbi.IdentityServer.Models;

namespace Rcbi.Api.Middleware
{
    public class RCBIExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ExceptionHandlerOptions _options;
        public RCBIExceptionHandlerMiddleware(RequestDelegate next, IOptions<ExceptionHandlerOptions> options)
        {
            this._next = next;
            this._options = options.Value;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, OpenApiResultStatus.SYSTEM_ERROR, ex, "异常记录", "中间件拦截");
            }
            finally
            {
                var statusCode = context.Response.StatusCode;
                if (!statusCode.Equals(StatusCodes.Status200OK) && !statusCode.Equals(StatusCodes.Status301MovedPermanently) && !statusCode.Equals(StatusCodes.Status302Found))
                {
                    var url = context.Request.Path.Value;

                    if (statusCode == StatusCodes.Status401Unauthorized)
                    {
                        Exception exception = new Exception($"请求{url}未授权,原始状态码:{statusCode}");

                        await HandleExceptionAsync(context, OpenApiResultStatus.UNAUTHORIZED, exception, "未经授权", "中间件拦截");
                    }
                    else if (statusCode == StatusCodes.Status400BadRequest)
                    {
                        Exception exception = new Exception($"请求{url}错误,原始状态码:{statusCode}");

                        await HandleExceptionAsync(context, OpenApiResultStatus.BAD_REQUEST, exception, "错误的请求", "中间件拦截");
                    }
                    else if (statusCode == StatusCodes.Status403Forbidden)
                    {
                        Exception exception = new Exception($"请求{url}被禁止,原始状态码:{statusCode}");

                        await HandleExceptionAsync(context, OpenApiResultStatus.FORBIDDEN, exception, "被禁止的", "中间件拦截");
                    }
                    else if (statusCode == StatusCodes.Status404NotFound)
                    {
                        Exception exception = new Exception($"请求{url}未找到,原始状态码:{statusCode}");

                        await HandleExceptionAsync(context, OpenApiResultStatus.NOT_FOUND, exception, "接口未找到", "中间件拦截");
                    }
                    else
                    {
                        Exception exception = new Exception($"请求{url}失败,原始状态码:{statusCode}");

                        await HandleExceptionAsync(context, OpenApiResultStatus.SYSTEM_ERROR, exception, "系统异常", "中间件拦截");

                    }

                }
            }
        }

        /// <summary>
        /// 异常处理
        /// </summary>
        /// <param name="context"></param>
        /// <param name="openApiResultStatus"></param>
        /// <param name="exception"></param>
        /// <param name="tags"></param>
        /// <returns></returns>
        private static async Task HandleExceptionAsync(HttpContext context, OpenApiResultStatus openApiResultStatus, Exception exception, params string[] tags)
        {

            if (!context.Response.HasStarted)
            {
                var openApiResult = new OpenApiResult<string>()
                {
                    Data = null,
                    Status = (int)openApiResultStatus,
                    Message = exception.Message
                };
                var result = JsonConvert.SerializeObject(openApiResult);
                try
                {
                    context.Response.Clear();
                    //获取当前登录用户的信息
                    var claimsIdentity = (context.User.Identity as ClaimsIdentity);
                    
                    var excUserParam = new ExcUserParam()
                    {
                        Id = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value,
                        Name = claimsIdentity.FindFirst("name")?.Value,
                        Email = claimsIdentity.FindFirst(ClaimTypes.Email)?.Value
                    };
                    exception.Submit(excUserParam, tags);
                }
                catch (Exception)
                {
                    //获取用户失败 抛出异常 不记录用户
                    exception.Submit("无用户登录");
                }
                //清楚已经完成的相应内容

                context.Response.WriteAsync(result);
            }
        }

    }
}