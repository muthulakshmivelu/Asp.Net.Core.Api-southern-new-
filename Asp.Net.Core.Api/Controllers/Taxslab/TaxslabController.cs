using Asp.Net.Core.Business.Services.Taxslab;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Asp.Net.Core.Api.Controllers.Taxslab
{
    [Route("api/[controller]")]
    [ApiController]

    [Authorize]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class TaxslabController : ControllerBase
    {
        private readonly IMediator mediator;

        public TaxslabController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("TaxslabSave")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> TaxslabSave([FromBody] TaxslabService values)
        {
            var response = await mediator.Send(values);
            return Ok(JsonConvert.SerializeObject(response));
        }

        [HttpGet]
        [Route("TaxslabList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> TaxslabList()
        {
            var response = await mediator.Send(new TaxslabListService());
            return Ok(response);
        }

        [HttpPost]
        [Route("TaxslabDelete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> TaxslabDelete([FromBody] TaxslabDeleteService values)
        {
            var response = await mediator.Send(values);
            return Ok(JsonConvert.SerializeObject(response));
        }
    }
}
