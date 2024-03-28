using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.Core.DataContext.InterfaceRepository.EmployeeLeaveType
{
    public interface IEmployeeLeaveTypeRepository
    {
        Task<string> LeaveTypeList();
    }
}
