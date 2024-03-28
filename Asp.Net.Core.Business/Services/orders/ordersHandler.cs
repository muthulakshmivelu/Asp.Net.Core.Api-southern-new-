using Asp.Net.Core.Business.Services.Department;
using ERP.UserControl.DataContext.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.Net.Core.Business.Services.orders
{
    public class ordersSaveHandler : IRequestHandler<ordersSaveService, int>
    {
        private readonly IUnitOfWork unitOfWork;

        public ordersSaveHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(ordersSaveService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.OrdersRepository.ordersSave(request.ordersSave);
            unitOfWork.Commit();
            return user;
        }
    }

    public class ordersListHandler : IRequestHandler<ordersListService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public ordersListHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(ordersListService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.OrdersRepository.ordersList(request.ordersList);
            return user;
        }
    }
    public class ordersFetchHandler : IRequestHandler<ordersFetchService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public ordersFetchHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(ordersFetchService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.OrdersRepository.ordersFetch(request.ordersFetch);
            unitOfWork.Commit();
            return user;
        }
    
    }

    public class ordersDeleteHandler : IRequestHandler<ordersDeleteService, int>
    {
        private readonly IUnitOfWork unitOfWork;

        public ordersDeleteHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(ordersDeleteService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.OrdersRepository.ordersDelete(request.ordersDelete);
            unitOfWork.Commit();
            return user;
        }
    }
}
