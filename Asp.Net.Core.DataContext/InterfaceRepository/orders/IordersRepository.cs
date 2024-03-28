using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.Core.DataContext.InterfaceRepository.orders
{
    public interface IordersRepository
    {
        Task<int> ordersSave(string value);
        Task<string> ordersList(string value);
        Task<string> ordersFetch(string value);
        Task<int> ordersDelete(string value);
    }
}
