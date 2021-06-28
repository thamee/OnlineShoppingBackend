using IdentityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace OnlinePortal.Api.Extensions
{
    public static class AuthExtentions
    {
        public static string GetId(this IPrincipal authUser)
        {
            return GetClaimValue(authUser, JwtClaimTypes.Id);
        }
        public static string GetRole(this IPrincipal authUser)
        {
            return GetClaimValue(authUser, ClaimTypes.Role);
        }
       
        private static string GetClaimValue(IPrincipal user, string claim)
        {
            var userClaims = user.Identity as ClaimsIdentity;
            var value = userClaims.Claims.FirstOrDefault(c => c.Type == claim)?.Value;
            if (string.IsNullOrEmpty(value))
                throw new UnauthorizedAccessException("Invalid access token");
            return value;
        }

    }
}
