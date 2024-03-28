using Asp.Net.Core.Business.Services.Contract.CustomerMaster;
using Asp.Net.Core.Business.Services.Manpower;
using Asp.Net.Core.DataModel.Models;
using MediatR;
using ERP.UserControl.DataContext.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.Net.Core.Business.Services.Contract
{
    public class ContractSaveHandler : IRequestHandler<ContractSaveService, int>
    {
        private readonly IUnitOfWork unitOfWork;

        public ContractSaveHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(ContractSaveService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.ContractRepository.ContractSave(request.Contract);
            unitOfWork.Commit();
            return user;
        }
    }
    public class ContractDeleteHandler : IRequestHandler<ContractDeleteService, int>
    {
        private readonly IUnitOfWork unitOfWork;

        public ContractDeleteHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(ContractDeleteService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.ContractRepository.ContractDelete(request.Contract);
            unitOfWork.Commit();
            return user;
        }
    }
    public class GetConsumableRequirementHandler : IRequestHandler<GetConsumableRequirementService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetConsumableRequirementHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(GetConsumableRequirementService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.ContractRepository.GetConsumableRequirement(request.Contract);
            return user;
        }
    }
    public class GetContractByAllCustomerHandler : IRequestHandler<GetContractByAllCustomerService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetContractByAllCustomerHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(GetContractByAllCustomerService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.ContractRepository.GetContractByAllCustomer(request.Contract);
            return user;
        }
    }
    public class GetContractDetailsHandler : IRequestHandler<GetContractDetailsService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetContractDetailsHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(GetContractDetailsService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.ContractRepository.GetContractDetails(request.Contract);
            return user;
        }
    }
    public class GetContractHandler : IRequestHandler<GetContractService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetContractHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(GetContractService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.ContractRepository.GetContract(request.Contract);
            return user;
        }
    }
    public class GetContractMasterHandler : IRequestHandler<GetContractMasterService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetContractMasterHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(GetContractMasterService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.ContractRepository.GetContractMaster(request.Contract);
            return user;
        }
    }
    public class GetAllCustomerHandler : IRequestHandler<GetAllCustomerService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetAllCustomerHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(GetAllCustomerService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.ContractRepository.GetAllCustomer(request.Contract);
            return user;
        }
    }
    public class GetContractsListByCustomerIdHandler : IRequestHandler<GetContractsListByCustomerIdService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetContractsListByCustomerIdHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(GetContractsListByCustomerIdService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.ContractRepository.GetContractsListByCustomerId(request.Contract);
            return user;
        }
    }

    public class GetDeparmentAsServiceListHandler : IRequestHandler<GetDeparmentAsServiceListService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetDeparmentAsServiceListHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(GetDeparmentAsServiceListService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.ContractRepository.GetDeparmentAsServiceList();
            return user;
        }
    }
    public class GetDesignetionByServiceIDHandler : IRequestHandler<GetDesignetionByServiceIDService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetDesignetionByServiceIDHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(GetDesignetionByServiceIDService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.ContractRepository.GetDesignetionByService(request.DesignetionByServiceID);
            unitOfWork.Commit();
            return user;
        }
    }
    public class GetCustomerNameListHandler : IRequestHandler<GetCustomerNameListService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetCustomerNameListHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(GetCustomerNameListService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.ContractRepository.GetCustomerNameList();
            return user;
        }
    }
    public class ContractDetailsFetchHandler : IRequestHandler<ContractDetailsFetchService, Table6>
    {
        private readonly IUnitOfWork unitOfWork;

        public ContractDetailsFetchHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Table6> Handle(ContractDetailsFetchService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.ContractRepository.ContractDetailsFetch(request.ContractDetailsFetch);
            unitOfWork.Commit();
            return user;
        }
    }
    public class getclienttypeHandler : IRequestHandler<getclienttypeService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public getclienttypeHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(getclienttypeService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.ContractRepository.getclienttype();
            return user;
        }
    }
}
