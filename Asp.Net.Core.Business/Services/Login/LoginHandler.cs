using Asp.Net.Core.Business.Helpers;
using Asp.Net.UserControl.Business.Model;
using Asp.Net.UserControl.DataContext.UnitOfWork;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ERP.UserControl.DataContext.UnitOfWork;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.Net.Core.Business.Services.Login
{
    public class LoginHandler : IRequestHandler<LoginService, LoginResponse>
    {
        private readonly IOptions<ConfigurationManager> configurationService;
        private readonly IUnitOfWork unitOfWork;
        private readonly IHttpContextAccessor httpContextAccessor;

        public LoginHandler(
            IOptions<ConfigurationManager> configurationService,
            IUnitOfWork unitOfWork,
            IHttpContextAccessor httpContextAccessor)
        {
            this.configurationService = configurationService;
            this.unitOfWork = unitOfWork;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<LoginResponse> Handle(LoginService request, CancellationToken cancellationToken)
        {
            var response = new LoginResponse();
            var user = await unitOfWork.UserAuthenticate.Login(request.Username, request.Password);
            if (user == null) { return new LoginResponse { StatusCode = HttpStatusCode.Unauthorized }; }
            if (user.Authorized == true)
            {
                unitOfWork.Commit();
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(configurationService.Value.JwtSettings.JwtPublicKey);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(JwtRegisteredClaimNames.Sub,user.User_ID.ToString()),
                    }),
                    Issuer = configurationService.Value.JwtSettings.Issuer,
                    Expires = DateTime.Now.AddSeconds(Convert.ToDouble(configurationService.Value.JwtSettings.LifeTime)),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                response = new LoginResponse
                {
                    UserId = user.User_ID,
                    UserName = user.User_Name,
                    TokenType = configurationService.Value.JwtSettings.TokenType,
                    Token = tokenHandler.WriteToken(token),
                    ExpiredAt = tokenDescriptor.Expires.Value,
                    StatusCode = HttpStatusCode.OK,
                };
            }
            else
            {
                throw new ArgumentException("UnAuthorized");
            }

            return response;
        }
    }
}
