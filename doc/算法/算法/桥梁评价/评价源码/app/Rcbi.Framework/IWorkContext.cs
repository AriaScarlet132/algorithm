using System;

using Rcbi.Entity.Domain;

namespace Rcbi.Framework
{
    public interface IWorkContext
    {
        /// <summary>
        /// 用户信息
        /// </summary>
        User CurrentUser { get; }

        /// <summary>
        /// 是否管理员
        /// </summary>
        bool IsAdmin { get; }

        /// <summary>
        /// IP地址
        /// </summary>
        string CurrentIpAddress { get; }

        /// <summary>
        /// 页面Url
        /// </summary>
        string ThisPageUrl { get; }
        
        /// <summary>
        /// Referrer
        /// </summary>
        string UrlReferrer { get; }
    }
}
