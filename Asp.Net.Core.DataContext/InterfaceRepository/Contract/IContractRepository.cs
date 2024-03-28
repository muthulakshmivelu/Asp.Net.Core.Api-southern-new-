using Asp.Net.Core.DataModel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.Core.DataContext.InterfaceRepository.Contract
{
   public interface IContractRepository
    {

        Task<int> ContractSave(string value);
        Task<int> ContractDelete(string value);
        Task<string> GetConsumableRequirement(string value);
        Task<string> GetContractByAllCustomer(string value);
        Task<string> GetContractDetails(string value);
        Task<string> GetContract(string value);
        Task<string> GetContractMaster(string value);
        Task<string> GetAllCustomer(string value);
        Task<string> GetContractsListByCustomerId(string value); 
        Task<string> GetDeparmentAsServiceList();
        Task<string> GetDesignetionByService(string value);
        Task<string> GetCustomerNameList();
        Task<Table6> ContractDetailsFetch(string value);
        Task<string> getclienttype();
    }
}
