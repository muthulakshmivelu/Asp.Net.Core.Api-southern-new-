using Asp.Net.Core.DataContext.InterfaceRepository.Designation;
using Asp.Net.Core.DataContext.InterfaceRepository.ManPower;
using Asp.Net.Core.DataContext.RepositoryBases;
using Asp.Net.Core.DataModel.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.Core.DataContext.Repositories.Designation
{
    public class DesignationRepository : RepositoryBase, IDesignationRepository
    {
        public DesignationRepository(IDbTransaction transaction) : base(transaction)
        {
        }

        public async Task<int> DesignationSave(string value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_txt", value);
            var response = await Connection.QueryFirstOrDefaultAsync<int>($"southern.",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response;
        }

        public async Task<string> DesignationList()
        {
            var response = await Connection.QueryFirstOrDefaultAsync<Table>($"southern.",
                 commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response.Records;
        }

        public async Task<string> DesignationFetch(string value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_txt", value);
            var response = await Connection.QueryFirstOrDefaultAsync<Table>($"southern.",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response.Records;
        }
        public async Task<int> DesignationDelete(string value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_txt", value);
            var response = await Connection.QueryFirstOrDefaultAsync<int>($"southern.",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response;
        }
    }
}
