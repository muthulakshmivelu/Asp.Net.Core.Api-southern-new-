
using Asp.Net.Core.DataModel.Models.Department;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.Core.DataContext.InterfaceRepository.Attendance
{
    public interface IAttendanceRepository
    {
        Task<string> AttendanceStatusList();
        Task<string> CustomerBranchSiteDropDownList(string value);
        Task<string> GetManpowerDetailsList(string value);
        Task<int> ManPowerAttendanceSave(string value);
        Task<string> GetManpowerPivotDetailsList(dynamic value);
    }
}
