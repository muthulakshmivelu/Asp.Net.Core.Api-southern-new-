using Asp.Net.Core.DataModel.Models.Department;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Asp.Net.Core.Business.Services.Invoice
{
    public class GenerateTaxInvoiceReportService : IRequest<DataSet>
    {
        public string GenerateReport { get; set; }
    }
}
