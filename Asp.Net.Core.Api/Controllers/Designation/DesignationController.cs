using Asp.Net.Core.Business.Services.Contract.CustomerMaster;
using Asp.Net.Core.Business.Services.Designation;
using Asp.Net.Core.Business.Services.Manpower;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Asp.Net.Core.Api.Controllers.Designation
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class DesignationController : ControllerBase
    {
        private readonly IMediator mediator;

        public DesignationController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("DesignationSave")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DesignationSave([FromBody] DesignationSaveService values)
        {
            var response = await mediator.Send(values);
            return Ok(JsonConvert.SerializeObject(response));
        }

        [HttpGet]
        [Route("DesignationList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DesignationList()
        {
            var response = await mediator.Send(new DesignationListService());
            return Ok(response);
        }

        [HttpPost]
        [Route("DesignationFetch")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DesignationFetch([FromBody] DesignationFetchService values)
        {
            var response = await mediator.Send(values);
            return Ok(response);
        }

        [HttpPost]
        [Route("DesignationDelete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DesignationDelete([FromBody] DesignationDeleteService values)
        {
            var response = await mediator.Send(values);
            return Ok(JsonConvert.SerializeObject(response));
        }
    }
}
