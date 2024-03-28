using Asp.Net.Core.DataContext.InterfaceRepository.Attendance;
using Asp.Net.Core.DataContext.InterfaceRepository.Contract;
using Asp.Net.Core.DataContext.RepositoryBases;
using Asp.Net.Core.DataModel.Models;
using Asp.Net.Core.DataModel.Models.Department;
using Asp.Net.Core.DataModel.Utilities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.Core.DataContext.Repositories.Attendance
{
    public class AttendanceRepository : RepositoryBase, IAttendanceRepository
    {
        public AttendanceRepository(IDbTransaction transaction) : base(transaction)
        {
        }

        public async Task<string> AttendanceStatusList()
        {
            var response = await Connection.QueryFirstOrDefaultAsync<Table>($"southern.fn_attendance_status_list",
                 commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response.Records;
        }

        public async Task<string> CustomerBranchSiteDropDownList(string value)
        {
            DynamicParameters values = new DynamicParameters();
            values.Add("@v_txt", value);
            var result = await Connection.QueryFirstOrDefaultAsync<Table>($"southern.c", values,
                 commandType: CommandType.StoredProcedure, transaction: Transaction);
            return result.Records;
        }

        public async Task<string> GetManpowerDetailsList(string value)
        {
            DynamicParameters values = new DynamicParameters();
            values.Add("@v_txt", value);
            var result = await Connection.QueryFirstOrDefaultAsync<Table>($"contract.fn_attendance_manpower_details_list_grid", values,
                 commandType: CommandType.StoredProcedure, transaction: Transaction);
            return result.Records;
        }
        public async Task<int> ManPowerAttendanceSave(string value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_txt", value);
            var response = await Connection.QueryFirstOrDefaultAsync<int>($"southern.fn_manpower_attendance_save",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response;
        }
        public async Task<string> GetManpowerPivotDetailsList(dynamic value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_txt", value);
            var response = await Connection.QueryFirstOrDefaultAsync<Table5>($"southern.execute_manpower_attendance_pivot_query",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response.Data;
        }
    }
}
