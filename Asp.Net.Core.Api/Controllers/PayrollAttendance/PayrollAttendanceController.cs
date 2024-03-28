using Asp.Net.Core.Business.Services.PayrollAttendance;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Asp.Net.Core.Api.Controllers.PayrollAttendance
{
    [Route("api/[controller]")]
    [ApiController]



    [Authorize]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class PayrollAttendanceController : ControllerBase
    {
        private readonly IMediator mediator;

        public PayrollAttendanceController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("PayrollAttendanceSave")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> PayrollAttendanceSave([FromBody] PayrollAttendanceService values)
        {
            var response = await mediator.Send(values);
            return Ok(JsonConvert.SerializeObject(response));
        }

        [HttpGet]
        [Route("PayrollAttendanceList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> PayrollAttendanceList()
        {
            var response = await mediator.Send(new PayrollAttendanceListService());
            return Ok(response);
        }
        [HttpGet]
        [Route("PayrollAttendanceGetById/{empid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> PayrollAttendanceGetById(int empid)

        {
            // Perform input validation
            if (empid <= 0)
            {
                return BadRequest("Invalid employee ID");
            }

            var service = new PayrollAttendanceGetByIdService { empid = empid };
            var response = await mediator.Send(service);

            return Ok(response);
        }


        [HttpPost]
        [Route("PayrollAttendanceDelete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> PayrollAttendanceDelete([FromBody] PayrollAttendanceDeleteService values)
        {
            var response = await mediator.Send(values);
            return Ok(JsonConvert.SerializeObject(response));
        }
    }
}
