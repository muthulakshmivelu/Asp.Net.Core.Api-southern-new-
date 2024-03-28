using Asp.Net.Core.DataContext.RepositoryBases;
using Asp.Net.Core.DataModel.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Threading.Tasks;
using Asp.Net.Core.DataContext.InterfaceRepository.Master;

namespace Asp.Net.Core.DataContext.Repositories.Master
{
    public class StateRepository : RepositoryBase, IStateRepository
    {
        public StateRepository(IDbTransaction transaction) : base(transaction)
        {
        }

        public async Task<int> StateSave(string value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_txt", value);
            var response = await Connection.QueryFirstOrDefaultAsync<int>($"southern.fn_state_save",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response;
        }

        public async Task<string> StateList(string value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_txt", value);
            var response = await Connection.QueryFirstOrDefaultAsync<Table>($"southern.fn_get_all_state_list",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response.Records;
        }

        public async Task<string> StateFetch(string value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_txt", value);
            var response = await Connection.QueryFirstOrDefaultAsync<Table>($"southern.fn_get_state_by_id",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response.Records;
        }
        public async Task<int> StateDelete(string value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_txt", value);
            var response = await Connection.QueryFirstOrDefaultAsync<int>($"southern.fn_get_state_delete",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response;
        }
    }
}
