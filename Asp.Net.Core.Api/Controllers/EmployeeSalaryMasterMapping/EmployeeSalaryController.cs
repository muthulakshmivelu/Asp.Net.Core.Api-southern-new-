using Asp.Net.Core.Business.Services.EmployeeSalaryMasterMapping;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Asp.Net.Core.Api.Controllers.EmployeeSalaryMasterMapping
{
    [Route("api/[controller]")]
    [ApiController]

    [Authorize]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class EmployeeSalaryController : ControllerBase
    {
        private readonly IMediator mediator;

        public EmployeeSalaryController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("EmployeeSalarySave")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> EmployeeSalarySave([FromBody] EmployeeSalarySaveService values)
        {
            var response = await mediator.Send(values);
            return Ok(JsonConvert.SerializeObject(response));
        }

        [HttpGet]
        [Route("EmployeeSalaryList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> EmployeeSalaryList()
        {
            var response = await mediator.Send(new EmployeeSalaryListService());
            return Ok(response);
        }
        [HttpGet]
        [Route("GetById/{empid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int empid)

        {
            // Perform input validation
            if (empid <= 0)
            {
                return BadRequest("Invalid employee ID");
            }

            var service = new GetByIdService { empid = empid };
            var response = await mediator.Send(service);

            return Ok(response);
        }


        [HttpPost]
        [Route("EmployeeSalaryDelete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> EmployeeSalaryDelete([FromBody] EmployeeSalaryDeleteService values)
        {
            var response = await mediator.Send(values);
            return Ok(JsonConvert.SerializeObject(response));
        }
    }
}
