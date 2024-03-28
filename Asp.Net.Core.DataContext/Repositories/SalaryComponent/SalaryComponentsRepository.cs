using Asp.Net.Core.DataContext.InterfaceRepository.SalaryComponent;
using Asp.Net.Core.DataContext.RepositoryBases;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.Core.DataContext.Repositories.SalaryComponent
{
    public class SalaryComponentsRepository : RepositoryBase, ISalaryComponentsRepository
    {
        public SalaryComponentsRepository(IDbTransaction transaction) : base(transaction)
        {
        }
        public async Task<int> SalaryComponentDelete(string value)
        {
            int inputId = 15; // Replace 1 with the desired hardcoded value

            DynamicParameters datas = new DynamicParameters();
            datas.Add("@input_id", inputId);

            var response = await Connection.ExecuteAsync("southern.fn_salary_component_delete", datas,
                commandType: CommandType.StoredProcedure, transaction: Transaction);

            return response;
        }

        public async Task<string> SalaryComponentList()
        {
            DynamicParameters datas = new DynamicParameters();

            var response = await Connection.QueryFirstOrDefaultAsync<string>("southern.fn_salary_component_list",
                datas, commandType: CommandType.StoredProcedure, transaction: Transaction);

            return response;
        }

        public async Task<int> SalaryComponentSave(string value)
        {
            //        var inputJson = @"{
            //    ""input_structureid"": 1,
            //    ""input_structurename"": ""Basic"",
            //    ""input_structuretype"": ""Fixed"",
            //    ""input_structurefrequency"": ""Monthly""
            //}";

            DynamicParameters datas = new DynamicParameters();
            datas.Add("@input_text", value);

            var response = await Connection.QueryFirstOrDefaultAsync<int>("southern.fn_salary_component_save",
                datas, commandType: CommandType.StoredProcedure, transaction: Transaction);

            return response;
        }
    }
}
