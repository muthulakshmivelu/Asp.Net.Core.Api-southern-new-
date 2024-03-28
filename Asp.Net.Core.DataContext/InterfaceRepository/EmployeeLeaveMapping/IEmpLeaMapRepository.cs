using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.Core.DataContext.InterfaceRepository.EmployeeLeaveMapping
{
    public interface IEmpLeaMapRepository
    {

        Task<int> EmpLeaSave(string value);
        Task<string> EmpLeaList();
        Task<string> GetEmpLeaveById(int empid);

        Task<int> EmpLeaDelete(int inputId);
    }
}
