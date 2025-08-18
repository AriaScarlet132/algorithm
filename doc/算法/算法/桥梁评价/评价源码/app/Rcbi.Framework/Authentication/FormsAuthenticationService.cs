using System;
using System.Web;
/*
using System.Web.Security;
using System.Collections.Generic;

using Rcbi.Business;
using Rcbi.Entity.Domain;
using Rcbi.Core.Infrastructure;
*/
namespace Rcbi.Framework.Authentication
{
    /*
    public class FormsAuthenticationService : IAuthenticationService
    {
        private User _cachedUser;
        private readonly HttpContextBase _httpContext;
        private readonly HttpSessionStateBase _httpSession;

        public FormsAuthenticationService(HttpContextBase httpContext,
            HttpSessionStateBase httpSession) 
        {
            this._httpContext = httpContext; 
            this._httpSession = httpSession; 
        }

        public virtual void SignIn(User user, bool createPersistentCookie)
        {
            var now = DateTime.UtcNow.ToLocalTime();

            var ticket = new FormsAuthenticationTicket(
                1 ,
                user.UserName,
                now,
                now.Add(FormsAuthentication.Timeout),
                createPersistentCookie,
                user.UserName,
                FormsAuthentication.FormsCookiePath);

            var encryptedTicket = FormsAuthentication.Encrypt(ticket);
           
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            cookie.HttpOnly = true;
            if (ticket.IsPersistent)
            {
                cookie.Expires = ticket.Expiration;
            }
            cookie.Secure = FormsAuthentication.RequireSSL;
            cookie.Path = FormsAuthentication.FormsCookiePath;
            if (FormsAuthentication.CookieDomain != null)
            {
                cookie.Domain = FormsAuthentication.CookieDomain;
            }

            _httpSession[user.UserName] = user;
            _httpSession["guid"] = Guid.NewGuid().ToString("N");
            _httpContext.Response.Cookies.Add(cookie);
            _cachedUser = user;
        }

        public virtual void SignOut()
        {
            _cachedUser = null;
            FormsAuthentication.SignOut();
            _httpSession.Clear();
            _httpSession.Abandon();
        }

        public User GetAuthenticatedUser()
        {
            if (_cachedUser != null)
                return _cachedUser;

            if (_httpContext == null ||
                _httpContext.Request == null ||
                !_httpContext.Request.IsAuthenticated ||
                _httpContext.User == null ||
                _httpContext.User.Identity == null ||
                !(_httpContext.User.Identity is FormsIdentity))
            {
                return null;
            }

            var formsIdentity = (FormsIdentity)_httpContext.User.Identity;

            var user = GetAuthenticatedCustomerFromTicket(formsIdentity.Ticket);

            if(user != null)
                _cachedUser = user;

            return _cachedUser;
        }

        public virtual User GetAuthenticatedCustomerFromTicket(FormsAuthenticationTicket ticket)
        {
            if (ticket == null)
                throw new ArgumentNullException("ticket");
            
            var userName = ticket.UserData;

            if (String.IsNullOrWhiteSpace(userName))
                return null;

            _cachedUser = _httpSession[userName] as User;
            
            if (_cachedUser != null)
               return _cachedUser;

            _cachedUser = UserBll.GetUser(userName);

            if (_cachedUser != null) 
            {
                _httpSession[userName] = _cachedUser;
            }

            return _cachedUser;
        }
    }*/
}
