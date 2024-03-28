using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.Core.Business.Services.Holiday
{
    public class HolidayValidation : AbstractValidator<HolidayService>
    {
    }
    public class HolidayListValidation : AbstractValidator<HolidayListService>
    {

    }

    public class HolidayDeleteValidation : AbstractValidator<HolidayDeleteService>
    {

    }
}
