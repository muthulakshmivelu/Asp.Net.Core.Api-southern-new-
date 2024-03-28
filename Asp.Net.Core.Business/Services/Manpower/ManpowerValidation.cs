using Asp.Net.Core.Business.Services.Attendance;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.Net.Core.Business.Services.Manpower
{
    //All Drop Down

    public class GetCompanyListValidation : AbstractValidator<GetCompanyListService>
    {

    }
    public class GetCountryListValidation : AbstractValidator<GetCountryListService>
    {

    }
    public class GetStateListValidation : AbstractValidator<GetStateListService>
    {

    }
    public class GetCityListValidation : AbstractValidator<GetCityListService>
    {

    }
    public class GetBankListValidation : AbstractValidator<GetBankListService>
    {

    }
    public class GetDesignationListValidation : AbstractValidator<GetDesignationListService>
    {

    }
    public class GetPaymentModeListValidation : AbstractValidator<GetPaymentModeListService>
    {

    }
    public class GetProofListValidation : AbstractValidator<GetProofListService>
    {

    }
    public class GetAccountTypeListValidation : AbstractValidator<GetAccountTypeListService>
    {

    }

    // All Save

    public class ManPowerDetailSaveValidation : AbstractValidator<ManPowerDetailSaveService>
    {

    }
    public class ManPowerBankDetailSaveValidation : AbstractValidator<ManPowerBankDetailSaveService>
    {

    }
    public class ManPowerFamilyDetailSaveValidation : AbstractValidator<ManPowerFamilyDetailSaveService>
    {

    }
    public class ManPowerProofDetailSaveValidation : AbstractValidator<ManPowerProofDetailSaveService>
    {

    }

    //all List
    public class GetManpowerListValidation : AbstractValidator<GetManpowerListService>
    {

    }
    public class GetManpowerBankListValidation : AbstractValidator<GetManpowerBankListService>
    {

    }
    public class GetManpowerFamilyListValidation : AbstractValidator<GetManpowerFamilyListService>
    {

    }
    public class GetManpowerProofListValidation : AbstractValidator<GetManpowerProofListService>
    {

    }

    // All Delete

    public class ManPowerBankDeleteValidation : AbstractValidator<ManPowerBankDeleteService>
    {

    }
    public class ManPowerFamilyDeleteValidation : AbstractValidator<ManPowerFamilyDeleteService>
    {

    }
    public class ManPowerProofDeleteValidation : AbstractValidator<ManPowerProofDeleteService>
    {

    }

    //fetch
    public class ManPowerDetailFetchValidation : AbstractValidator<ManPowerDetailFetchService>
    {

    }

    //Assign Manpower

    public class GetClassificationListValidation : AbstractValidator<GetClassificationListService>
    {

    }
    public class GetContractIdListValidation : AbstractValidator<GetContractIdListService>
    {

    }
    public class GetServiceListValidation : AbstractValidator<GetServiceListService>
    {

    }
    public class GetManpowerNameListValidation : AbstractValidator<GetManpowerNameListService>
    {

    }
    public class GetAssignManpowerListValidation : AbstractValidator<GetAssignManpowerListService>
    {

    }
    public class GetAssignManpowerSaveValidation : AbstractValidator<GetAssignManpowerSaveService>
    {

    }
    public class GetAssignManpowerDeleteValidation : AbstractValidator<GetAssignManpowerDeleteService>
    {

    }

    //assign field officer

    public class GetFieldOfficerSaveValidation : AbstractValidator<GetFieldOfficerSaveService>
    {

    }
    public class GetFieldOfficerDeleteValidation : AbstractValidator<GetFieldOfficerDeleteService>
    {

    }
    public class GetFieldOfficerValidation : AbstractValidator<GetFieldOfficerService>
    {

    }
    public class GetAllManpowerNameValidation : AbstractValidator<GetAllManpowerNameService>
    {

    }
    public class GetManpowerDirectValidation : AbstractValidator<GetManpowerDirectService>
    {

    }
    public class SaveManpowerdirectValidation : AbstractValidator<SaveManpowerdirectService>
    {

    }
    public class GetShiftdetailsdirectValidation : AbstractValidator<GetShiftdetailsdirectService>
    {

    }
}
