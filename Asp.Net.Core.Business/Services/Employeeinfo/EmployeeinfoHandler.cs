using ERP.UserControl.DataContext.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.Net.Core.Business.Services.Employeeinfo
{
    public class EmployeeinfoListHandler : IRequestHandler<EmployeeinfoListService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public EmployeeinfoListHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(EmployeeinfoListService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.EmployeeinfoRepository.EmployeeinfoList();
            return user;
        }
    }
}
