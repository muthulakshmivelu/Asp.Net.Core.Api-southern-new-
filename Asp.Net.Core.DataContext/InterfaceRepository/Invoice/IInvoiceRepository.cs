using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.Core.DataContext.InterfaceRepository.Invoice
{
    public interface IInvoiceRepository
    {
        Task<DataSet> GenerateTaxInvoiceReport(string obj);
    }
}
