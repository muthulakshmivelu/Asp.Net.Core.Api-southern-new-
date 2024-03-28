using Asp.Net.Core.DataModel.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Threading.Tasks;
using Asp.Net.Core.DataContext.InterfaceRepository.ManPower;
using Asp.Net.Core.DataContext.RepositoryBases;
using Dapper;
using Asp.Net.Core.DataContext.InterfaceRepository.Contract.CustomerMaster;

namespace Asp.Net.Core.DataContext.Repositories.Contract.CustomerMaster
{
    public class CustomerMasterRepository : RepositoryBase, ICustomerMasterRepository
    {
        public CustomerMasterRepository(IDbTransaction transaction) : base(transaction)
        {
        }

        public async Task<int> CustomerSave(string value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_txt", value);
            var response = await Connection.QueryFirstOrDefaultAsync<int>($"southern.fn_customer_master_save",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response;
        }

        public async Task<string> CustomerList()
        {
            var response = await Connection.QueryFirstOrDefaultAsync<Table>($"southern.fn_customer_master_list",
                 commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response.Records;
        }

        public async Task<string> CustomerFetch(string value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_txt", value);
            var response = await Connection.QueryFirstOrDefaultAsync<Table>($"southern.fn_customer_master_fetch",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response.Records;
        }
    }
}
