using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.Core.DataContext.InterfaceRepository.Contract.CustomerMaster
{
    public interface ICustomerMasterRepository
    {
        Task<int> CustomerSave(string value);
        Task<string> CustomerList();
        Task<string> CustomerFetch(string value);
    }
}
