using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.Core.Business.Services.orders
{
    public class ordersSaveService : IRequest<int>
    {
        public string ordersSave { get; set; }
    }
    public class ordersListService : IRequest<string>
    {
        public string ordersList { get; set; }
    }
    public class ordersFetchService : IRequest<string>
    {
        public string ordersFetch { get; set; }
    }
    public class ordersDeleteService : IRequest<int>
    {
        public string ordersDelete { get; set; }
    }
}
