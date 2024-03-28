using Asp.Net.Core.DataContext.InterfaceRepository.Payslip;
using Asp.Net.Core.DataContext.RepositoryBases;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.Core.DataContext.Repositories.Payslip
{
    public class PayslipRepository : RepositoryBase, IPayslipRepository
    {
        public PayslipRepository(IDbTransaction transaction) : base(transaction)
        {
        }
        public async  Task<int> PayslipDelete(int month, int year)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@p_month", month);
            parameters.Add("@p_year", year);

            var response = await Connection.ExecuteAsync(
                "Select southern.fn_payrollprocess_delete(@p_month, @p_year)",
                parameters,
                commandType: CommandType.Text,
                transaction: Transaction
            );

            return response;
        }


        public async Task<string> PayslipList()
        {
            DynamicParameters datas = new DynamicParameters();

            var response = await Connection.QueryFirstOrDefaultAsync<string>("southern.fn_payrollprocess_list",
                datas, commandType: CommandType.StoredProcedure, transaction: Transaction);

            return response;
        }

        public async Task<int> PayslipSave(string inputJson)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@p_input", inputJson);


            var response = await Connection.ExecuteAsync(
                "Select southern.fn_payrollprocess_save(@p_input::json)",
                parameters,
                commandType: CommandType.Text,
                transaction: Transaction
            );

            return response;
        }
    }
}
