using ERP.UserControl.DataContext.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.Net.Core.Business.Services.Payslip
{
    public class PayslipHandler : IRequestHandler<PayslipService, int>
    {
        private readonly IUnitOfWork unitOfWork;

        public PayslipHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public Task<int> Handle(PayslipService request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class PayslipListHandler : IRequestHandler<PayslipListService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public PayslipListHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(PayslipListService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.PayslipRepository.PayslipList();
            return user;
        }
    }


    public class PayslipDeleteHandler : IRequestHandler<PayslipDeleteService, int>
    {
        private readonly IUnitOfWork unitOfWork;

        public PayslipDeleteHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(PayslipDeleteService request, CancellationToken cancellationToken)
        {

            var user = await unitOfWork.PayslipRepository.PayslipDelete(request.month, request.year);
            unitOfWork.Commit();
            return user;
        }

    }

}
