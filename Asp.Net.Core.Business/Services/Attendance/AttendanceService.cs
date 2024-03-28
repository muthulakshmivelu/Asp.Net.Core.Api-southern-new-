
using Asp.Net.Core.DataModel.Models.Department;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.Net.Core.Business.Services.Attendance
{
    public class AttendanceStatusListService : IRequest<string>
    {
    }

    public class CustomerBranchSiteDropDownListService : IRequest<string>
    {
        public string AttendanceDropDownList { get; set; }
    }

    public class GetManpowerDetailsListService : IRequest<string>
    {
        public string ManpowerDetails { get; set; }
    }
    public class ManPowerAttendanceSaveService : IRequest<int>
    {
        public string AttendanceSave { get; set; }
    }

    public class GetManpowerPivotDetailsListService : IRequest<string>
    {
        public string GetManpowerPivotDetailsList { get; set; }
    }

}
