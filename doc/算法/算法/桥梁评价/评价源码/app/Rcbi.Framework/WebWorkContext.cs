using System;
using Microsoft.AspNetCore.Http;

using Rcbi.Entity.Domain;
using Rcbi.Framework.Authentication;

namespace Rcbi.Framework
{
    public class WebWorkContext : IWorkContext
    {
        private User _cachedUser;

        private readonly HttpContext _httpContext;
        private readonly ISession _httpSession;
        private readonly IAuthenticationService _authenticationService;
        private readonly IWebHelper _webHelper;

        public WebWorkContext(HttpContext httpContext,
            ISession httpSession,
            IAuthenticationService authenticationService,
            IWebHelper webHelper) 
        {
            this._httpContext = httpContext;
            this._httpSession = httpSession;
            this._authenticationService = authenticationService;
            this._webHelper = webHelper;
        }

        public virtual User CurrentUser
        {
            get {
                if (_cachedUser != null)
                    return _cachedUser;

                _cachedUser = this._authenticationService.GetAuthenticatedUser();

                return _cachedUser;
            }
        }

        public virtual IRequestCookieCollection Cookie
        {
            get {
                if (_httpContext == null || _httpContext.Request == null)
                    return null;

                return _httpContext.Request.Cookies;
            }
        }

        public virtual bool IsAdmin
        {
            get {
                if (_cachedUser != null)
                    _cachedUser = this.CurrentUser;

                if (_cachedUser != null)
                    return _cachedUser.IsAdmin;

                return false;
            }
        }

        public virtual string CurrentIpAddress 
        {
            get {
                return _webHelper.GetCurrentIpAddress();
            }
        }

        public virtual string ThisPageUrl 
        {
            get {
                return _webHelper.GetThisPageUrl(false);
            }
        }

        public virtual string UrlReferrer 
        {
            get {
                return _webHelper.GetUrlReferrer();
            }
        }
    }
}
