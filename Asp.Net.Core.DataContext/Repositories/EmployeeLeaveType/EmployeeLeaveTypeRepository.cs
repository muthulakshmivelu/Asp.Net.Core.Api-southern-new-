using Asp.Net.Core.DataContext.InterfaceRepository.EmployeeLeaveType;
using Asp.Net.Core.DataContext.RepositoryBases;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.Core.DataContext.Repositories.EmployeeLeaveType
{
    public class EmployeeLeaveTypeRepository : RepositoryBase, IEmployeeLeaveTypeRepository
    {
        public EmployeeLeaveTypeRepository(IDbTransaction transaction) : base(transaction)
        {
        }
        public async Task<string> LeaveTypeList()
        {
            DynamicParameters datas = new DynamicParameters();

            var response = await Connection.QueryFirstOrDefaultAsync<string>("southern.fn_leavetype_list",
                datas, commandType: CommandType.StoredProcedure, transaction: Transaction);

            return response;
        }
    }
}
