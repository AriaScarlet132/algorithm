using IdentityModel;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Rcbi.IdentityServer.Interfaces.Services;
using Rcbi.IdentityServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Rcbi.IdentityServer.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IUserService _userManager;

        public ProfileService(IUserService userManager)
        {
            _userManager = userManager;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var subjectId = context.Subject.GetSubjectId();

            if (!subjectId.IsNullOrEmpty())
            {
                var user = await _userManager.GetAsync(Convert.ToInt32(subjectId));

                if (context.IssuedClaims == null)
                    context.IssuedClaims = new List<Claim>();

                context.IssuedClaims.Add(new Claim(JwtClaimTypes.Email, user.Email ?? string.Empty));
                context.IssuedClaims.Add(new Claim(JwtClaimTypes.Name, user.Username));
            }
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var sub = context.Subject.GetSubjectId();
            if (int.TryParse(sub, out int userId))
            {
                var user = await _userManager.GetAsync(userId);

                context.IsActive = user != null;
            }
            else
            {
                context.IsActive = false;
            }
        }
    }

    internal static class UserExtensions
    {
        public static IEnumerable<Claim> GetClaims(this User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtClaimTypes.Subject, user.Id.ToString()),
                new Claim(JwtClaimTypes.PreferredUserName, user.Username),
                new Claim(JwtClaimTypes.Name, user.Username)
            };

            return claims;
        }
    }
}

