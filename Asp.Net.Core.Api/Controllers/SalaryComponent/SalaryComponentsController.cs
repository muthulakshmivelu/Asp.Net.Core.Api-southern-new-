using Asp.Net.Core.Business.Services.salarycomponent;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Asp.Net.Core.Api.Controllers.SalaryComponent
{
    [Route("api/[controller]")]
    [ApiController]


    [Authorize]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class SalaryComponentsController : ControllerBase
    {
        private readonly IMediator mediator;

        public SalaryComponentsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("SalaryComponentSave")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> SalaryComponentSave([FromBody] SalaryComponentSaveService values)
        {
            var response = await mediator.Send(values);
            return Ok(JsonConvert.SerializeObject(response));
        }

        [HttpGet]
        [Route("SalaryComponentList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> SalaryComponentList()
        {
            var response = await mediator.Send(new SalaryComponentListService());
            return Ok(response);
        }

        //[HttpPost]
        //[Route("SalaryComponentFetch")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<IActionResult> SalaryComponentFetch([FromBody] SalaryComponentFetchService values)
        //{
        //    var response = await mediator.Send(values);
        //    return Ok(response);
        //}
        [HttpDelete]
        [Route("SalaryComponentDelete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> SalaryComponentDelete([FromBody] SalaryComponentDeleteService values)
        {
            var response = await mediator.Send(values);
            return Ok(JsonConvert.SerializeObject(response));
        }
    }
}
