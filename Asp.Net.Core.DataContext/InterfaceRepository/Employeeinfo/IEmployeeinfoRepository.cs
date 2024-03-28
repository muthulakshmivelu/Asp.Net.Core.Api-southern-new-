using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.Core.DataContext.InterfaceRepository.Employeeinfo
{
    public interface IEmployeeinfoRepository
    {
        Task<string> EmployeeinfoList();
    }
}
