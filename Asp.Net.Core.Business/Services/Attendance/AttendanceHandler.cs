using Asp.Net.Core.Business.Services.Contract;
using MediatR;
using ERP.UserControl.DataContext.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Asp.Net.Core.Business.Services.Department;
using Asp.Net.Core.DataModel.Models.Department;

namespace Asp.Net.Core.Business.Services.Attendance
{
    public class AttendanceStatusListHandler : IRequestHandler<AttendanceStatusListService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public AttendanceStatusListHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(AttendanceStatusListService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.AttendanceRepository.AttendanceStatusList();
            return user;
        }
    }

    public class CustomerBranchSiteDropDownListHandler : IRequestHandler<CustomerBranchSiteDropDownListService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public CustomerBranchSiteDropDownListHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(CustomerBranchSiteDropDownListService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.AttendanceRepository.CustomerBranchSiteDropDownList(request.AttendanceDropDownList);
            return user;
        }
    }

    public class GetManpowerDetailsListHandler : IRequestHandler<GetManpowerDetailsListService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetManpowerDetailsListHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(GetManpowerDetailsListService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.AttendanceRepository.GetManpowerDetailsList(request.ManpowerDetails);
            return user;
        }
    }
    public class ManPowerAttendanceSaveHandler : IRequestHandler<ManPowerAttendanceSaveService, int>
    {
        private readonly IUnitOfWork unitOfWork;

        public ManPowerAttendanceSaveHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(ManPowerAttendanceSaveService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.AttendanceRepository.ManPowerAttendanceSave(request.AttendanceSave);
            unitOfWork.Commit();
            return user;
        }
    }



    public class GetManpowerPivotDetailsListHandler : IRequestHandler<GetManpowerPivotDetailsListService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetManpowerPivotDetailsListHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(GetManpowerPivotDetailsListService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.AttendanceRepository.GetManpowerPivotDetailsList(request.GetManpowerPivotDetailsList);
            return user;
        }
    }

}
