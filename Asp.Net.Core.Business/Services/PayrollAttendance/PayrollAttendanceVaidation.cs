using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.Core.Business.Services.PayrollAttendance
{
    public class PayrollAttendanceValidation : AbstractValidator<PayrollAttendanceService>
    {

    }
    public class PayrollAttendanceListValidation : AbstractValidator<PayrollAttendanceListService>
    {

    }
    public class PayrollAttendanceGetByIdValidation : AbstractValidator<PayrollAttendanceGetByIdService>
    {

    }
    public class PayrollAttendanceDeleteValidation : AbstractValidator<PayrollAttendanceDeleteService>
    {

    }
}
