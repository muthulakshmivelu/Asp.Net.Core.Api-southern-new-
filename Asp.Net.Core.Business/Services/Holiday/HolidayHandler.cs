using ERP.UserControl.DataContext.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.Net.Core.Business.Services.Holiday
{
    public class HolidayHandler : IRequestHandler<HolidayService, int>
    {
        private readonly IUnitOfWork unitOfWork;

        public HolidayHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(HolidayService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.HolidayRepository.HolidaySave(request.HolidaySave);
            unitOfWork.Commit();
            return user;
        }
    }
    public class HolidayListHandler : IRequestHandler<HolidayListService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public HolidayListHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(HolidayListService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.HolidayRepository.HolidayList();
            return user;
        }
    }


    public class HolidayDeleteHandler : IRequestHandler<HolidayDeleteService, int>
    {
        private readonly IUnitOfWork unitOfWork;

        public HolidayDeleteHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(HolidayDeleteService request, CancellationToken cancellationToken)
        {

            var user = await unitOfWork.HolidayRepository.HolidayDelete(request.holidayid);
            unitOfWork.Commit();
            return user;
        }

    }
}
