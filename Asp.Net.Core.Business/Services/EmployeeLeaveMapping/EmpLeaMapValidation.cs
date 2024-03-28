using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.Core.Business.Services.EmployeeLeaveMapping
{
    public class EmpLeaMapValidation : AbstractValidator<EmpLeaMapService>
    {
    }
    public class EmpLeaMapListValidation : AbstractValidator<EmpLeaMapListService>
    {

    }
    public class GetEmpLeaveByIdValidation : AbstractValidator<GetEmpLeaveByIdService>
    {

    }

    public class EmpLeaMapDeleteValidation : AbstractValidator<EmpLeaMapDeleteService>
    {

    }
}
