using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.Core.Business.Services.Payslip
{
    public class PayslipValidation: AbstractValidator<PayslipService>
    {

    }
    public class PayslipListValidation : AbstractValidator<PayslipListService>
    {

    }

    public class PayslipDeleteValidation : AbstractValidator<PayslipDeleteService>
    {

    }
}
