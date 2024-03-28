using Asp.Net.Core.Business.Services.Common.Country;
using Asp.Net.Core.Business.Services.Contract;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Asp.Net.Core.Api.Controllers.Common
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class CountryController : ControllerBase
    {
        private IMediator mediator;

        public CountryController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("CountrySave")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CountrySave([FromBody] CountrySaveService values)
        {
            var response = await mediator.Send(values);
            return Ok(JsonConvert.SerializeObject(response));
        }

        [HttpPost]
        [Route("CountryList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CountryList([FromBody] CountryListService values)
        {
            var response = await mediator.Send(values);
            return Ok(JsonConvert.SerializeObject(response));
        }

        [HttpPost]
        [Route("CountryById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CountryById([FromBody] CountryByIdService values)
        {
            var response = await mediator.Send(values);
            return Ok(JsonConvert.SerializeObject(response));
        }

        [HttpPost]
        [Route("CountryDelete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CountryDelete([FromBody] CountryDeleteService values)
        {
            var response = await mediator.Send(values);
            return Ok(JsonConvert.SerializeObject(response));
        }

    }
}
