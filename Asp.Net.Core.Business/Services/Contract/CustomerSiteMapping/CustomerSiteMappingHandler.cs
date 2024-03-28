using Asp.Net.Core.Business.Services.Manpower;
using MediatR;
using ERP.UserControl.DataContext.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Asp.Net.Core.Business.Services.Masters.State;

namespace Asp.Net.Core.Business.Services.Contract.CustomerSiteMapping
{
    // customer drop down
    public class GetCustomerDropDownHandler : IRequestHandler<GetCustomerDropDownService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetCustomerDropDownHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(GetCustomerDropDownService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.CustomerSiteMappingRepository.GetCustomerDropDown();
            return user;
        }
    }
    //delete
    public class BranchMasterDeleteHandler : IRequestHandler<BranchMasterDeleteService, int>
    {
        private readonly IUnitOfWork unitOfWork;

        public BranchMasterDeleteHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(BranchMasterDeleteService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.CustomerSiteMappingRepository.BranchMasterDelete(request.SiteMapping);
            unitOfWork.Commit();
            return user;
        }
    }

    public class SiteMasterDeleteHandler : IRequestHandler<SiteMasterDeleteService, int>
    {
        private readonly IUnitOfWork unitOfWork;

        public SiteMasterDeleteHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(SiteMasterDeleteService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.CustomerSiteMappingRepository.SiteMasterDelete(request.SiteMapping);
            unitOfWork.Commit();
            return user;
        }
    }

    public class ClassificationMasterDeleteHandler : IRequestHandler<ClassificationMasterDeleteService, int>
    {
        private readonly IUnitOfWork unitOfWork;

        public ClassificationMasterDeleteHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(ClassificationMasterDeleteService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.CustomerSiteMappingRepository.ClassificationMasterDelete(request.SiteMapping);
            unitOfWork.Commit();
            return user;
        }
    }

    public class LocationlistHandler : IRequestHandler<LocationlistService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public LocationlistHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(LocationlistService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.CustomerSiteMappingRepository.Locationlist(request.Locationlist);
            unitOfWork.Commit();
            return user;
        }
    }

    public class ContractListAllocateHandler : IRequestHandler<ContractListAllocateService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public ContractListAllocateHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(ContractListAllocateService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.CustomerSiteMappingRepository.ContractListAllocate(request.ContractListAllocate);
            unitOfWork.Commit();
            return user;
        }
    }

    public class ContractServiceListHandler : IRequestHandler<ContractServiceListService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public ContractServiceListHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(ContractServiceListService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.CustomerSiteMappingRepository.ContractServiceList(request.ContractServiceList);
            unitOfWork.Commit();
            return user;
        }
    }

    public class ContractManpowerListHandler : IRequestHandler<ContractListbyCustomerService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public ContractManpowerListHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(ContractListbyCustomerService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.CustomerSiteMappingRepository.ContractListbyCustomer(request.customer_id);
            unitOfWork.Commit();
            return user;
        }
    }

    public class AllocationListHandler : IRequestHandler<AllocationListService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public AllocationListHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(AllocationListService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.CustomerSiteMappingRepository.AllocationList(request.contract_id);
            unitOfWork.Commit();
            return user;
        }
    }

    //public class GetContractListHandler : IRequestHandler<GetContractListService, string>
    //{
    //    private readonly IUnitOfWork unitOfWork;

    //    public GetContractListHandler(IUnitOfWork unitOfWork)
    //    {
    //        this.unitOfWork = unitOfWork;
    //    }

    //    public async Task<string> Handle(GetContractListService request, CancellationToken cancellationToken)
    //    {
    //        var user = await unitOfWork.CustomerSiteMappingRepository.GetContractList();
    //        return user;
    //    }
    //}

    // list
    public class GetBranchMasterListHandler : IRequestHandler<GetBranchMasterListService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetBranchMasterListHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(GetBranchMasterListService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.CustomerSiteMappingRepository.GetBranchMasterList(request.SiteMapping);
            return user;
        }
    }
    public class GetSiteMasterListHandler : IRequestHandler<GetSiteMasterListService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetSiteMasterListHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(GetSiteMasterListService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.CustomerSiteMappingRepository.GetSiteMasterList(request.SiteMapping);
            return user;
        }
    }
    public class GetClassificationMasterListHandler : IRequestHandler<GetClassificationMasterListService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetClassificationMasterListHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(GetClassificationMasterListService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.CustomerSiteMappingRepository.GetClassificationMasterList(request.SiteMapping);
            return user;
        }
    }

    //save

    public class BranchMasterSaveHandler : IRequestHandler<BranchMasterSaveService, int>
    {
        private readonly IUnitOfWork unitOfWork;

        public BranchMasterSaveHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(BranchMasterSaveService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.CustomerSiteMappingRepository.BranchMasterSave(request.SiteMapping);
            unitOfWork.Commit();
            return user;
        }
    }
    public class SiteMasterSaveHandler : IRequestHandler<SiteMasterSaveService, int>
    {
        private readonly IUnitOfWork unitOfWork;

        public SiteMasterSaveHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(SiteMasterSaveService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.CustomerSiteMappingRepository.SiteMasterSave(request.SiteMapping);
            unitOfWork.Commit();
            return user;
        }
    }
    public class ClassificationMasterSaveHandler : IRequestHandler<ClassificationMasterSaveService, int>
    {
        private readonly IUnitOfWork unitOfWork;

        public ClassificationMasterSaveHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(ClassificationMasterSaveService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.CustomerSiteMappingRepository.ClassificationMasterSave(request.SiteMapping);
            unitOfWork.Commit();
            return user;
        }
    }

    //////////////////// Allocate Manpower ////////////
    ///
    public class AllocateManpowerSiteSaveHandler : IRequestHandler<AllocateManpowerSaveService, int>
    {
        private readonly IUnitOfWork unitOfWork;

        public AllocateManpowerSiteSaveHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(AllocateManpowerSaveService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.CustomerSiteMappingRepository.AllocateManpowerSiteSave(request.AllocateManpower);
            unitOfWork.Commit();
            return user;
        }
    }

    public class GetMAServiceListHandler : IRequestHandler<GetMAServiceListService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetMAServiceListHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(GetMAServiceListService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.CustomerSiteMappingRepository.GetMAServiceList(request.AllocateManpower);
            return user;
        }
    }

    public class AllocateManpowerSiteListHandler : IRequestHandler<AllocateManpowerSiteListService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public AllocateManpowerSiteListHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(AllocateManpowerSiteListService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.CustomerSiteMappingRepository.AllocateManpowerSiteList(request.AllocateManpower);
            return user;
        }
    }
    public class AllocateManpowerSiteDeleteHandler : IRequestHandler<AllocateManpowerSiteDeleteService, int>
    {
        private readonly IUnitOfWork unitOfWork;

        public AllocateManpowerSiteDeleteHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(AllocateManpowerSiteDeleteService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.CustomerSiteMappingRepository.AllocateManpowerSiteDelete(request.AllocateManpower);
            unitOfWork.Commit();
            return user;
        }
    }
    public class SaveLocationHandler : IRequestHandler<SaveLocationService, int>
    {
        private readonly IUnitOfWork unitOfWork;

        public SaveLocationHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(SaveLocationService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.CustomerSiteMappingRepository.SaveLocation(request.SaveLocation);
            unitOfWork.Commit();
            return user;
        }
    }
    public class GetLocationHandler : IRequestHandler<GetLocationService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetLocationHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(GetLocationService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.CustomerSiteMappingRepository.GetLocation(request.GetLocation);
            return user;
        }
    }
    public class DeleteLocationHandler : IRequestHandler<DeleteLocationService, int>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteLocationHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(DeleteLocationService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.CustomerSiteMappingRepository.DeleteLocation(request.DeleteLocation);
            unitOfWork.Commit();
            return user;
        }
    }
    public class GetContractListHandler : IRequestHandler<GetContractListService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetContractListHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(GetContractListService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.CustomerSiteMappingRepository.GetContractList();
            return user;
        }
    }

    public class LocationFetchHandler : IRequestHandler<LocationFetchService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public LocationFetchHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(LocationFetchService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.CustomerSiteMappingRepository.LocationFetch(request.LocationFetch);
            unitOfWork.Commit();
            return user;
        }
    }
}
