using Asp.Net.Core.DataContext.InterfaceRepository.Taxlab;
using Asp.Net.Core.DataContext.RepositoryBases;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.Core.DataContext.Repositories.Taxlab
{
    public class TaxslabRepository : RepositoryBase, ITaxslabRepository
    {
        public TaxslabRepository(IDbTransaction transaction) : base(transaction)
        {
        }
        public async Task<int> TaxslabDelete(int taxslabid)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_taxslabid", taxslabid);


            var response = await Connection.ExecuteAsync("southern.fn_taxslab_delete", datas,
                 commandType: CommandType.StoredProcedure, transaction: Transaction);

            return response;
        }

        public async Task<string> TaxslabList()
        {
            DynamicParameters datas = new DynamicParameters();

            var response = await Connection.QueryFirstOrDefaultAsync<string>("southern.fn_taxslab_list",
                datas, commandType: CommandType.StoredProcedure, transaction: Transaction);

            return response;
        }

        public async Task<int> TaxslabSave(string value)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@v_input", value);

            var response = await Connection.ExecuteAsync(
                "SELECT southern.fn_taxslab_save(@v_input::json)",
                parameters,
                commandType: CommandType.Text,
                transaction: Transaction
            );

            return response;
        }
    }
}
