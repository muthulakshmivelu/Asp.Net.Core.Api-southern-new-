using Asp.Net.Core.Business.Services.Attendance;
using Asp.Net.Core.Business.Services.Contract;
using Asp.Net.Core.DataModel.Models;
using Asp.Net.Core.DataModel.Models.ManPower;
using MediatR;
using ERP.UserControl.DataContext.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.Net.Core.Business.Services.Manpower
{

    //All Drop Down

    public class GetCompanyListHandler : IRequestHandler<GetCompanyListService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetCompanyListHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(GetCompanyListService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.ManpowerRepository.GetCompanyList();
            return user;
        }
    }
    public class GetCountryListHandler : IRequestHandler<GetCountryListService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetCountryListHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(GetCountryListService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.ManpowerRepository.GetCountryList();
            return user;
        }
    }
    public class GetStateListHandler : IRequestHandler<GetStateListService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetStateListHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(GetStateListService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.ManpowerRepository.GetStateList();
            return user;
        }
    }
    public class GetCityListHandler : IRequestHandler<GetCityListService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetCityListHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(GetCityListService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.ManpowerRepository.GetCityList(request.GetCityList);
            return user;
        }
    }
    public class GetBankListHandler : IRequestHandler<GetBankListService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetBankListHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(GetBankListService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.ManpowerRepository.GetBankList();
            return user;
        }
    }
    public class GetDesignationListHandler : IRequestHandler<GetDesignationListService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetDesignationListHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(GetDesignationListService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.ManpowerRepository.GetDesignationList();
            return user;
        }
    }
    public class GetPaymentModeListHandler : IRequestHandler<GetPaymentModeListService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetPaymentModeListHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(GetPaymentModeListService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.ManpowerRepository.GetPaymentModeList();
            return user;
        }
    }
    public class GetProofListHandler : IRequestHandler<GetProofListService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetProofListHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(GetProofListService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.ManpowerRepository.GetProofList();
            return user;
        }
    }
    public class GetAccountTypeListHandler : IRequestHandler<GetAccountTypeListService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetAccountTypeListHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(GetAccountTypeListService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.ManpowerRepository.GetAccountTypeList();
            return user;
        }
    }

    // All Save
    public class ManPowerDetailSaveHandler : IRequestHandler<ManPowerDetailSaveService, int>
    {
        private readonly IUnitOfWork unitOfWork;

        public ManPowerDetailSaveHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(ManPowerDetailSaveService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.ManpowerRepository.ManPowerDetailSave(request.ManPowerDetailSave);
            unitOfWork.Commit();
            return user;
        }
    }
    public class ManPowerBankDetailSaveHandler : IRequestHandler<ManPowerBankDetailSaveService, int>
    {
        private readonly IUnitOfWork unitOfWork;

        public ManPowerBankDetailSaveHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(ManPowerBankDetailSaveService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.ManpowerRepository.ManPowerBankDetailSave(request.ManPowerBankDetailSave);
            unitOfWork.Commit();
            return user;
        }
    }

    public class ManPowerFamilyDetailSaveHandler : IRequestHandler<ManPowerFamilyDetailSaveService, int>
    {
        private readonly IUnitOfWork unitOfWork;

        public ManPowerFamilyDetailSaveHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(ManPowerFamilyDetailSaveService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.ManpowerRepository.ManPowerFamilyDetailSave(request.ManPowerFamilyDetailSave);
            unitOfWork.Commit();
            return user;
        }
    }

    public class ManPowerProofDetailSaveHandler : IRequestHandler<ManPowerProofDetailSaveService, int>
    {
        private readonly IUnitOfWork unitOfWork;

        public ManPowerProofDetailSaveHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(ManPowerProofDetailSaveService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.ManpowerRepository.ManPowerProofDetailSave(request.ManPowerProofDetailSave);
            unitOfWork.Commit();
            return user;
        }
    }


    public class GetManpowerListHandler : IRequestHandler<GetManpowerListService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetManpowerListHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(GetManpowerListService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.ManpowerRepository.GetManpowerList();
            return user;
        }
    }

    public class GetManpowerBankListHandler : IRequestHandler<GetManpowerBankListService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetManpowerBankListHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(GetManpowerBankListService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.ManpowerRepository.GetManpowerBankList(request.ManpowerBankList);
            return user;
        }
    }

    public class GetManpowerFamilyListHandler : IRequestHandler<GetManpowerFamilyListService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetManpowerFamilyListHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(GetManpowerFamilyListService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.ManpowerRepository.GetManpowerFamilyList(request.ManpowerFamilyList);
            return user;
        }
    }

    public class GetManpowerProofListHandler : IRequestHandler<GetManpowerProofListService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetManpowerProofListHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(GetManpowerProofListService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.ManpowerRepository.GetManpowerProofList(request.ManpowerProofList);
            return user;
        }
    }

    //Delete


    //All Delete

    public class ManPowerBankDeleteHandler : IRequestHandler<ManPowerBankDeleteService, int>
    {
        private readonly IUnitOfWork unitOfWork;

        public ManPowerBankDeleteHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(ManPowerBankDeleteService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.ManpowerRepository.ManPowerBankDelete(request.ManPowerBankDelete);
            unitOfWork.Commit();
            return user;
        }
    }

    public class ManPowerFamilyDeleteHandler : IRequestHandler<ManPowerFamilyDeleteService, int>
    {
        private readonly IUnitOfWork unitOfWork;

        public ManPowerFamilyDeleteHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(ManPowerFamilyDeleteService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.ManpowerRepository.ManPowerFamilyDelete(request.ManPowerFamilyDelete);
            unitOfWork.Commit();
            return user;
        }
    }

    public class ManPowerProofDeleteHandler : IRequestHandler<ManPowerProofDeleteService, int>
    {
        private readonly IUnitOfWork unitOfWork;

        public ManPowerProofDeleteHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(ManPowerProofDeleteService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.ManpowerRepository.ManPowerProofDelete(request.ManPowerProofDelete);
            unitOfWork.Commit();
            return user;
        }
    }

    //fetch

    public class ManPowerDetailFetchHandler : IRequestHandler<ManPowerDetailFetchService, Table4>
    {
        private readonly IUnitOfWork unitOfWork;

        public ManPowerDetailFetchHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Table4> Handle(ManPowerDetailFetchService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.ManpowerRepository.ManPowerDetailFetch(request.ManPowerDetailFetch);
            unitOfWork.Commit();
            return user;
        }
    }

    //Assign Manpower

    public class GetClassificationListHandler : IRequestHandler<GetClassificationListService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetClassificationListHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(GetClassificationListService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.ManpowerRepository.GetClassificationList(request.Classification);
            unitOfWork.Commit();
            return user;
        }
    }
    public class GetContractIdListHandler : IRequestHandler<GetContractIdListService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetContractIdListHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(GetContractIdListService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.ManpowerRepository.GetContractIdList(request.ContractId);
            unitOfWork.Commit();
            return user;
        }
    }
    public class GetServiceListHandler : IRequestHandler<GetServiceListService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetServiceListHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(GetServiceListService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.ManpowerRepository.GetServiceList(request.Service);
            unitOfWork.Commit();
            return user;
        }
    }
    public class GetManpowerNameListHandler : IRequestHandler<GetManpowerNameListService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetManpowerNameListHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(GetManpowerNameListService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.ManpowerRepository.GetManpowerNameList(request.ManpowerName);
            unitOfWork.Commit();
            return user;
        }
    }
    public class GetAssignManpowerListHandler : IRequestHandler<GetAssignManpowerListService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetAssignManpowerListHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(GetAssignManpowerListService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.ManpowerRepository.GetAssignManpowerList(request.contractid);
            unitOfWork.Commit();
            return user;
        }
    }
   
    public class GetAssignManpowerSaveHandler : IRequestHandler<GetAssignManpowerSaveService, int>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetAssignManpowerSaveHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(GetAssignManpowerSaveService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.ManpowerRepository.GetAssignManpowerSave(request.AssignManpowerSave);
            unitOfWork.Commit();
            return user;
        }
    }
    public class GetAssignManpowerDeleteHandler : IRequestHandler<GetAssignManpowerDeleteService, int>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetAssignManpowerDeleteHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(GetAssignManpowerDeleteService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.ManpowerRepository.GetAssignManpowerDelete(request.AssignManpowerDelete);
            unitOfWork.Commit();
            return user;
        }
    }

    //Assign field officer


    public class GetFieldOfficerSaveHandler : IRequestHandler<GetFieldOfficerSaveService, int>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetFieldOfficerSaveHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(GetFieldOfficerSaveService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.ManpowerRepository.GetFieldOfficerSave(request.FieldOfficerSave);
            unitOfWork.Commit();
            return user;
        }
    }
    public class GetFieldOfficerDeleteHandler : IRequestHandler<GetFieldOfficerDeleteService, int>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetFieldOfficerDeleteHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(GetFieldOfficerDeleteService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.ManpowerRepository.GetFieldOfficerDelete(request.FieldOfficerDelete);
            unitOfWork.Commit();
            return user;
        }
    }

    public class GetFieldOfficerHandler : IRequestHandler<GetFieldOfficerService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetFieldOfficerHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(GetFieldOfficerService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.ManpowerRepository.GetFieldOfficer(request.FieldOfficer);
            return user;
        }
    }
    public class GetAllManpowerNameHandler : IRequestHandler<GetAllManpowerNameService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetAllManpowerNameHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(GetAllManpowerNameService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.ManpowerRepository.GetAllManpowerName();
            return user;
        }
    }

    public class GetManpowerDirectHandler : IRequestHandler<GetManpowerDirectService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetManpowerDirectHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(GetManpowerDirectService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.ManpowerRepository.GetManpowerDirect();
            return user;
        }
    }

    public class SaveManpowerdirectHandler : IRequestHandler<SaveManpowerdirectService, int>
    {
        private readonly IUnitOfWork unitOfWork;

        public SaveManpowerdirectHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(SaveManpowerdirectService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.ManpowerRepository.SaveManpowerdirect(request.SaveManpowerdirect);
            unitOfWork.Commit();
            return user;
        }
    }

    public class GetShiftdetailsdirectHandler : IRequestHandler<GetShiftdetailsdirectService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetShiftdetailsdirectHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(GetShiftdetailsdirectService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.ManpowerRepository.GetShiftdetailsdirect(request.GetShiftdetailsdirect);
            unitOfWork.Commit();
            return user;
        }
    }

}
