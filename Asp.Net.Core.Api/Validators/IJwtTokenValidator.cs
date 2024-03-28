using System.IdentityModel.Tokens.Jwt;

namespace Asp.Net.Core.Api.Validators
{
    public interface IJwtTokenValidator
    {
        JwtSecurityToken ValidateToken(string token);
    }
}
