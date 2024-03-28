using ERP.UserControl.DataContext.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.Net.Core.Business.Services.EmployeeLeaveMapping
{
    public class EmpLeaMapHandler: IRequestHandler<EmpLeaMapService, int>
    {
        private readonly IUnitOfWork unitOfWork;

        public EmpLeaMapHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(EmpLeaMapService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.EmpLeaMapRepository.EmpLeaSave(request.EmpLeaSave);
            unitOfWork.Commit();
            return user;
        }
    }
    public class EmpLeaMapListServiceHandler : IRequestHandler<EmpLeaMapListService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public EmpLeaMapListServiceHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(EmpLeaMapListService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.EmpLeaMapRepository.EmpLeaList();
            return user;
        }
    }
    public class GetEmpLeaveByIdhandler : IRequestHandler<GetEmpLeaveByIdService, string>
    {
        private readonly IUnitOfWork unitofwork;

        public GetEmpLeaveByIdhandler(IUnitOfWork unitofwork)
        {
            this.unitofwork = unitofwork;
        }

        public async Task<string> Handle(GetEmpLeaveByIdService request, CancellationToken cancellationtoken)
        {
            var response = await unitofwork.EmpLeaMapRepository.GetEmpLeaveById(request.empid);
            return response;
        }
    }


    public class EmpLeaMapDeleteServiceHandler : IRequestHandler<EmpLeaMapDeleteService, int>
    {
        private readonly IUnitOfWork unitOfWork;

        public EmpLeaMapDeleteServiceHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(EmpLeaMapDeleteService request, CancellationToken cancellationToken)
        {

            var user = await unitOfWork.EmpLeaMapRepository.EmpLeaDelete(request.inputId);
            unitOfWork.Commit();
            return user;
        }

    }
}
