using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rcbi.Exceptionless;
using Rcbi.Exceptionless.Model;
using Rcbi.Framework.Filter;
using Rcbi.IdentityServer.Models;

namespace Rcbi.Framework.Controllers
{
    [ApiController]
#if !DEBUG
    [Authorize]
#endif
    public class BaseApiController : ControllerBase
    {
        protected User CurrentUser
        {
            get
            {
                var claimsIdentity = (this.User.Identity as ClaimsIdentity);

                Claim idclaim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

                if (idclaim == null)
                {
                    throw new InvalidOperationException("user id claim is missing");
                }

                if (int.TryParse(idclaim.Value, out int userId))
                {
                    return new User(userId,
                        claimsIdentity.FindFirst("name")?.Value,
                        claimsIdentity.FindFirst(ClaimTypes.Email)?.Value);
                }

                throw new InvalidOperationException("current user is missing");
            }
            private set { }
        }

        protected ExcUserParam ExceptionUser
        {
            get
            { 
                try
                {
                    return new ExcUserParam()
                    {
                        Id = this.CurrentUser.Id.ToString(),
                        Name = this.CurrentUser.Username,
                        Email = this.CurrentUser.Email
                    };
                }
                catch (Exception e)
                {
                    return new ExcUserParam();
                }
            }
        }
    }
}
