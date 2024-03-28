using Asp.Net.Core.DataModel.Models;
using Asp.Net.Core.DataModel.Models.Department;
using Asp.Net.Core.DataModel.Models.ManPower;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.Net.Core.Business.Services.Manpower
{

    //All Drop Down

    public class GetCompanyListService : IRequest<string>
    {
       
    }
    public class GetCountryListService : IRequest<string>
    {
       
    }
    public class GetStateListService : IRequest<string>
    {
       
    }
    public class GetCityListService : IRequest<string>
    {
        public string GetCityList { get; set; }
    }
    public class GetBankListService : IRequest<string>
    {
        
    }
    public class GetDesignationListService : IRequest<string>
    {
        
    }
    public class GetPaymentModeListService : IRequest<string>
    {

    }
    public class GetProofListService : IRequest<string>
    {

    }
    public class GetAccountTypeListService : IRequest<string>
    {

    }

    //All Save

    public class ManPowerDetailSaveService : IRequest<int>
    {
        public string ManPowerDetailSave { get; set; }
    }
    public class ManPowerBankDetailSaveService : IRequest<int>
    {
        public string ManPowerBankDetailSave { get; set; }
    }
    public class ManPowerFamilyDetailSaveService : IRequest<int>
    {
        public string ManPowerFamilyDetailSave { get; set; }
    }
    public class ManPowerProofDetailSaveService : IRequest<int>
    {
        public string ManPowerProofDetailSave { get; set; }
    }

    //All List

    public class GetManpowerListService : IRequest<string>
    {

    }
    public class GetManpowerBankListService : IRequest<string>
    {
        public string ManpowerBankList { get; set; }

    }
    public class GetManpowerFamilyListService : IRequest<string>
    {
        public string ManpowerFamilyList { get; set; }

    }
    public class GetManpowerProofListService : IRequest<string>
    {
        public string ManpowerProofList { get; set; }
    }

    // All Delete

    public class ManPowerBankDeleteService : IRequest<int>
    {
        public string ManPowerBankDelete { get; set; }
    }
    public class ManPowerFamilyDeleteService : IRequest<int>
    {
        public string ManPowerFamilyDelete { get; set; }
    }
    public class ManPowerProofDeleteService : IRequest<int>
    {
        public string ManPowerProofDelete { get; set; }
    }

    // fetch

    public class ManPowerDetailFetchService : IRequest<Table4>
    {
        public string ManPowerDetailFetch { get; set; }
    }

    // Assign Manpower

    public class GetClassificationListService : IRequest<string>
    {
        public string Classification { get; set; }
    }
    public class GetContractIdListService : IRequest<string>
    {
        public string ContractId { get; set; }
    }
    public class GetServiceListService : IRequest<string>
    {
        public string Service { get; set; }
    }
    public class GetManpowerNameListService : IRequest<string>
    {
        public string ManpowerName { get; set; }
    }
    public class GetAssignManpowerListService : IRequest<string>
    {
        public int contractid { get; set; }
    }
    public class GetAssignManpowerSaveService : IRequest<int>
    {
        public string AssignManpowerSave { get; set; }
    }
    public class GetAssignManpowerDeleteService : IRequest<int>
    {
        public string AssignManpowerDelete { get; set; }
    }

    // Assign field officer

    public class GetFieldOfficerSaveService : IRequest<int>
    {
        public string FieldOfficerSave { get; set; }
    }
    public class GetFieldOfficerDeleteService : IRequest<int>
    {
        public string FieldOfficerDelete { get; set; }
    }
    public class GetFieldOfficerService : IRequest<string>
    {
        public string FieldOfficer { get; set; }
    }
    public class GetAllManpowerNameService : IRequest<string>
    {
       
    }
    public class GetManpowerDirectService : IRequest<string>
    {

    }
    public class SaveManpowerdirectService : IRequest<int>
    {
        public string SaveManpowerdirect { get; set; }
    }
    public class GetShiftdetailsdirectService : IRequest<string>
    {
        public string GetShiftdetailsdirect { get; set; }
    }
}
