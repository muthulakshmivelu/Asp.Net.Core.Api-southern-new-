using Asp.Net.Core.Business.Services.Contract;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.Net.Core.Business.Services.Menus
{
    public class MenusValidation : AbstractValidator<MenusService>
    {
        public MenusValidation()
        {
        }
    }
    public class getmenulistValidation : AbstractValidator<getmenulistService>
    {

    }
}
