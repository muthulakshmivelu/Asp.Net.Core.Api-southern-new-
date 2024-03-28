using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Asp.Net.Core.Api.Validators;
using Asp.Net.Core.Business.Constants;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Asp.Net.Core.Api.Middlewares
{
    public class AuthorizationMiddleware
    {
        private readonly RequestDelegate next;

        private readonly IJwtTokenValidator jwtTokenValiator;

        private readonly ILogger<AuthorizationMiddleware> logger;

        private const string CLAIM_USERID = "UserId";

        public AuthorizationMiddleware(RequestDelegate next, IJwtTokenValidator jwtTokenValiator, ILogger<AuthorizationMiddleware> logger)
        {
            this.next = next;
            this.jwtTokenValiator = jwtTokenValiator;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext context )
        {
            bool isAuthorized = false;
           
            try
            {
                isAuthorized = Authorize(context);

            }
            catch (Exception ex)
            {
                logger.LogInformation(default(EventId), ex, ex.Message);
            }

            if (isAuthorized)
            {
                await next.Invoke(context);
            }
           
            else
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return;
            }
        }

        public bool Authorize(HttpContext context)
        {
            if (context.Request.Method == "OPTIONS")
            {
                return true;
            }

            if (context.Request.Path.Value.Contains("swagger"))
            {
                return true;
            }
            if (context.Request.Path.Value.Contains("Authentication"))
            {
                return true;
            }

            if (context.Request.Headers.Keys.Contains(AuthorizationHeaders.TerritoryHeaderName))
            {
                var claims = new List<Claim>();
                claims.Add(new Claim(AuthenticationConstants.ClaimsTerritoryId, context.Request.Headers[AuthorizationHeaders.TerritoryHeaderName]));
                context.User.AddIdentity(new ClaimsIdentity(new ClaimsIdentity(claims)));
                return true;
            }

            if (context.Request.Headers.Keys.Contains(AuthorizationHeaders.HeaderName))
            {
                string accessToken = GetBearerToken(context);
                JwtSecurityToken jwtSecurityToken = jwtTokenValiator.ValidateToken(accessToken);
                var roles = new List<string>();
               // byte [] roles = ((JArray)jwtSecurityToken.Claims["role"]).ToList();
                //claims.FirstOrDefault(c => c.Type.Equals(ClaimTypes.Role, StringComparison.OrdinalIgnoreCase).Value);
                //roles.Add.jwtSecurityToken.Payload.
                //Role.Claims.FirstOrDefault(c => c.Type.Equals("UserId", StringComparison.OrdinalIgnoreCase)).Value);
                // var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(Enumerable.Empty<Claim>(), Schema.Name));
                //var roles = ((JArray)jwtSecurityToken.Payload["role"]).ToObject<List<string>>();
                ClaimsIdentity claimsIdentity = GetClaimsIdentity(jwtSecurityToken, roles);
                context.User.AddIdentity(claimsIdentity);

                return true;
            }

            return false;
        }

        private ClaimsIdentity GetClaimsIdentity(JwtSecurityToken jwtSecurityToken, List<string> roles)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(CLAIM_USERID, jwtSecurityToken.Subject));
            //claims.Add(new Claim(Role,jwtSecurityToken.Claims).ToArray();
            //claims.FirstOrDefault(c => c.Type.Equals(ClaimTypes.Role, StringComparison.OrdinalIgnoreCase).Value);
            //claims.Add(new Claim(ClaimTypes.Role, "HRMS - Super Admin"));
            //claims.Add(new Claim(jwtSecurityToken.Claims.FirstOrDefault(claims => claims.Type =="role:").Value));
            //claims.AddRange(roles.Select(role => new Claim(ClaimsIdentity.DefaultRoleClaimType, role)));
            //new Claim(ClaimTypes.Role, role.Description),
            //claims.Add(new Claim(Role, jwtSecurityToken.Claims.));
            //claims.Add(new Claim(jwtSecurityToken.Claims.FirstOrDefault(c => c.Type == roles).Value));
            //claims.Add(new Claim(claim => new { claim.Type, claim.Value }).ToArray();
            roles.ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));
            var claimIdentity = new ClaimsIdentity(claims, "Bearer");
            return claimIdentity;
        }

        private string GetBearerToken(HttpContext context)
        {
            string accessToken = context.Request.Headers["Authorization"];
            if (accessToken.Contains("Bearer"))
                return accessToken.Replace("Bearer ", "");
            else
                throw new Exception("Authorization header not found!");
        }
    }
}
