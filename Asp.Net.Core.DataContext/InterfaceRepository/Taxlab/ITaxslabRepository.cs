using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.Core.DataContext.InterfaceRepository.Taxlab
{
    public interface ITaxslabRepository
    {
        Task<int> TaxslabSave(string value);
        Task<string> TaxslabList();

        Task<int> TaxslabDelete(int taxslabid);

    }
}
