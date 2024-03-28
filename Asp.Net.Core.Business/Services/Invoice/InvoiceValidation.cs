using Asp.Net.Core.Business.Services.Department;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.Net.Core.Business.Services.Invoice
{
    public class GenerateTaxInvoiceReportValidation : AbstractValidator<GenerateTaxInvoiceReportService>
    {
    }
}
