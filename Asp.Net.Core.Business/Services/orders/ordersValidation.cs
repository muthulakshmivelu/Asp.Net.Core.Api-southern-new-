using Asp.Net.Core.Business.Services.Department;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.Core.Business.Services.orders
{

    public class ordersSaveValidation : AbstractValidator<ordersSaveService>
    {

    }
    public class ordersListValidation : AbstractValidator<ordersListService>
    {

    }
    public class ordersFetchValidation : AbstractValidator<ordersFetchService>
    {

    }
    public class ordersDeleteValidation : AbstractValidator<ordersDeleteService>
    {

    }


}
