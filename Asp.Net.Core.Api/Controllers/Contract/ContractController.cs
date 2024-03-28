using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.Net.Core.Business.Services.Contract;
using Asp.Net.Core.Business.Services.Contract.CustomerMaster;
using Asp.Net.Core.Business.Services.Manpower;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Asp.Net.Core.Api.Controllers.Contract
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class ContractController : ControllerBase
    {
        private readonly IMediator mediator;

        public ContractController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("ContractSave")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ContractSave([FromBody] ContractSaveService values)
        {
            var response = await mediator.Send(values);
            return Ok(JsonConvert.SerializeObject(response));
        }

        [HttpPost]
        [Route("ContractDelete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ContractDelete([FromBody] ContractDeleteService values)
        {
            var response = await mediator.Send(values);
            return Ok(JsonConvert.SerializeObject(response));
        }

        [HttpPost]
        [Route("GetConsumableRequirement")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetConsumableRequirement([FromBody] GetConsumableRequirementService values)
        {
            var response = await mediator.Send(values);
            return Ok(JsonConvert.SerializeObject(response));
        }

        [HttpPost]
        [Route("GetContractByAllCustomer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetContractByAllCustomer([FromBody] GetContractByAllCustomerService values)
        {
            var response = await mediator.Send(values);
            return Ok(JsonConvert.SerializeObject(response));
        }

        [HttpPost]
        [Route("GetContractDetails")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetContractDetails([FromBody] GetContractDetailsService values)
        {
            var response = await mediator.Send(values);
            return Ok(JsonConvert.SerializeObject(response));
        }

        [HttpPost]
        [Route("GetContract")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetContract([FromBody] GetContractService values)
        {
            var response = await mediator.Send(values);
            return Ok(response);
        }

        [HttpPost]
        [Route("GetContractMaster")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetContractMaster([FromBody] GetContractMasterService values)
        {
            var response = await mediator.Send(values);
            return Ok(JsonConvert.SerializeObject(response));
        }

        [HttpPost]
        [Route("GetAllCustomer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllCustomer([FromBody] GetAllCustomerService values)
        {
            var response = await mediator.Send(values);
            return Ok(JsonConvert.SerializeObject(response));
        }

        [HttpPost]
        [Route("GetContractsListByCustomerId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetContractsListByCustomerId([FromBody] GetContractsListByCustomerIdService values)
        {
            var response = await mediator.Send(values);
            return Ok(JsonConvert.SerializeObject(response));
        }

        [HttpGet]
        [Route("GetDeparmentAsServiceList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDeparmentAsServiceList()
        {
            var response = await mediator.Send(new GetDeparmentAsServiceListService());
            return Ok(response);
        }

        [HttpPost]
        [Route("GetDesignetionByService")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDesignetionByService([FromBody] GetDesignetionByServiceIDService values)
        {
            var response = await mediator.Send(values);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetCustomerNameList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCustomerNameList()
        {
            var response = await mediator.Send(new GetCustomerNameListService());
            return Ok(response);
        }

        [HttpPost]
        [Route("ContractDetailsFetch")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ContractDetailsFetch([FromBody] ContractDetailsFetchService values)
        {
            var response = await mediator.Send(values);
            return Ok(JsonConvert.SerializeObject(response));
        }
        [HttpGet]
        [Route("getclienttype")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> getclienttype()
        {
            var response = await mediator.Send(new getclienttypeService());
            return Ok(response);
        }

    }
}
