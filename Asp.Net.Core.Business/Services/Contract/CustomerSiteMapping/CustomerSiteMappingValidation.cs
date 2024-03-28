using Asp.Net.Core.Business.Services.Manpower;
using Asp.Net.Core.Business.Services.Masters.State;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.Net.Core.Business.Services.Contract.CustomerSiteMapping
{
    public class GetCustomerDropDownValidation : AbstractValidator<GetCustomerDropDownService>
    {

    }
    public class BranchMasterDeleteValidation : AbstractValidator<BranchMasterDeleteService>
    {

    }
    public class SiteMasterDeleteValidation : AbstractValidator<SiteMasterDeleteService>
    {

    }
    public class ClassificationMasterDeleteValidation : AbstractValidator<ClassificationMasterDeleteService>
    {

    }
    public class LocationlistValidation : AbstractValidator<LocationlistService>
    {

    }
    public class ContractListAllocateValidation : AbstractValidator<ContractListAllocateService>
    {

    }

    public class ContractServiceListValidation : AbstractValidator<ContractServiceListService>
    {

    }
    public class ContractManpowerListValidation : AbstractValidator<ContractListbyCustomerService>
    {

    }

    public class AllocationListValidation : AbstractValidator<AllocationListService>
    {

    }

    public class GetBranchMasterListValidation : AbstractValidator<GetBranchMasterListService>
    {

    }
    public class GetSiteMasterListValidation : AbstractValidator<GetSiteMasterListService>
    {

    }
    public class GetClassificationMasterListValidation : AbstractValidator<GetClassificationMasterListService>
    {

    }
    public class BranchMasterSaveValidation : AbstractValidator<BranchMasterSaveService>
    {

    }
    public class SiteMasterSaveValidation : AbstractValidator<SiteMasterSaveService>
    {

    }
    public class ClassificationMasterSaveValidation : AbstractValidator<ClassificationMasterSaveService>
    {

    }

    //////////////////// Allocate Manpower ////////////
    ///
    public class AllocateManpowerSiteSaveValidation : AbstractValidator<AllocateManpowerSaveService>
    {

    }
    public class GetMAServiceListValidation : AbstractValidator<GetMAServiceListService>
    {

    }
    public class AllocateManpowerSiteListValidation : AbstractValidator<AllocateManpowerSiteListService>
    {

    }
    public class AllocateManpowerSiteDeleteValidation : AbstractValidator<AllocateManpowerSiteDeleteService>
    {

    }
    public class SaveLocationValidation : AbstractValidator<SaveLocationService>
    {

    }
    public class GetLocationValidation : AbstractValidator<GetLocationService>
    {

    }
    public class DeleteLocationValidation : AbstractValidator<DeleteLocationService>
    {

    }
    public class GetContractListValidation : AbstractValidator<GetContractListService>
    {

    }
    public class LocationFetchValidation : AbstractValidator<LocationFetchService>
    {

    }
}
