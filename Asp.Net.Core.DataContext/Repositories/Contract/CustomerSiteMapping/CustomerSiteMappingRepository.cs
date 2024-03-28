using Asp.Net.Core.DataContext.InterfaceRepository.Contract.CustomerMaster;
using Asp.Net.Core.DataContext.InterfaceRepository.Contract.CustomerSiteMapping;
using Asp.Net.Core.DataContext.RepositoryBases;
using Asp.Net.Core.DataModel.Models;
using Dapper;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.Core.DataContext.Repositories.Contract.CustomerSiteMapping
{
    public class CustomerSiteMappingRepository : RepositoryBase, ICustomerSiteMappingRepository
    {
        public CustomerSiteMappingRepository(IDbTransaction transaction) : base(transaction)
        {
        }

        // customer drop down

        public async Task<string> GetCustomerDropDown()
        {
            var response = await Connection.QueryFirstOrDefaultAsync<Table>($"southern.fn_customer_name_drop_down_list",
                 commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response.Records;
        }

        //delete
        public async Task<int> BranchMasterDelete(string value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_txt", value);
            var response = await Connection.QueryFirstOrDefaultAsync<int>($"southern.fn_branch_master_delete",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response;
        }
        public async Task<int> SiteMasterDelete(string value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_txt", value);
            var response = await Connection.QueryFirstOrDefaultAsync<int>($"southern.fn_site_master_delete",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response;
        }
        public async Task<int> ClassificationMasterDelete(string value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_txt", value);
            var response = await Connection.QueryFirstOrDefaultAsync<int>($"southern.fn_classification_site_mapping_delete",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response;
        }

        //list

        public async Task<string> GetBranchMasterList(string value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_txt", value);
            var response = await Connection.QueryFirstOrDefaultAsync<Table>($"southern.fn_branch_master_list",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response.Records;
        }

        public async Task<string> GetSiteMasterList(string value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_txt", value);
            var response = await Connection.QueryFirstOrDefaultAsync<Table>($"southern.fn_site_master_list",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response.Records;
        }


        public async Task<string> GetClassificationMasterList(string value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_txt", value);
            var response = await Connection.QueryFirstOrDefaultAsync<Table>($"southern.c",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response.Records;
        }
        public async Task<string> Locationlist(string value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_txt", value);
            var response = await Connection.QueryFirstOrDefaultAsync<Table>($"southern.fn_location_list_dropdown",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response.Records;
        }

        public async Task<string> ContractListAllocate(string value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_txt", value);
            var response = await Connection.QueryFirstOrDefaultAsync<Table>($"southern.fn_Contract_manpower_list_dropdown",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response.Records;
        }

        public async Task<string> ContractServiceList(string value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_txt", value);
            var response = await Connection.QueryFirstOrDefaultAsync<Table>($"southern.fn_Contract_designation_list_dropdown",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response.Records;
        }

        public async Task<string> ContractListbyCustomer(int value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_customer_id", value);
            var response = await Connection.QueryFirstOrDefaultAsync<Table>($"contract.fn_Contract_allocate_list_dropdown",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response.Records;
        }
        //public async Task<string> AllocationList(string value)
        //{
        //    DynamicParameters datas = new DynamicParameters();
        //    datas.Add("@v_txt", value);
        //    var response = await Connection.QueryFirstOrDefaultAsync<Table>($"southern.fn_manpower_allocation_list_contract",
        //         datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
        //    return response.Records;
        //}
        public async Task<string> AllocationList(int value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_contract_id", value);
            var response = await Connection.QueryFirstOrDefaultAsync<Table>($"contract.fn_manpower_allocation_list_contract",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response.Records;
        }

        //save

        public async Task<int> BranchMasterSave(string value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_txt", value);
            var response = await Connection.QueryFirstOrDefaultAsync<int>($"southern.fn_branch_master_save",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response;
        }

        public async Task<int> SiteMasterSave(string value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_txt", value);
            var response = await Connection.QueryFirstOrDefaultAsync<int>($"southern.fn_site_master_save",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response;
        }

        public async Task<int> ClassificationMasterSave(string value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_txt", value);
            var response = await Connection.QueryFirstOrDefaultAsync<int>($"southern.fn_classification_site_mapping_save",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response;
        }

        //////////////////// Allocate Manpower ////////////
        ///
        public async Task<int> AllocateManpowerSiteSave(string value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_txt", value);
            var response = await Connection.QueryFirstOrDefaultAsync<int>($"contract.fn_manpower__allocation_save",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response;
        }
        public async Task<string> GetMAServiceList(string value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_txt", value);
            var response = await Connection.QueryFirstOrDefaultAsync<Table>($"southern.fn_service_drop_down_list",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response.Records;
        }
        public async Task<string> AllocateManpowerSiteList(string value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_txt", value);
            var response = await Connection.QueryFirstOrDefaultAsync<Table>($"southern.fn_manpower_site_allocation_List",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response.Records;
        }
        public async Task<int> AllocateManpowerSiteDelete(string value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_txt", value);
            var response = await Connection.QueryFirstOrDefaultAsync<int>($"contract.fn_manpower_allocation_delete",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response;
        }
        public async Task<int> SaveLocation(string value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_txt", value);
            var response = await Connection.QueryFirstOrDefaultAsync<int>($"contract.fn_contract_locations_save",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response;
        }

        public async Task<int> DeleteLocation(string value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_txt", value);
            var response = await Connection.QueryFirstOrDefaultAsync<int>($"contract.fn_contract_locations_delete",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response;
        }
        public async Task<string> GetLocation(string value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_txt", value);
            var response = await Connection.QueryFirstOrDefaultAsync<Table>($"contract.fn_contract_locations_get",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response.Records;
        }

        public async Task<string> GetContractList()
        {
            var response = await Connection.QueryFirstOrDefaultAsync<Table>($"contract.fn_contract_locations_contract_list",
                 commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response.Records;
        }
        public async Task<string> LocationFetch(string value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_txt", value);
            var response = await Connection.QueryFirstOrDefaultAsync<Table>($"contract.fn_contract_locations_fetch",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response.Records;
        }
    }
}
