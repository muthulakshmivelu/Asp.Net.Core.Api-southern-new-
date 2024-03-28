using ERP.UserControl.DataContext.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Asp.Net.Core.Business.Services.EmployeeLeaveType.EmployeeLeaveTypeService;

namespace Asp.Net.Core.Business.Services.EmployeeLeaveType
{
    public class EmployeeLeaveTypeHandler : IRequestHandler<EmployeeLeaveTypeListService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public EmployeeLeaveTypeHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<string> Handle(EmployeeLeaveTypeListService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.EmployeeLeaveTypeRepository.LeaveTypeList();
            return user;

        }
    }
}
