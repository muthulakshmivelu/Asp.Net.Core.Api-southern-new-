using Microsoft.AspNetCore.Authorization;
using Asp.Net.Core.Business.Constants;
using Asp.Net.Core.Business.Model;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net.Core.Api.Filters
{
    public class TerritoryAuthorizeAttribute : AuthorizationHandler<TerritoryAuthorizeAttribute>, IAuthorizationRequirement
    {
        private readonly TerritoryTokens[] territoryTokens;

        public TerritoryAuthorizeAttribute(TerritoryTokens[] territoryTokens)
        {
            this.territoryTokens = territoryTokens;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, TerritoryAuthorizeAttribute requirement)
        {
            if (context.User.HasClaim(c => c.Type == AuthenticationConstants.ClaimsTerritoryId))
            {
                string userTerritoryId = (context.User.Claims.ToList().Where(c => c.Type == AuthenticationConstants.ClaimsTerritoryId)).Select(c => c.Value).FirstOrDefault();

                if (territoryTokens.FirstOrDefault(x => x.Token.Equals(userTerritoryId, StringComparison.InvariantCultureIgnoreCase)) != null)
                {
                    context.Succeed(requirement);
                    await Task.CompletedTask;
                    return;
                }
            }
            else if (context.User.Identities.Any(x => x.AuthenticationType == AuthenticationConstants.ClaimsIdentityBearer && x.IsAuthenticated == true))
            {
                context.Succeed(requirement);
                return;
            }
            context.Fail();
            return;
        }
    }
}
