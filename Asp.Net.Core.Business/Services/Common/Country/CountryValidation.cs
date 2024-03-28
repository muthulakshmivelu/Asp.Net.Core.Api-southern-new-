using Asp.Net.Core.Business.Services.Contract;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.Net.Core.Business.Services.Common.Country
{
    public class CountrySaveValidation : AbstractValidator<CountrySaveService>
    {

    }
    public class CountryListValidation : AbstractValidator<CountryListService>
    {

    }
    public class CountryByIdValidation : AbstractValidator<CountryByIdService>
    {

    }
    public class CountryDeleteValidation : AbstractValidator<CountryDeleteService>
    {

    }
}
