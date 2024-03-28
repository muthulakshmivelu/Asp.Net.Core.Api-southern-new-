using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Asp.Net.Core.Business.Services.EmployeeLeaveType.EmployeeLeaveTypeService;

namespace Asp.Net.Core.Business.Services.EmployeeLeaveType
{
    public class EmployeeLeaveTypeValidation : AbstractValidator<EmployeeLeaveTypeListService>
    {
    }
}
