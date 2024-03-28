using Asp.Net.Core.Business.Services.Department;
using Asp.Net.Core.Business.Services.Masters.State;
using Asp.Net.Core.Business.Services.orders;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Asp.Net.Core.Api.Controllers.orders
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ordersController : Controller
    {
        private readonly IMediator mediator;

        public ordersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("ordersSave")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ordersSave([FromBody] ordersSaveService values)
        {
            var response = await mediator.Send(values);
            return Ok(JsonConvert.SerializeObject(response));
        }

        [HttpGet]
        [Route("ordersList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ordersList([FromBody] ordersListService values)
        {
            var response = await mediator.Send(values);
            return Ok(JsonConvert.SerializeObject(response));
        }

        [HttpPost]
        [Route("ordersFetch")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ordersFetch([FromBody] ordersFetchService values)
        {
            var response = await mediator.Send(values);
            return Ok(response);
        }

        [HttpPost]
        [Route("ordersDelete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ordersDelete([FromBody] ordersDeleteService values)
        {
            var response = await mediator.Send(values);
            return Ok(JsonConvert.SerializeObject(response));
        }
    }
}
