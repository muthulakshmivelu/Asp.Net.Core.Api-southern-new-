using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Asp.Net.Core.Business.Services.EmployeeLeaveType.EmployeeLeaveTypeService;
using System.Threading.Tasks;

namespace Asp.Net.Core.Api.Controllers.EmployeeLeaveType
{
    [Route("api/[controller]")]
    [ApiController]

    [Authorize]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class EmployeeLeaveTypeController : ControllerBase
    {
        private readonly IMediator mediator;

        public EmployeeLeaveTypeController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        [Route("LeaveTypeLists")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> LeaveTypeLists()
        {
            var response = await mediator.Send(new EmployeeLeaveTypeListService());
            return Ok(response);
        }
    }
}
