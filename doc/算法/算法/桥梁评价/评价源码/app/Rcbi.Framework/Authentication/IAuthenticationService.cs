using System;

using Rcbi.Entity.Domain;

namespace Rcbi.Framework.Authentication
{
    public partial interface IAuthenticationService
    {
        void SignIn(User user, bool createPersistentCookie);
        void SignOut();
        User GetAuthenticatedUser();
    }
}
