using Asp.Net.Core.Business.Services.Department;
using Asp.Net.Core.Business.Services.Designation;
using Asp.Net.Core.DataModel.Utilities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net.Core.Api.Controllers.Department
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class DepartmentController : Controller
    {
        private readonly IMediator mediator;

        public DepartmentController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        //[HttpGet]
        //[Route("DepartmentList")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<IActionResult> DepartmentList()
        //{
        //    var response = await mediator.Send(new DepartmentListService());
        //    return Ok(JsonConvert.SerializeObject(response));
        //}

        //[HttpPost]
        //[Route("TestFile")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<IActionResult> TestFile(IFormFile file)
        //{
        //    var result = Utilities.FileUpload(file);
        //    return Ok(result);
        //}

        //[HttpPost]
        //[Route("DepartmentSave")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<IActionResult> DepartmentSave([FromBody] DepartmentSaveService values)
        //{
        //    var response = await mediator.Send(values);
        //    return Ok(JsonConvert.SerializeObject(response));
        //}

        //[HttpPost]
        //[Route("DepartmentFetch")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<IActionResult> DepartmentFetch([FromBody] DepartmentFetchService values)
        //{
        //    var response = await mediator.Send(values);
        //    return Ok(JsonConvert.SerializeObject(response));
        //}

        //[HttpPost]
        //[Route("DepartmentDelete")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<IActionResult> DepartmentDelete([FromBody] DepartmentDeleteService values)
        //{
        //    var response = await mediator.Send(values);
        //    return Ok(JsonConvert.SerializeObject(response));
        //}

        //[HttpPost]
        //[Route("DepartmentListReport")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<IActionResult> ERPInvoice(DepartmentReportService values)
        //{
        //    DataSet response = await mediator.Send(values);
        //    try
        //    {
        //        var webRootPath = Path.GetFullPath(Path.Combine("wwwroot/reports/DepartmentListReport.frx"));

        //        FileStreamResult stream = Utilities.ReturnStreamReport(response, webRootPath);
        //        return stream;
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex);
        //    }
        //}

        [HttpPost]
        [Route("DepartmentSave")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DepartmentSave([FromBody] DepartmentSaveService values)
        {
            var response = await mediator.Send(values);
            return Ok(JsonConvert.SerializeObject(response));
        }

        [HttpGet]
        [Route("DepartmentList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DepartmentList()
        {
            var response = await mediator.Send(new DepartmentListService());
            return Ok(response);
        }

        [HttpPost]
        [Route("DepartmentFetch")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DepartmentFetch([FromBody] DepartmentFetchService values)
        {
            var response = await mediator.Send(values);
            return Ok(response);
        }

        [HttpPost]
        [Route("DepartmentDelete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DepartmentDelete([FromBody] DepartmentDeleteService values)
        {
            var response = await mediator.Send(values);
            return Ok(JsonConvert.SerializeObject(response));
        }
    }
}
