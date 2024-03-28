using Asp.Net.Core.Business.Services.Contract;
using Asp.Net.Core.Business.Services.Contract.CustomerMaster;
using Asp.Net.Core.Business.Services.Manpower;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Asp.Net.Core.Api.Controllers.Contract.CustomerMaster
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class CustomerMasterController : ControllerBase
    {
        private readonly IMediator mediator;

        public CustomerMasterController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("CustomerSave")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CustomerSave([FromBody] CustomerSaveService values)
        {
            var response = await mediator.Send(values);
            return Ok(JsonConvert.SerializeObject(response));
        }

        [HttpGet]
        [Route("CustomerList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CustomerList()
        {
            var response = await mediator.Send(new CustomerListService());
            return Ok(response);
        }

        [HttpPost]
        [Route("CustomerFetch")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CustomerFetch([FromBody] CustomerFetchService values)
        {
            var response = await mediator.Send(values);
            return Ok(response);
        }
    }
}
