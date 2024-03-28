using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.Net.Core.Business.Services.Contract;
using Asp.Net.Core.Business.Services.Menus;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Asp.Net.Core.Api.Controllers.Menus
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class MenusController : ControllerBase
    {
        private IMediator mediator;

        public MenusController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("GetMenus")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Menus([FromQuery] MenusService command)
        {
            var response = await mediator.Send(command);
            return Ok(JsonConvert.SerializeObject(response));
        }
        [HttpGet]
        [Route("getmenulist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> getmenulist()
        {
            var response = await mediator.Send(new getmenulistService());
            return Ok(response);
        }

    }
}
