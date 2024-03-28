using Asp.Net.Core.DataContext.InterfaceRepository.Employeeinfo;
using Asp.Net.Core.DataContext.RepositoryBases;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.Core.DataContext.Repositories.Employeeinfo
{
    public class EmployeeinfoRepository : RepositoryBase, IEmployeeinfoRepository
    {
        public EmployeeinfoRepository(IDbTransaction transaction) : base(transaction)
        {
        }   
        public async Task<string> EmployeeinfoList()
        {
            DynamicParameters datas = new DynamicParameters();

            var response = await Connection.QueryFirstOrDefaultAsync<string>("southern.fn_employeeinfo_list",
                datas, commandType: CommandType.StoredProcedure, transaction: Transaction);

            return response;
        }
    }
}
