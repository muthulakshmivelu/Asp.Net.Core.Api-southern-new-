using Asp.Net.Core.Business.Services.Masters.State;
using MediatR;
using ERP.UserControl.DataContext.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.Net.Core.Business.Services.State
{

    public class StateSaveHandler : IRequestHandler<StateSaveService, int>
    {
        private readonly IUnitOfWork unitOfWork;

        public StateSaveHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(StateSaveService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.StateRepository.StateSave(request.StateSave);
            unitOfWork.Commit();
            return user;
        }
    }

    public class StateListHandler : IRequestHandler<StateListService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public StateListHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(StateListService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.StateRepository.StateList(request.StateList);
            return user;
        }
    }
    public class StateFetchHandler : IRequestHandler<StateFetchService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public StateFetchHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(StateFetchService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.StateRepository.StateFetch(request.StateFetch);
            unitOfWork.Commit();
            return user;
        }
    }

    public class StateDeleteHandler : IRequestHandler<StateDeleteService, int>
    {
        private readonly IUnitOfWork unitOfWork;

        public StateDeleteHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(StateDeleteService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.StateRepository.StateDelete(request.StateDelete);
            unitOfWork.Commit();
            return user;
        }
    }

}
