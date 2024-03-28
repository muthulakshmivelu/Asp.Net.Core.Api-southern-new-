﻿using Asp.Net.Core.Business.Services.Holiday;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Asp.Net.Core.Api.Controllers.Holiday
{
    [Route("api/[controller]")]
    [ApiController]

    [Authorize]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class HolidayController : ControllerBase
    {
        private readonly IMediator mediator;

        public HolidayController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("HolidaySave")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> HolidaySave([FromBody] HolidayService values)
        {
            var response = await mediator.Send(values);
            return Ok(JsonConvert.SerializeObject(response));
        }

        [HttpGet]
        [Route("HolidayList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> HolidayList()
        {
            var response = await mediator.Send(new HolidayListService());
            return Ok(response);
        }

        [HttpPost]
        [Route("HolidayDelete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> HolidayDelete([FromBody] HolidayDeleteService values)
        {
            var response = await mediator.Send(values);
            return Ok(JsonConvert.SerializeObject(response));
        }
    }
}
