using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.Core.DataContext.InterfaceRepository.Contract.CustomerSiteMapping
{
    public interface ICustomerSiteMappingRepository
    {
        // customer drop down
        Task<string> GetCustomerDropDown();
        //delete
        Task<int> BranchMasterDelete(string value);
        Task<int> SiteMasterDelete(string value);
        Task<int> ClassificationMasterDelete(string value);

        //list
        Task<string> GetBranchMasterList(string value);
        Task<string> GetSiteMasterList(string value);
        Task<string> GetClassificationMasterList(string value);
        Task<string> Locationlist(string value);
        Task<string> ContractListAllocate(string value);
        Task<string> ContractServiceList(string value);
        Task<string> ContractListbyCustomer(int value);
        Task<string> AllocationList(int value);

        //save
        Task<int> BranchMasterSave(string value);
        Task<int> SiteMasterSave(string value);
        Task<int> ClassificationMasterSave(string value);

        //////////////////// Allocate Manpower ////////////
        ///
        Task<int> AllocateManpowerSiteSave(string value);
        Task<string> GetMAServiceList(string value);
        Task<string> AllocateManpowerSiteList(string value);
        Task<int> AllocateManpowerSiteDelete(string value);


        //location

        Task<int> SaveLocation(string value);
        Task<string> GetLocation(string value);
        Task<int> DeleteLocation(string value);
        Task<string> GetContractList();
        Task<string> LocationFetch(string value);

    }
}
