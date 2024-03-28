using Asp.Net.Core.DataContext.InterfaceRepository.EmployeeSalaryMasterMapping;
using Asp.Net.Core.DataContext.RepositoryBases;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.Core.DataContext.Repositories.EmployeeSalaryMasterMapping
{
    public class EmployeeSalaryRepository : RepositoryBase, IEmployeeSalaryRepository
    {
        public EmployeeSalaryRepository(IDbTransaction transaction) : base(transaction)
        {
        }
        public async Task<int> EmployeeSalaryDelete(int inputId)
        {
                //int inputId = 15;  Replace 1 with the desired hardcoded value
                //int inputId = int.Parse(value);

                DynamicParameters datas = new DynamicParameters();
                datas.Add("@input_id", inputId);


                var response = await Connection.ExecuteAsync("southern.fn_employeesalarymaster_mapping_delete", datas,
                     commandType: CommandType.StoredProcedure, transaction: Transaction);

                return response;
            }

        public async Task<string> EmployeeSalaryList()
        {
            DynamicParameters datas = new DynamicParameters();

            var response = await Connection.QueryFirstOrDefaultAsync<string>("southern.fn_employeesalarymaster_mapping_list",
                datas, commandType: CommandType.StoredProcedure, transaction: Transaction);

            return response;
        }

        public  async Task<int> EmployeeSalarySave(string value)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@v_text", value);

            var response = await Connection.QueryFirstOrDefaultAsync<int>(
                "SELECT southern.fn_employeesalarymaster_mapping_save(@v_text::json)",
                parameters,
                commandType: CommandType.Text,
                transaction: Transaction
            );

            return response;
        }

        public async Task<string> GetById(int empid)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@v_empid", empid);

            var response = await Connection.QueryFirstOrDefaultAsync<string>("southern.fn_get_employee_by_id",
                parameters, commandType: CommandType.StoredProcedure, transaction: Transaction);

            return response;
        }
    }
}
