using Asp.Net.Core.DataContext.InterfaceRepository.ManPower;
using Asp.Net.Core.DataContext.RepositoryBases;
using Asp.Net.Core.DataModel.Models;
using Asp.Net.Core.DataModel.Models.Department;
using Asp.Net.Core.DataModel.Models.ManPower;
using Asp.Net.Core.DataModel.Utilities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.Core.DataContext.Repositories.ManPower
{
    internal class ManpowerRepository : RepositoryBase, ImanpowerRepository
    {
        public ManpowerRepository(IDbTransaction transaction) : base(transaction)
        {
        }

        //All Drop Down

        public async Task<string> GetCompanyList()
        {
            var response = await Connection.QueryFirstOrDefaultAsync<Table>($"southern.fn_all_company_list",
                 commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response.Records;
        }
        public async Task<string> GetCountryList()
        {
            var response = await Connection.QueryFirstOrDefaultAsync<Table>($"southern.fn_all_country_list",
                 commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response.Records;
        }
        public async Task<string> GetStateList()
        {
            var response = await Connection.QueryFirstOrDefaultAsync<Table>($"southern.fn_all_state_list",
                 commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response.Records;
        }
        public async Task<string> GetCityList(string value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_txt", value);
            var response = await Connection.QueryFirstOrDefaultAsync<Table>($"southern.fn_all_city_list",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response.Records;
        }
        public async Task<string> GetBankList()
        {
            var response = await Connection.QueryFirstOrDefaultAsync<Table>($"southern.fn_all_bank_list",
                 commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response.Records;
        }
        public async Task<string> GetDesignationList()
        {
            var response = await Connection.QueryFirstOrDefaultAsync<Table>($"southern.fn_all_designation_list",
                 commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response.Records;
        }
        public async Task<string> GetPaymentModeList()
        {
            var response = await Connection.QueryFirstOrDefaultAsync<Table>($"southern.fn_all_payment_mode_list",
                 commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response.Records;
        }
        public async Task<string> GetProofList()
        {
            var response = await Connection.QueryFirstOrDefaultAsync<Table>($"southern.fn_all_proof_list",
                 commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response.Records;
        }
        public async Task<string> GetAccountTypeList()
        {
            var response = await Connection.QueryFirstOrDefaultAsync<Table>($"southern.fn_all_account_type_list",
                 commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response.Records;
        }

        //All Save
        public async Task<int> ManPowerDetailSave(string value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_txt", value);
            var response = await Connection.QueryFirstOrDefaultAsync<int>($"southern.fn_manpower_details_save",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response;
        }

        public async Task<int> ManPowerBankDetailSave(string value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_txt", value);
            var response = await Connection.QueryFirstOrDefaultAsync<int>($"southern.fn_manpower_bank_details_save",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response;
        }

        public async Task<int> ManPowerFamilyDetailSave(string value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_txt", value);
            var response = await Connection.QueryFirstOrDefaultAsync<int>($"southern.fn_manpower_family_details_save",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response;
        }

        public async Task<int> ManPowerProofDetailSave(string value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_txt", value);
            var response = await Connection.QueryFirstOrDefaultAsync<int>($"southern.fn_manpower_proof_details_save",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response;
        }

        //All List

        public async Task<string> GetManpowerList()
        {
            var response = await Connection.QueryFirstOrDefaultAsync<Table>($"southern.fn_manpower_detail_list",
                 commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response.Records;
        }

        public async Task<string> GetManpowerBankList(string value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_txt", value);
            var response = await Connection.QueryFirstOrDefaultAsync<Table>($"southern.fn_manpower_bank_details_list",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response.Records;
        }

        public async Task<string> GetManpowerFamilyList(string value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_txt", value);
            var response = await Connection.QueryFirstOrDefaultAsync<Table>($"southern.fn_manpower_family_details_list",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response.Records;
        }


        public async Task<string> GetManpowerProofList(string value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_txt", value);
            var response = await Connection.QueryFirstOrDefaultAsync<Table>($"southern.fn_manpower_proof_details_list",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response.Records;
        }

        // All Delete

        public async Task<int> ManPowerBankDelete(string value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_txt", value);
            var response = await Connection.QueryFirstOrDefaultAsync<int>($"southern.fn_manpower_bank_delete",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response;
        }
        public async Task<int> ManPowerFamilyDelete(string value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_txt", value);
            var response = await Connection.QueryFirstOrDefaultAsync<int>($"southern.fn_manpower_family_delete",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response;
        }
        public async Task<int> ManPowerProofDelete(string value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_txt", value);
            var response = await Connection.QueryFirstOrDefaultAsync<int>($"southern.fn_manpower_proof_delete",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response;
        }

        //fetch
        public async Task<Table4> ManPowerDetailFetch(string value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_txt", value);
            var response = await Connection.QueryFirstOrDefaultAsync<Table4>($"southern.fn_manpower_details_fetch",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response;
        }


        //For Assign Manpower Start

        public async Task<string> GetClassificationList(string value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_txt", value);
            var response = await Connection.QueryFirstOrDefaultAsync<Table>($"southern.fn_classification_dropdown_list",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response.Records;
        }
        public async Task<string> GetContractIdList(string value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_txt", value);
            var response = await Connection.QueryFirstOrDefaultAsync<Table>($"southern.fn_shift_dropdown_list",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response.Records;
        }
        public async Task<string> GetServiceList(string value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_txt", value);
            var response = await Connection.QueryFirstOrDefaultAsync<Table>($"southern.fn_service_dropdown_list",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response.Records;
        }
        public async Task<string> GetManpowerNameList(string value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_txt", value);
            var response = await Connection.QueryFirstOrDefaultAsync<Table>($"southern.fn_manpower_dropdown_list",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response.Records;
        }
        public async Task<string> GetAssignManpowerList(int value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_contractid", value);
            var response = await Connection.QueryFirstOrDefaultAsync<Table>($"contract.fn_manpower_assign_list",
               datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response.Records;
        }

        public async Task<int> GetAssignManpowerSave(string value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_txt", value);
            var response = await Connection.QueryFirstOrDefaultAsync<int>($"southern.fn_assign_manpower_save",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response;
        }
        public async Task<int> GetAssignManpowerDelete(string value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_txt", value);
            var response = await Connection.QueryFirstOrDefaultAsync<int>($"southern.fn_assign_manpower_delete",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response;
        }

        // Assign Field Officer

        public async Task<int> GetFieldOfficerSave(string value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_txt", value);
            var response = await Connection.QueryFirstOrDefaultAsync<int>($"southern.fn_assign_field_officer_save",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response;
        }
        public async Task<int> GetFieldOfficerDelete(string value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_txt", value);
            var response = await Connection.QueryFirstOrDefaultAsync<int>($"southern.fn_assign_field_officer_delete",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response;
        }
        public async Task<string> GetFieldOfficer(string value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_txt", value);
            var response = await Connection.QueryFirstOrDefaultAsync<Table>($"southern.fn_assign_field_officer_list",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response.Records;
        }
        public async Task<string> GetAllManpowerName()
        {
            var response = await Connection.QueryFirstOrDefaultAsync<Table>($"southern.fn_all_employee_list",
                 commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response.Records;
        }

        public async Task<string> GetManpowerDirect()
        {
            var response = await Connection.QueryFirstOrDefaultAsync<Table>($"southern.fn_manpower_direct_assign_list",
                 commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response.Records;
        }
        public async Task<int> SaveManpowerdirect(string value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_txt", value);
            var response = await Connection.QueryFirstOrDefaultAsync<int>($"southern.fn_assign_manpower_direct_save",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response;
        }
        public async Task<string> GetShiftdetailsdirect(string value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_txt", value);
            var response = await Connection.QueryFirstOrDefaultAsync<Table>($"southern.fn_shift_dropdown_list_direct",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response.Records;
        }
    }
}
