using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Asp.Net.Core.Api.Validators
{
    public class JwtTokenValidator : IJwtTokenValidator
    {
        private string publicKey;
        private string authTokenIssuer;

        public JwtTokenValidator(string publicKey, string authTokenIssuer)
        {
            this.publicKey = publicKey;
            this.authTokenIssuer = authTokenIssuer;
        }

        public JwtSecurityToken ValidateToken(string token)
        {
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = false,
                RequireExpirationTime = true,
                ValidIssuer = authTokenIssuer,
                ValidateLifetime = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(publicKey))
            };

            SecurityToken validatedSecurityToken = null;
            var handler = new JwtSecurityTokenHandler();

            handler.ValidateToken(token, validationParameters, out validatedSecurityToken);
            var validatedJwt = validatedSecurityToken as JwtSecurityToken;
            return validatedJwt;
        }
    }
}
