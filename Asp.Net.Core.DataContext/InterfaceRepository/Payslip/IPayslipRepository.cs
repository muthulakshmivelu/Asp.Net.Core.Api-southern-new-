using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.Core.DataContext.InterfaceRepository.Payslip
{
    public interface IPayslipRepository
    {
        Task<int> PayslipSave(string inputJson);
        Task<string> PayslipList();
        Task<int> PayslipDelete(int month, int year);

    }
}
