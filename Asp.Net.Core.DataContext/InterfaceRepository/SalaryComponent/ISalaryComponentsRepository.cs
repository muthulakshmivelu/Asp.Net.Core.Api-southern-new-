using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.Core.DataContext.InterfaceRepository.SalaryComponent
{
    public interface ISalaryComponentsRepository
    {

        Task<int> SalaryComponentSave(string value);
        Task<string> SalaryComponentList();
        Task<int> SalaryComponentDelete(string value);
    }
}
