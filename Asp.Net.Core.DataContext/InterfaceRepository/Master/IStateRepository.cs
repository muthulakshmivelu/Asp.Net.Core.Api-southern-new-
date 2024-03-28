using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.Core.DataContext.InterfaceRepository.Master
{
    public interface IStateRepository
    {
        Task<int> StateSave(string value);
        Task<string> StateList(string value);
        Task<string> StateFetch(string value);
        Task<int> StateDelete(string value);
    }
}
