using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.Core.DataContext.InterfaceRepository.Designation
{
    public  interface IDesignationRepository
    {
        Task<int> DesignationSave(string value);
        Task<string> DesignationList();
        Task<string> DesignationFetch(string value);
        Task<int> DesignationDelete(string value);
    }
}
