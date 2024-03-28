using Microsoft.AspNetCore.Authorization;
using Asp.Net.Core.Business.Constants;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net.Core.Api.Filters
{
    public class BearerTokenAttribute : AuthorizationHandler<BearerTokenAttribute>, IAuthorizationRequirement
    {  
      protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, BearerTokenAttribute requirement)
        {
            if (context.User.Identities.Any(x => x.AuthenticationType == AuthenticationConstants.ClaimsIdentityBearer && x.IsAuthenticated == true))
            {
                context.Succeed(requirement);
                await Task.CompletedTask;
                return;
            }
            await Task.CompletedTask;
            //HttpStatusCode.BadRequest.ToString();
            return;
        }

       
    }
}
