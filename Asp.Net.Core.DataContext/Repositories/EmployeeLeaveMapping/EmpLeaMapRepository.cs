using Asp.Net.Core.DataContext.InterfaceRepository.EmployeeLeaveMapping;
using Asp.Net.Core.DataContext.RepositoryBases;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.Core.DataContext.Repositories.EmployeeLeaveMapping
{
    public class EmpLeaMapRepository : RepositoryBase, IEmpLeaMapRepository
    {
        public EmpLeaMapRepository(IDbTransaction transaction) : base(transaction)
        {
        }
        public async Task<int> EmpLeaDelete(int inputId)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@input_id", inputId);


            var response = await Connection.ExecuteAsync("southern.fn_employeeleave_mapping_delete", datas,
                 commandType: CommandType.StoredProcedure, transaction: Transaction);

            return response;
        }

        public  async Task<string> EmpLeaList()
        {
            DynamicParameters datas = new DynamicParameters();

            var response = await Connection.QueryFirstOrDefaultAsync<string>("southern.fn_employeeleave_mapping_list",
                datas, commandType: CommandType.StoredProcedure, transaction: Transaction);

            return response;
        }

        public  async Task<int> EmpLeaSave(string value)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@v_input", value);

            var response = await Connection.ExecuteAsync(
                "SELECT southern.fn_employeeleave_mapping_save(@v_input::json)",
                parameters,
                commandType: CommandType.Text,
                transaction: Transaction
            );

            return response;
        }

        public async Task<string> GetEmpLeaveById(int empid)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@v_empid", empid);

            var response = await Connection.QueryFirstOrDefaultAsync<string>("southern.fn_getempleave_by_id",
                parameters, commandType: CommandType.StoredProcedure, transaction: Transaction);

            return response;
        }
    }
}
