using Asp.Net.Core.Business.Services.Department;
using Asp.Net.Core.DataModel.Utilities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using System;
using Asp.Net.Core.Business.Services.Invoice;

namespace Asp.Net.Core.Api.Controllers.Invoice
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class InvoiceController : ControllerBase
    {
        private readonly IMediator mediator;

        public InvoiceController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("GenerateTaxInvoiceReport")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GenerateTaxInvoiceReport(GenerateTaxInvoiceReportService values)
        {
            DataSet response = await mediator.Send(values);
            try
            {
                var webRootPath = Path.GetFullPath(Path.Combine("wwwroot/reports/Invoice_by_contract.frx"));

                FileStreamResult stream = Utilities.ReturnStreamReport(response, webRootPath);
                return stream;
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
