using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.Net.Core.Business.Services.Login;
using Asp.Net.Core.DataModel.DBContext;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Asp.Net.Core.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class LoginController : ControllerBase
    {
        private readonly IMediator mediator;

        public LoginController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("Authentication")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] LoginService values)
        {
            //using (var db = new DBPostgresContext())
            //{
            //    var data = db.StateMaster.ToList();
            //}
            var response = await mediator.Send(values);
            return Ok(JsonConvert.SerializeObject(response));
        }

        [HttpPost]
        [Route("Test")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Test()
        {
            var response = System.Environment.MachineName;
            return Ok(JsonConvert.SerializeObject(response));
        }
    }
}
