using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace Asp.Net.Core.IdentityUser
{
    public class CurrentUser : ICurrentUser
    {
        private readonly Guid UserId;

        public CurrentUser(IHttpContextAccessor httpContextAccessor)
        {
            if (httpContextAccessor.HttpContext.User.HasClaim(c => c.Type.Equals("UserId", StringComparison.OrdinalIgnoreCase)))
            {
                UserId = Guid.Parse(httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("UserId", StringComparison.OrdinalIgnoreCase)).Value);
            }
        }

        Guid ICurrentUser.UserId { get { return UserId; } }
    }
}
