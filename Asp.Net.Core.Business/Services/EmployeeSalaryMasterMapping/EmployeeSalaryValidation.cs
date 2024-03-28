using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.Core.Business.Services.EmployeeSalaryMasterMapping
{
    public  class EmployeeSalaryValidation: AbstractValidator<EmployeeSalarySaveService>
    {
    }
    public class EmployeeSalaryListValidation : AbstractValidator<EmployeeSalaryListService>
    {

    }
    public class GetByIdValidation : AbstractValidator<GetByIdService>
    {

    }
    public class EmployeeSalaryDeleteValidation : AbstractValidator<EmployeeSalaryDeleteService>
    {

    }
}
