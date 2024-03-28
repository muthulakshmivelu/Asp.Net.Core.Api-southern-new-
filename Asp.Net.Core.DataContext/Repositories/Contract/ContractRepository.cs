using Asp.Net.Core.DataContext.InterfaceRepository.Contract;
using Asp.Net.Core.DataContext.RepositoryBases;
using Asp.Net.Core.DataModel.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.Core.DataContext.Repositories.Contract
{
   public class ContractRepository : RepositoryBase, IContractRepository
    {
        public ContractRepository(IDbTransaction transaction) : base(transaction)
        {
        }
        public async Task<int> ContractSave(string value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_txt", value);
            var response = await Connection.QueryFirstOrDefaultAsync<int>($"southern.fn_contract_save",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response;
        }
        public async Task<int> ContractDelete(string value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_txt", value);
            var response = await Connection.QueryFirstOrDefaultAsync<int>($"southern.fn_contracts_delete",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response;
        }
        public async Task<string> GetConsumableRequirement(string value)
        {
            DynamicParameters values = new DynamicParameters();
            values.Add("@v_txt", value);
            var result = await Connection.QueryFirstOrDefaultAsync<Table>($"southern.fn_consumable_requirement_list", values,
                 commandType: CommandType.StoredProcedure, transaction: Transaction);
            return result.Records;
        }
        public async Task<string> GetContractByAllCustomer(string value)
        {
            DynamicParameters values = new DynamicParameters();
            values.Add("@v_txt", value);
            var result = await Connection.QueryFirstOrDefaultAsync<Table>($"southern.fn_contract_by_allcustomer_list", values,
                 commandType: CommandType.StoredProcedure, transaction: Transaction);
            return result.Records;
        }
        public async Task<string> GetContractDetails(string value)
        {
            DynamicParameters values = new DynamicParameters();
            values.Add("@v_txt", value);
            var result = await Connection.QueryFirstOrDefaultAsync<Table>($"southern.fn_contract_details_list", values,
                 commandType: CommandType.StoredProcedure, transaction: Transaction);
            return result.Records;
        }
        public async Task<string> GetContract(string value)
        {
            DynamicParameters values = new DynamicParameters();
            values.Add("@v_txt", value);
            var result = await Connection.QueryFirstOrDefaultAsync<Table>($"southern.fn_contract_list", values,
                 commandType: CommandType.StoredProcedure, transaction: Transaction);
            return result.Records;
        }
        public async Task<string> GetContractMaster(string value)
        {
            DynamicParameters values = new DynamicParameters();
            values.Add("@v_txt", value);
            var result = await Connection.QueryFirstOrDefaultAsync<Table>($"southern.fn_contract_master_list", values,
                 commandType: CommandType.StoredProcedure, transaction: Transaction);
            return result.Records;
        }
        public async Task<string> GetAllCustomer(string value)
        {
            DynamicParameters values = new DynamicParameters();
            values.Add("@v_txt", value);
            var result = await Connection.QueryFirstOrDefaultAsync<Table>($"southern.fn_all_customer_list", values,
                 commandType: CommandType.StoredProcedure, transaction: Transaction);
            return result.Records;
        }
        public async Task<string> GetContractsListByCustomerId(string value)
        {
            DynamicParameters values = new DynamicParameters();
            values.Add("@v_txt", value);
            var result = await Connection.QueryFirstOrDefaultAsync<Table>($"southern.fn_contracts_list_by_customerid", values,
                 commandType: CommandType.StoredProcedure, transaction: Transaction);
            return result.Records;
        }

        public async Task<string> GetDeparmentAsServiceList()
        {
            var response = await Connection.QueryFirstOrDefaultAsync<Table>($"southern.fn_all_department_as_service_list",
                 commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response.Records;
        }

        public async Task<string> GetDesignetionByService(string value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_txt", value);
            var response = await Connection.QueryFirstOrDefaultAsync<Table>($"southern.fn_get_desig_by_dept_id",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response.Records;
        }
        public async Task<string> GetCustomerNameList()
        {
            var response = await Connection.QueryFirstOrDefaultAsync<Table>($"southern.fn_contract_customer_name_list",
                 commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response.Records;
        }
        public async Task<Table6> ContractDetailsFetch(string value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_txt", value);
            var response = await Connection.QueryFirstOrDefaultAsync<Table6>($"southern.fn_contract_fetch",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response;
        }
        public async Task<string> getclienttype()
        {
            var response = await Connection.QueryFirstOrDefaultAsync<Table>($"southern.fn_list_clienttype",
                 commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response.Records;
        }

    }
}
