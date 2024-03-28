using Asp.Net.Core.DataModel.Models;
using Asp.Net.Core.DataModel.Models.Department;
using Asp.Net.Core.DataModel.Models.ManPower;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.Core.DataContext.InterfaceRepository.ManPower
{
    public interface ImanpowerRepository
    {

        // All Drop Down
        Task<string> GetCompanyList();
        Task<string> GetCountryList();
        Task<string> GetStateList();
        Task<string> GetCityList(string value);
        Task<string> GetBankList();
        Task<string> GetDesignationList();
        Task<string> GetPaymentModeList();
        Task<string> GetProofList();
        Task<string> GetAccountTypeList();

        // All Save
        Task<int> ManPowerDetailSave(string value);
        Task<int> ManPowerBankDetailSave(string value);
        Task<int> ManPowerFamilyDetailSave(string value);
        Task<int> ManPowerProofDetailSave(string value);

        // All List
        Task<string> GetManpowerList();
        Task<string> GetManpowerBankList(string value);
        Task<string> GetManpowerFamilyList(string value);
        Task<string> GetManpowerProofList(string value);

        // All Delete
        Task<int> ManPowerBankDelete(string value);
        Task<int> ManPowerFamilyDelete(string value);
        Task<int> ManPowerProofDelete(string value);

        //fetch
        Task<Table4> ManPowerDetailFetch(string value);

        // AssignManpower
        Task<string> GetClassificationList(string value);
        Task<string> GetContractIdList(string value);
        Task<string> GetServiceList(string value);
        Task<string> GetManpowerNameList(string value);
        Task<string> GetAssignManpowerList(int value);
        Task<int> GetAssignManpowerSave(string value);
        Task<int> GetAssignManpowerDelete(string value);

        //assign field officer
        Task<int> GetFieldOfficerSave(string value);
        Task<int> GetFieldOfficerDelete(string value);
        Task<string> GetFieldOfficer(string value);
        Task<string> GetAllManpowerName();
        Task<string> GetManpowerDirect();
        Task<int> SaveManpowerdirect(string value);
        Task<string> GetShiftdetailsdirect(string value);
    }
}
