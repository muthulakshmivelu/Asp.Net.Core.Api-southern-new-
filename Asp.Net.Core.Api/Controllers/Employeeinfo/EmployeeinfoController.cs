using Asp.Net.Core.Business.Services.Employeeinfo;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Asp.Net.Core.Api.Controllers.Employeeinfo
{
    [Route("api/[controller]")]
    [ApiController]


    [Authorize]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)] 
    public class EmployeeinfoController : ControllerBase
    {
        private readonly IMediator mediator;

        public EmployeeinfoController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        [Route("EmployeeinfoList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> EmployeeinfoList()
        {
            var response = await mediator.Send(new EmployeeinfoListService());
            return Ok(response);
        }
    }
}
