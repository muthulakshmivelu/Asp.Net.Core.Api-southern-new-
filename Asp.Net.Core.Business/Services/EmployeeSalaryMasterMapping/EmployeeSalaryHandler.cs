using ERP.UserControl.DataContext.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.Net.Core.Business.Services.EmployeeSalaryMasterMapping
{
    public class EmployeeSalaryHandler : IRequestHandler<EmployeeSalarySaveService, int>
    {
        private readonly IUnitOfWork unitOfWork;

        public EmployeeSalaryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async  Task<int> Handle(EmployeeSalarySaveService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.EmployeeLeaveRepository.EmployeeSalarySave(request.EmployeeSalarySave);
            unitOfWork.Commit();
            return user;
        }
    }
    public class EmployeeSalayListHandler : IRequestHandler<EmployeeSalaryListService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public EmployeeSalayListHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(EmployeeSalaryListService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.EmployeeLeaveRepository.EmployeeSalaryList();
            return user;
        }
    }

    public class GetByIdhandler : IRequestHandler<GetByIdService, string>
    {
        private readonly IUnitOfWork unitofwork;

        public GetByIdhandler(IUnitOfWork unitofwork)
        {
            this.unitofwork = unitofwork;
        }

        public async Task<string> Handle(GetByIdService request, CancellationToken cancellationtoken)
        {
            var response = await unitofwork.EmployeeLeaveRepository.GetById(request.empid);
            return response;
        }
    }


    //public class EmployeeSalaryDeleteHandler : IRequestHandler<EmployeeSalaryDeleteService, int>
    //{
    //    private readonly IUnitOfWork unitOfWork;

    //    public EmployeeSalaryDeleteHandler(IUnitOfWork unitOfWork)
    //    {
    //        this.unitOfWork = unitOfWork;
    //    }

    //    public async Task<int> Handle(EmployeeSalaryDeleteService request, CancellationToken cancellationToken)
    //    {
    //        var user = await unitOfWork.EmployeeSalaryRepository.EmployeeSalaryDelete(request.EmployeeSalaryDelete);
    //        unitOfWork.Commit();
    //        return user;
    //    }
    //}
    public class EmployeeSalaryDeleteHandler : IRequestHandler<EmployeeSalaryDeleteService, int>
    {
        private readonly IUnitOfWork unitOfWork;

        public EmployeeSalaryDeleteHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(EmployeeSalaryDeleteService request, CancellationToken cancellationToken)
        {

            var user = await unitOfWork.EmployeeLeaveRepository.EmployeeSalaryDelete(request.inputId);
            unitOfWork.Commit();
            return user;
        }

    }
}
