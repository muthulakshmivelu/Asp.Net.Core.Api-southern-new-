using Asp.Net.Core.Business.Services.EmployeeLeaveMapping;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Asp.Net.Core.Api.Controllers.EmployeeLeaveMapping
{
    [Route("api/[controller]")]
    [ApiController]


    [Authorize]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class EmpLeaMapController : ControllerBase
    {
        private readonly IMediator mediator;

        public EmpLeaMapController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("EmpLeaSave")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> EmpLeaSave([FromBody] EmpLeaMapService values)
        {
            var response = await mediator.Send(values);
            return Ok(JsonConvert.SerializeObject(response));
        }

        [HttpGet]
        [Route("EmpLeaList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> EmpLeaList()
        {
            var response = await mediator.Send(new EmpLeaMapListService());
            return Ok(response);
        }
        [HttpGet]
        [Route("GetEmpLeaveById/{empid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int empid)

        {
            // Perform input validation
            if (empid <= 0)
            {
                return BadRequest("Invalid employee ID");
            }

            var service = new GetEmpLeaveByIdService { empid = empid };
            var response = await mediator.Send(service);

            return Ok(response);
        }




        [HttpPost]
        [Route("EmpLeaDelete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> EmpLeaDelete([FromBody] EmpLeaMapDeleteService values)
        {
            var response = await mediator.Send(values);
            return Ok(JsonConvert.SerializeObject(response));
        }
    }
}
