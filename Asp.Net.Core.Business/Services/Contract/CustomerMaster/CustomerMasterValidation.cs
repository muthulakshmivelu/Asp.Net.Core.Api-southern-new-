using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.Net.Core.Business.Services.Contract.CustomerMaster
{
    public class CustomerSaveValidation : AbstractValidator<CustomerSaveService>
    {

    }
    public class CustomerListValidation : AbstractValidator<CustomerListService>
    {

    }
    public class CustomerFetchValidation : AbstractValidator<CustomerFetchService>
    {

    }
}
