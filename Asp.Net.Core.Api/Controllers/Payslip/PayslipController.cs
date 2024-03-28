using Asp.Net.Core.Business.Services.Payslip;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Asp.Net.Core.Api.Controllers.Payslip
{
    [Route("api/[controller]")]
    [ApiController]


    [Authorize]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class PayslipController : ControllerBase
    {
        private readonly IMediator mediator;

        public PayslipController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("PayslipSave")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> PayslipSave([FromBody] PayslipService values)
        {
            var response = await mediator.Send(values);
            return Ok(JsonConvert.SerializeObject(response));
        }

        [HttpGet]
        [Route("PayslipList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> PayslipList()
        {
            var response = await mediator.Send(new PayslipListService());
            return Ok(response);
        }

        [HttpPost]
        [Route("PayslipDelete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> PayslipDelete([FromBody] PayslipDeleteService values)
        {
            var response = await mediator.Send(values);
            return Ok(JsonConvert.SerializeObject(response));
        }
    }
}
