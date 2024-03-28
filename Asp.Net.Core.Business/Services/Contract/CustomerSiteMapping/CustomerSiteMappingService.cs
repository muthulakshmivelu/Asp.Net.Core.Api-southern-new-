using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.Net.Core.Business.Services.Contract.CustomerSiteMapping
{
    //Customer drop down
    public class GetCustomerDropDownService : IRequest<string>
    {

    }
    //delete
    public class BranchMasterDeleteService : IRequest<int>
    {
        public string SiteMapping { get; set; }
    }
    public class SiteMasterDeleteService : IRequest<int>
    {
        public string SiteMapping { get; set; }
    }
    public class ClassificationMasterDeleteService : IRequest<int>
    {
        public string SiteMapping { get; set; }
    }
    public class LocationlistService : IRequest<string>
    {
        public string Locationlist { get; set; }
    }

    public class ContractListAllocateService : IRequest<string>
    {
        public string ContractListAllocate { get; set; }
    }
    public class ContractServiceListService : IRequest<string>
    {
        public string ContractServiceList { get; set; }
    }
    public class ContractListbyCustomerService : IRequest<string>
    {
        public int customer_id { get; set; }
    }

    public class AllocationListService : IRequest<string>
    {
        public int contract_id { get; set; }
    }


    //list
    public class GetBranchMasterListService : IRequest<string>
    {
        public string SiteMapping { get; set; }

    }
    public class GetSiteMasterListService : IRequest<string>
    {
        public string SiteMapping { get; set; }

    }
    public class GetClassificationMasterListService : IRequest<string>
    {
        public string SiteMapping { get; set; }
    }

    //save

    public class BranchMasterSaveService : IRequest<int>
    {
        public string SiteMapping { get; set; }
    }
    public class SiteMasterSaveService : IRequest<int>
    {
        public string SiteMapping { get; set; }
    }
    public class ClassificationMasterSaveService : IRequest<int>
    {
        public string SiteMapping { get; set; }
    }


    //////////////////// Allocate Manpower ////////////
    ///
    public class AllocateManpowerSaveService : IRequest<int>
    {
        public string AllocateManpower { get; set; }
    }
    public class GetMAServiceListService : IRequest<string>
    {
        public string AllocateManpower { get; set; }
    }
    public class AllocateManpowerSiteListService : IRequest<string>
    {
        public string AllocateManpower { get; set; }
    }
    public class AllocateManpowerSiteDeleteService : IRequest<int>
    {
        public string AllocateManpower { get; set; }
    }

    public class SaveLocationService : IRequest<int>
    {
        public string SaveLocation { get; set; }
    }
    public class DeleteLocationService : IRequest<int>
    {
        public string DeleteLocation { get; set; }
    }
    public class GetLocationService : IRequest<string>
    {
        public string GetLocation { get; set; }

    }
    public class GetContractListService : IRequest<string>
    {

    }
    public class LocationFetchService : IRequest<string>
    {
        public string LocationFetch { get; set; }
    }
}
