using Asp.Net.Core.DataContext.InterfaceRepository.Holiday;
using Asp.Net.Core.DataContext.RepositoryBases;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.Core.DataContext.Repositories.Holiday
{
    public class HolidayRepository : RepositoryBase, IHolidayRepository
    {
        public HolidayRepository(IDbTransaction transaction) : base(transaction)
        {
        }
        public async Task<int> HolidayDelete(int holidayid)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@holiday_id", holidayid);


            var response = await Connection.ExecuteAsync("southern.fn_holiday_delete", datas,
                 commandType: CommandType.StoredProcedure, transaction: Transaction);

            return response;
        }

        public async Task<string> HolidayList()
        {
            DynamicParameters datas = new DynamicParameters();

            var response = await Connection.QueryFirstOrDefaultAsync<string>("southern.fn_holiday_list",
                datas, commandType: CommandType.StoredProcedure, transaction: Transaction);

            return response;
        }

        public async Task<int> HolidaySave(string value)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@v_input", value);

            var response = await Connection.ExecuteAsync(
                "SELECT southern.fn_holiday_save(@v_input::json)",
                parameters,
                commandType: CommandType.Text,
                transaction: Transaction
            );

            return response;
        }
    }
}
