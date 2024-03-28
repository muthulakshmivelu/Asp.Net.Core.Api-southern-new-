using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.Core.DataContext.InterfaceRepository.EmployeeSalaryMasterMapping
{
    public interface IEmployeeSalaryRepository
    {
        Task<int> EmployeeSalarySave(string value);
        Task<string> EmployeeSalaryList();
        Task<string> GetById(int empid);
        //Task<int> EmployeeSalaryDelete(string value);
        Task<int> EmployeeSalaryDelete(int inputId);
    }
}
