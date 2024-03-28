using Asp.Net.Core.Business.Services.Attendance;
using Asp.Net.Core.Business.Services.Department;
using Asp.Net.Core.Business.Services.Manpower;
using Asp.Net.Core.DataModel.Models.ManPower;
using Asp.Net.Core.DataModel.Utilities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Asp.Net.Core.Api.Controllers.Manpower
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class ManpowerController : Controller
    {
        private IMediator mediator;

        public ManpowerController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // For manpower Detail Screen start

        // All DropDown 


        [HttpGet]
        [Route("GetCompanyList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCompanyList()
        {
            var response = await mediator.Send(new GetCompanyListService());
            return Ok(response);
        }

        [HttpGet]
        [Route("GetCountryList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCountryList()
        {
            var response = await mediator.Send(new GetCountryListService());
            return Ok(response);
        }

        [HttpGet]
        [Route("GetStateList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetStateList()
        {
            var response = await mediator.Send(new GetStateListService());
            return Ok(response);
        }

        //[HttpGet]
        //[Route("GetCityList")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<IActionResult> GetCityList()
        //{
        //    var response = await mediator.Send(new GetCityListService());
        //    return Ok(response);
        //}

        [HttpPost]
        [Route("GetCityList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCityList([FromBody] GetCityListService values)
        {
            var response = await mediator.Send(values);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetBankList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetBankList()
        {
            var response = await mediator.Send(new GetBankListService());
            return Ok(response);
        }

        [HttpGet]
        [Route("GetDesignationList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDesignationList()
        {
            var response = await mediator.Send(new GetDesignationListService());
            return Ok(response);
        }

        [HttpGet]
        [Route("GetPaymentModeList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPaymentModeList()
        {
            var response = await mediator.Send(new GetPaymentModeListService());
            return Ok(response);
        }

        [HttpGet]
        [Route("GetProofList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProofList()
        {
            var response = await mediator.Send(new GetProofListService());
            return Ok(response);
        }

        [HttpGet]
        [Route("GetAccountTypeList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAccountTypeList()
        {
            var response = await mediator.Send(new GetAccountTypeListService());
            return Ok(response);
        }

        //All Save

        [HttpPost]
        [Route("ManPowerDetailSave")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AddProductMaster(IFormFile[] files)
        {
            var data = Request.Form["ManPowerDetails"];
            IFormFile photo = null;
            if (Request.Form.Files.Count > 0)
            {
                photo = Request.Form.Files[0];
            }
            Manpowerentity objProduct = JsonConvert.DeserializeObject<Manpowerentity>(data);

            if (photo != null)
            {
                try
                {
                    var photouploadResult = Utilities.FileUploadName(photo);
                    objProduct.photo = photouploadResult;
                }
                catch (Exception fileUploadException)
                {
                    var ex = fileUploadException.Message;
                }
            }

            List <Manpowerentity> productArr = new List<Manpowerentity>();
            productArr.Add(objProduct);

            var response = await mediator.Send(new ManPowerDetailSaveService()
            {
                ManPowerDetailSave = JsonConvert.SerializeObject(productArr)
            });
            return Ok(response);
        }


        [HttpPost]
        [Route("ManPowerBankDetailSave")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ManPowerBankDetailSave([FromBody] ManPowerBankDetailSaveService values)
        {
            var response = await mediator.Send(values);
            return Ok(JsonConvert.SerializeObject(response));
        }

        [HttpPost]
        [Route("ManPowerFamilyDetailSave")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ManPowerFamilyDetailSave([FromBody] ManPowerFamilyDetailSaveService values)
        {
            var response = await mediator.Send(values);
            return Ok(JsonConvert.SerializeObject(response));
        }

        [HttpPost]
        [Route("ManPowerProofDetailSave")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ManPowerProofDetailSave([FromBody] ManPowerProofDetailSaveService values)
        {
            var response = await mediator.Send(values);
            return Ok(JsonConvert.SerializeObject(response));
        }

        // All List


        [HttpGet]
        [Route("GetManpowerList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetManpowerList()
        {
            var response = await mediator.Send(new GetManpowerListService());
            return Ok(response);
        }


        [HttpPost]
        [Route("GetManpowerBankList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetManpowerBankList([FromBody] GetManpowerBankListService values)
        {
            var response = await mediator.Send(values);
            return Ok(response);
        }


        [HttpPost]
        [Route("GetManpowerFamilyList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetManpowerFamilyList([FromBody] GetManpowerFamilyListService values)
        {
            var response = await mediator.Send(values);
            return Ok(response);
        }

        [HttpPost]
        [Route("GetManpowerProofList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetManpowerProofList([FromBody] GetManpowerProofListService values)
        {
            var response = await mediator.Send(values);
            return Ok(response);
        }

        // All Delete

        [HttpPost]
        [Route("ManPowerBankDelete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ManPowerBankDelete([FromBody] ManPowerBankDeleteService values)
        {
            var response = await mediator.Send(values);
            return Ok(JsonConvert.SerializeObject(response));
        }

        [HttpPost]
        [Route("ManPowerFamilyDelete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ManPowerFamilyDelete([FromBody] ManPowerFamilyDeleteService values)
        {
            var response = await mediator.Send(values);
            return Ok(JsonConvert.SerializeObject(response));
        }

        [HttpPost]
        [Route("ManPowerProofDelete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ManPowerProofDelete([FromBody] ManPowerProofDeleteService values)
        {
            var response = await mediator.Send(values);
            return Ok(JsonConvert.SerializeObject(response));
        }

        // fetch

        [HttpPost]
        [Route("ManPowerDetailFetch")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ManPowerDetailFetch([FromBody] ManPowerDetailFetchService values)
        {
            var response = await mediator.Send(values);
            return Ok(JsonConvert.SerializeObject(response));
        }


        // For manpower Detail Screen end

        // For Assign manpower Screen Start

        [HttpPost]
        [Route("GetClassificationList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetClassificationList([FromBody] GetClassificationListService values)
        {
            var response = await mediator.Send(values);
            return Ok(response);
        }

        [HttpPost]
        [Route("GetContractIdList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetContractIdList([FromBody] GetContractIdListService values)
        {
            var response = await mediator.Send(values);
            return Ok(response);
        }

        [HttpPost]
        [Route("GetServiceList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetServiceList([FromBody] GetServiceListService values)
        {
            var response = await mediator.Send(values);
            return Ok(response);
        }

        [HttpPost]
        [Route("GetManpowerNameList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetManpowerNameList([FromBody] GetManpowerNameListService values)
        {
            var response = await mediator.Send(values);
            return Ok(response);
        }

        //[HttpPost]
        //[Route("GetAssignManpowerList")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<IActionResult> GetAssignManpowerList([FromBody] GetAssignManpowerListService values)
        //{
        //    var response = await mediator.Send(values);
        //    return Ok(response);
        //}

        [HttpPost]
        [Route("GetAssignManpowerList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAssignManpowerList([FromBody] GetAssignManpowerListService values)
        {
            var response = await mediator.Send(values);
            return Ok(JsonConvert.SerializeObject(response));
        }

        [HttpPost]
        [Route("GetAssignManpowerSave")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAssignManpowerSave([FromBody] GetAssignManpowerSaveService values)
        {
            var response = await mediator.Send(values);
            return Ok(JsonConvert.SerializeObject(response));
        }

        [HttpPost]
        [Route("GetAssignManpowerDelete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAssignManpowerDelete([FromBody] GetAssignManpowerDeleteService values)
        {
            var response = await mediator.Send(values);
            return Ok(JsonConvert.SerializeObject(response));
        }


        // For Assign manpower Screen End

        // For Assign Field Officer Screen Start[HttpPost]


        [HttpPost]
        [Route("GetFieldOfficerSave")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFieldOfficerSave([FromBody] GetFieldOfficerSaveService values)
        {
            var response = await mediator.Send(values);
            return Ok(JsonConvert.SerializeObject(response));
        }

        [HttpPost]
        [Route("GetFieldOfficerDelete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFieldOfficerDelete([FromBody] GetFieldOfficerDeleteService values)
        {
            var response = await mediator.Send(values);
            return Ok(JsonConvert.SerializeObject(response));
        }

        [HttpPost]
        [Route("GetFieldOfficer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFieldOfficer([FromBody] GetFieldOfficerService values)
        {
            var response = await mediator.Send(values);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetAllManpowerName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllManpowerName()
        {
            var response = await mediator.Send(new GetAllManpowerNameService());
            return Ok(response);
        }

        [HttpGet]
        [Route("GetManpowerDirect")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetManpowerDirect()
        {
            var response = await mediator.Send(new GetManpowerDirectService());
            return Ok(response);
        }
        [HttpPost]
        [Route("SaveManpowerdirect")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> SaveManpowerdirect([FromBody] SaveManpowerdirectService values)
        {
            var response = await mediator.Send(values);
            return Ok(JsonConvert.SerializeObject(response));
        }

        [HttpPost]
        [Route("GetShiftdetailsdirect")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetShiftdetailsdirect([FromBody] GetShiftdetailsdirectService values)
        {
            var response = await mediator.Send(values);
            return Ok(response);
        }

    }
}
    

