using System;
using System.Security.Principal;

namespace Rcbi.Framework.Authentication
{
    public class AuthPrincipal : IPrincipal
    {
        private IIdentity _identity;

        public AuthPrincipal(IIdentity identity)
        {
            this._identity = identity;
        }
        public IIdentity Identity
        {
            get { return _identity; }
        }

        public bool IsInRole(string role)
        {
            return _identity != null && _identity.IsAuthenticated;
        }
    }
}
