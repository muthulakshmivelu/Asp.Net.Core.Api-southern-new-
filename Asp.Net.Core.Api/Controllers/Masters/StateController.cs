using Asp.Net.Core.Business.Services.Masters.State;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Asp.Net.Core.Api.Controllers.Masters
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class StateController : ControllerBase
    {
        private readonly IMediator mediator;

        public StateController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("StateSave")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> StateSave([FromBody] StateSaveService values)
        {
            var response = await mediator.Send(values);
            return Ok(JsonConvert.SerializeObject(response));
        }

        [HttpPost]
        [Route("StateList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> StateList([FromBody] StateListService values)
        {
            var response = await mediator.Send(values);
            return Ok(JsonConvert.SerializeObject(response));
        }

        [HttpPost]
        [Route("StateFetch")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> StateFetch([FromBody] StateFetchService values)
        {
            var response = await mediator.Send(values);
            return Ok(response);
        }

        [HttpPost]
        [Route("StateDelete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> StateDelete([FromBody] StateDeleteService values)
        {
            var response = await mediator.Send(values);
            return Ok(JsonConvert.SerializeObject(response));
        }
    }
}
