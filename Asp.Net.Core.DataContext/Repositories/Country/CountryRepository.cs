using Asp.Net.Core.DataContext.InterfaceRepository.Common;
using Asp.Net.Core.DataContext.InterfaceRepository.Contract;
using Asp.Net.Core.DataContext.RepositoryBases;
using Asp.Net.Core.DataModel.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.Core.DataContext.Repositories.Country
{
    internal class CountryRepository : RepositoryBase, ICountryRepository
    {
        public CountryRepository(IDbTransaction transaction) : base(transaction)
        {
        }

        public async Task<int> CountrySave(string value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_txt", value);
            var response = await Connection.QueryFirstOrDefaultAsync<int>($"common.fn_country_save",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response;
        }
        public async Task<string> CountryList(string value)
        {
            DynamicParameters values = new DynamicParameters();
            values.Add("@v_txt", value);
            var result = await Connection.QueryFirstOrDefaultAsync<Table>($"common.fn_country_select", values,
                 commandType: CommandType.StoredProcedure, transaction: Transaction);
            return result.Records;
        }
        public async Task<string> CountryById(string value)
        {
            DynamicParameters values = new DynamicParameters();
            values.Add("@v_txt", value);
            var result = await Connection.QueryFirstOrDefaultAsync<Table>($"common.fn_country_by_id", values,
                 commandType: CommandType.StoredProcedure, transaction: Transaction);
            return result.Records;
        }

        public async Task<int> CountryDelete(string value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_txt", value);
            var response = await Connection.QueryFirstOrDefaultAsync<int>($"common.fn_country_delete_by_id",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response;
        }

    }
}
