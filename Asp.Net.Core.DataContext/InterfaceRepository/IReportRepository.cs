using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.Core.DataContext.InterfaceRepository
{
    public interface IReportRepository
    {
        Task<DataSet> ERPInvoiceReport(int invoiceId);
        Task<DataSet> OfferReport(dynamic obj);
        Task<DataSet> ExperienceReport(int employee_id);
        Task<DataSet> PayslipReport(dynamic obj);
    }
}
