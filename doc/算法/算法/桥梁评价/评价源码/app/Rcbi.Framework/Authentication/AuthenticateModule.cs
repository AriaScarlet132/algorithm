using System;
using System.Collections.Generic;
using System.Web;
/*
using System.Web.Security;

using Rcbi.Common;
using Rcbi.Common.Extensions;
using Rcbi.Core.Infrastructure;
*/

namespace Rcbi.Framework.Authentication
{
    /*
    public class AuthenticateModule : IHttpModule
    {
        private IWebHelper webHelper;

        public void Init(HttpApplication context)
        {
            webHelper = EngineContext.Current.Resolve<IWebHelper>();
            
            context.AuthenticateRequest += context_AuthenticateRequest;
        }

        private void context_AuthenticateRequest(object sender, EventArgs e)
        {
            var context = ((HttpApplication)sender).Context;

            if (webHelper.IsStaticResource(context.Request))
                return;

            var cookie = context.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie != null) {

                FormsAuthenticationTicket authTicket = null;
               
                try
                {
                    authTicket = FormsAuthentication.Decrypt(cookie.Value);
                }
                catch { }

                if (authTicket != null && !authTicket.UserData.IsNullOrEmpty()) {

                    var identity = new AuthIdentity(authTicket, true);
                    context.User = new AuthPrincipal(identity);
                }
            }
        }

        public void Dispose()
        {

        }
    }*/
}
