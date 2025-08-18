using System;
using Microsoft.AspNetCore.Http;
using Rcbi.Core;
using Rcbi.Entity.Domain;
using Rcbi.Framework.Authentication;

namespace Rcbi.Framework
{
    public class ApiWorkContext : IWorkContext
    {
        private User _cachedUser;

        private readonly HttpContext _httpContext;
        private readonly IAuthenticationService _authenticationService;
        private readonly IWebHelper _webHelper;

        public ApiWorkContext(HttpContext httpContext,
            IAuthenticationService authenticationService,
            IWebHelper webHelper) 
        {
            this._httpContext = httpContext;
            this._authenticationService = authenticationService;
            this._webHelper = webHelper;
        }

        public virtual User CurrentUser
        {
            get
            {
                if (_cachedUser != null)
                    return _cachedUser;

                return this._authenticationService.GetAuthenticatedUser();
            }
        }

        public virtual bool IsAdmin
        {
            get
            {
                if (_cachedUser != null)
                    _cachedUser = this.CurrentUser;

                if (_cachedUser != null)
                    return _cachedUser.IsAdmin;

                return false;
            }
        }

        public virtual string CurrentIpAddress
        {
            get
            {
                return _webHelper.GetCurrentIpAddress();
            }
        }

        public virtual string ThisPageUrl
        {
            get
            {
                return _webHelper.GetThisPageUrl(false);
            }
        }

        public virtual string UrlReferrer
        {
            get
            {
                return _webHelper.GetUrlReferrer();
            }
        }
    }
}
