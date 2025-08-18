using System;
/*
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Owin;
using Microsoft.AspNetCore.Identity.EntityFramework;
*/
using System.Threading.Tasks;
using System.Security.Claims;

using Rcbi.Entity.Domain;

namespace Rcbi.Framework.Authentication
{
    /*
    public class AuthIdentityUser : IdentityUser
    {
        public AuthIdentityUser(User user) : base(user.UserName)
        {  
        }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<AuthIdentityUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }*/
}
