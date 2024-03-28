using Asp.Net.Core.Business.Services.Manpower;
using MediatR;
using ERP.UserControl.DataContext.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Asp.Net.Core.DataModel.Models;

namespace Asp.Net.Core.Business.Services.Contract.CustomerMaster
{
    public class CustomerSaveHandler : IRequestHandler<CustomerSaveService, int>
    {
        private readonly IUnitOfWork unitOfWork;

        public CustomerSaveHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CustomerSaveService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.CustomerMasterRepository.CustomerSave(request.CustomerSave);
            unitOfWork.Commit();
            return user;
        }
    }

    public class CustomerListHandler : IRequestHandler<CustomerListService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public CustomerListHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(CustomerListService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.CustomerMasterRepository.CustomerList();
            return user;
        }
    }
    public class CustomerFetchHandler : IRequestHandler<CustomerFetchService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public CustomerFetchHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(CustomerFetchService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.CustomerMasterRepository.CustomerFetch(request.CustomerFetch);
            unitOfWork.Commit();
            return user;
        }
    }
}
