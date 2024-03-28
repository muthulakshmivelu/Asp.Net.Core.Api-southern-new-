using Asp.Net.Core.Business.Services.Contract.CustomerMaster;
using MediatR;
using ERP.UserControl.DataContext.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Asp.Net.Core.Business.Services.Manpower;

namespace Asp.Net.Core.Business.Services.Designation
{
    public class DesignationSaveHandler : IRequestHandler<DesignationSaveService, int>
    {
        private readonly IUnitOfWork unitOfWork;

        public DesignationSaveHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(DesignationSaveService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.DesignationRepository.DesignationSave(request.DesignationSave);
            unitOfWork.Commit();
            return user;
        }
    }

    public class DesignationListHandler : IRequestHandler<DesignationListService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public DesignationListHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(DesignationListService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.DesignationRepository.DesignationList();
            return user;
        }
    }
    public class DesignationFetchHandler : IRequestHandler<DesignationFetchService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public DesignationFetchHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(DesignationFetchService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.DesignationRepository.DesignationFetch(request.DesignationFetch);
            unitOfWork.Commit();
            return user;
        }
    }

    public class DesignationDeleteHandler : IRequestHandler<DesignationDeleteService, int>
    {
        private readonly IUnitOfWork unitOfWork;

        public DesignationDeleteHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(DesignationDeleteService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.DesignationRepository.DesignationDelete(request.DesignationDelete);
            unitOfWork.Commit();
            return user;
        }
    }
}
