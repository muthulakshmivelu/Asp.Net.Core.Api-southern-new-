using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.Core.DataContext.InterfaceRepository.PayrollAttendance
{
    public interface IPayrollAttendanceRepository
    {
        Task<int> PayrollAttendanceSave(string attendanceData);
        Task<string> PayrollAttendanceList();
        Task<string> PayrollAttendanceGetById(int empid);

        Task<int> PayrollAttendanceDelete(int inputId);
    }
}
