using Asp.Net.Core.Business.Services.Attendance;
using Asp.Net.Core.Business.Services.Contract;
using Asp.Net.Core.Business.Services.Department;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Asp.Net.Core.Api.Controllers.Attendance
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class AttendanceController : ControllerBase
    {
        private readonly IMediator mediator;

        public AttendanceController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("AttendanceStatusList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AttendanceStatusList()
        {
            var response = await mediator.Send(new AttendanceStatusListService());
            return Ok(response);
        }

        [HttpPost]
        [Route("CustomerBranchSiteDropDownList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CustomerBranchSiteDropDownList([FromBody] CustomerBranchSiteDropDownListService values)
        {
            var response = await mediator.Send(values);
            return Ok(response);
        }

        [HttpPost]
        [Route("GetManpowerDetailsList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetManpowerDetailsList([FromBody] GetManpowerDetailsListService values)
        {
            var response = await mediator.Send(values);
            return Ok(response);
        }

        [HttpPost]
        [Route("ManPowerAttendanceSave")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ManPowerAttendanceSave([FromBody] ManPowerAttendanceSaveService values)
        {
            var response = await mediator.Send(values);
            return Ok(JsonConvert.SerializeObject(response));
        }

        [HttpPost]
        [Route("GetManpowerPivotDetailsList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetManpowerPivotDetailsList([FromBody] GetManpowerPivotDetailsListService values)
        {
            var response = await mediator.Send(values);
            return Ok(response);
        }


    }
}
