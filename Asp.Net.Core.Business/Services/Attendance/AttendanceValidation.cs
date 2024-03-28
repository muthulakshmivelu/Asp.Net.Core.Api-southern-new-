using Asp.Net.Core.Business.Services.Contract;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.Net.Core.Business.Services.Attendance
{
    public class AttendanceStatusListValidation : AbstractValidator<AttendanceStatusListService>
    {

    }
    public class CustomerBranchSiteDropDownListValidation : AbstractValidator<CustomerBranchSiteDropDownListService>
    {

    }
    public class GetManpowerDetailsListValidation : AbstractValidator<GetManpowerDetailsListService>
    {

    }
    public class ManPowerAttendanceSaveValidation : AbstractValidator<ManPowerAttendanceSaveService>
    {

    }
    public class GetManpowerPivotDetailsListValidation : AbstractValidator<GetManpowerPivotDetailsListService>
    {

    }
}
