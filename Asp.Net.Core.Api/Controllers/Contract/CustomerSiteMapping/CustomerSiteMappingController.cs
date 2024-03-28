using Asp.Net.Core.Business.Services.Contract;
using Asp.Net.Core.Business.Services.Contract.CustomerSiteMapping;
using Asp.Net.Core.Business.Services.Manpower;
using Asp.Net.Core.Business.Services.Masters.State;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace Asp.Net.Core.Api.Controllers.Contract.CustomerSiteMapping
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class CustomerSiteMappingController : ControllerBase
    {
        private readonly IMediator mediator;

        public CustomerSiteMappingController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        //customer drop down

        [HttpGet]
        [Route("GetCustomerDropDown")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCustomerDropDown()
        {
            var response = await mediator.Send(new GetCustomerDropDownService());
            return Ok(response);
        }

        //delete

        [HttpPost]
        [Route("BranchMasterDelete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> BranchMasterDelete([FromBody] BranchMasterDeleteService values)
        {
            var response = await mediator.Send(values);
            return Ok(JsonConvert.SerializeObject(response));
        }

        [HttpPost]
        [Route("SiteMasterDelete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> SiteMasterDelete([FromBody] SiteMasterDeleteService values)
        {
            var response = await mediator.Send(values);
            return Ok(JsonConvert.SerializeObject(response));
        }

        [HttpPost]
        [Route("ClassificationMasterDelete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ClassificationMasterDelete([FromBody] ClassificationMasterDeleteService values)
        {
            var response = await mediator.Send(values);
            return Ok(JsonConvert.SerializeObject(response));
        }

        //List

        [HttpPost]
        [Route("GetBranchMasterList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetBranchMasterList([FromBody] GetBranchMasterListService values)
        {
            var response = await mediator.Send(values);
            return Ok(response);
        }


        [HttpPost]
        [Route("GetSiteMasterList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSiteMasterList([FromBody] GetSiteMasterListService values)
        {
            var response = await mediator.Send(values);
            return Ok(response);
        }

        [HttpPost]
        [Route("GetClassificationMasterList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetClassificationMasterList([FromBody] GetClassificationMasterListService values)
        {
            var response = await mediator.Send(values);
            return Ok(response);
        }

        [HttpPost]
        [Route("Locationlist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Locationlist([FromBody] LocationlistService values)
        {
            var response = await mediator.Send(values);
            return Ok(response);
        }

        [HttpPost]
        [Route("ContractListAllocate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ContractListAllocate([FromBody] ContractListAllocateService values)
        {
            var response = await mediator.Send(values);
            return Ok(response);
        }

        [HttpPost]
        [Route("ContractServiceList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ContractServiceList([FromBody] ContractServiceListService values)
        {
            var response = await mediator.Send(values);
            return Ok(response);
        }
        [HttpPost]
        [Route("ContractListbyCustomer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ContractManpowerList([FromBody] ContractListbyCustomerService values)
        {
            var response = await mediator.Send(values);
            return Ok(response);
        }

    

        [HttpPost]
        [Route("AllocationList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AllocationList([FromBody] AllocationListService values)
        {
            var response = await mediator.Send(values);
            return Ok(JsonConvert.SerializeObject(response));
        }

        //save

        [HttpPost]
        [Route("BranchMasterSave")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> BranchMasterSave([FromBody] BranchMasterSaveService values)
        {
            var response = await mediator.Send(values);
            return Ok(JsonConvert.SerializeObject(response));
        }

        [HttpPost]
        [Route("SiteMasterSave")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> SiteMasterSave([FromBody] SiteMasterSaveService values)
        {
            var response = await mediator.Send(values);
            return Ok(JsonConvert.SerializeObject(response));
        }

        [HttpPost]
        [Route("ClassificationMasterSave")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ClassificationMasterSave([FromBody] ClassificationMasterSaveService values)
        {
            var response = await mediator.Send(values);
            return Ok(JsonConvert.SerializeObject(response));
        }



        //////////// Manpower Allocation /////////////////////


        [HttpPost]
        [Route("AllocateManpowerSave")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AllocateManpowerSiteSave([FromBody] AllocateManpowerSaveService values)
        {
            var response = await mediator.Send(values);
            return Ok(JsonConvert.SerializeObject(response));
        }

        [HttpPost]
        [Route("GetMAServiceList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetMAServiceList([FromBody] GetMAServiceListService values)
        {
            var response = await mediator.Send(values);
            return Ok(response);
        }

        [HttpPost]
        [Route("AllocateManpowerSiteList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AllocateManpowerSiteList([FromBody] AllocateManpowerSiteListService values)
        {
            var response = await mediator.Send(values);
            return Ok(response);
        }

        [HttpPost]
        [Route("AllocateManpowerSiteDelete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AllocateManpowerSiteDelete([FromBody] AllocateManpowerSiteDeleteService values)
        {
            var response = await mediator.Send(values);
            return Ok(JsonConvert.SerializeObject(response));
        }

    //
        [HttpPost]
        [Route("SaveLocation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> SaveLocation([FromBody] SaveLocationService values)
        {
            var response = await mediator.Send(values);
            return Ok(JsonConvert.SerializeObject(response));
        }

        [HttpPost]
        [Route("GetLocation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetLocation([FromBody] GetLocationService values)
        {
            var response = await mediator.Send(values);
            return Ok(response);
        }

        [HttpPost]
        [Route("DeleteLocation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteLocation([FromBody] DeleteLocationService values)
        {
            var response = await mediator.Send(values);
            return Ok(JsonConvert.SerializeObject(response));
        }

        [HttpGet]
        [Route("GetContractList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetContractList()
        {
            var response = await mediator.Send(new GetContractListService());
            return Ok(response);
        }
        [HttpPost]
        [Route("LocationFetch")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> StateFetch([FromBody] LocationFetchService values)
        {
            var response = await mediator.Send(values);
            return Ok(response);
        }

    }
}
