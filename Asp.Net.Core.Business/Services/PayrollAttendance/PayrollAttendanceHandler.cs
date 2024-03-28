using ERP.UserControl.DataContext.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.Net.Core.Business.Services.PayrollAttendance
{
    public class PayrollAttendanceHandler : IRequestHandler<PayrollAttendanceService, int>
    {
        private readonly IUnitOfWork unitOfWork;

        public PayrollAttendanceHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(PayrollAttendanceService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.PayrollAttendanceRepository.PayrollAttendanceSave(request.PayrollAttendanceSave);
            unitOfWork.Commit();
            return user;
        }
    }
    public class PayrollAttendanceListHandler : IRequestHandler<PayrollAttendanceListService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public PayrollAttendanceListHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(PayrollAttendanceListService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.PayrollAttendanceRepository.PayrollAttendanceList();
            return user;
        }
    }

    public class PayrollAttendanceGetByIdhandler : IRequestHandler<PayrollAttendanceGetByIdService, string>
    {
        private readonly IUnitOfWork unitofwork;

        public PayrollAttendanceGetByIdhandler(IUnitOfWork unitofwork)
        {
            this.unitofwork = unitofwork;
        }

        public async Task<string> Handle(PayrollAttendanceGetByIdService request, CancellationToken cancellationtoken)
        {
            var response = await unitofwork.PayrollAttendanceRepository.PayrollAttendanceGetById(request.empid);
            return response;
        }
    }



    public class PayrollAttendanceDeleteHandler : IRequestHandler<PayrollAttendanceDeleteService, int>
    {
        private readonly IUnitOfWork unitOfWork;

        public PayrollAttendanceDeleteHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(PayrollAttendanceDeleteService request, CancellationToken cancellationToken)
        {

            var user = await unitOfWork.PayrollAttendanceRepository.PayrollAttendanceDelete(request.inputId);
            unitOfWork.Commit();
            return user;
        }

    }

}
