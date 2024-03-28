using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.Net.Core.Business.Services.Login
{
    public class LoginValidation : AbstractValidator<LoginService>
    {
        public LoginValidation()
        {
            RuleFor(c => c.Username)
                .NotEmpty()
                .WithMessage(command => "{PropertyName} should not be blank.");
            RuleFor(c => c.Password)
               .NotEmpty()
               .WithMessage(command => "{PropertyName} should not be blank.");
        }
    }
}
