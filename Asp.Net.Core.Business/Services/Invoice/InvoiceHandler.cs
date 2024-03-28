using Asp.Net.Core.Business.Services.Department;
using MediatR;
using ERP.UserControl.DataContext.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Asp.Net.Core.Business.Services.Invoice
{
    public class GenerateTaxInvoiceReportHandler : IRequestHandler<GenerateTaxInvoiceReportService, DataSet>
    {
        private readonly IUnitOfWork unitOfWork;
        public GenerateTaxInvoiceReportHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<DataSet> Handle(GenerateTaxInvoiceReportService request, CancellationToken cancellationToken)
        {
            var result = await unitOfWork.InvoiceRepository.GenerateTaxInvoiceReport(request.GenerateReport);
            unitOfWork.Commit();
            return result;
        }
    }
}
