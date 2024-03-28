using Asp.Net.Core.DataContext.InterfaceRepository.PayrollAttendance;
using Asp.Net.Core.DataContext.RepositoryBases;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.Core.DataContext.Repositories.PayrollAttendance
{
    public class PayrollAttendanceRepository : RepositoryBase, IPayrollAttendanceRepository
    {
        public PayrollAttendanceRepository(IDbTransaction transaction) : base(transaction)
        {
        }
        public async Task<int> PayrollAttendanceDelete(int inputId)
        {
            //int inputId = 15;  Replace 1 with the desired hardcoded value
            //int inputId = int.Parse(value);

            DynamicParameters datas = new DynamicParameters();
            datas.Add("@input_id", inputId);


            var response = await Connection.ExecuteAsync("southern.fn_attendance_delete", datas,
                 commandType: CommandType.StoredProcedure, transaction: Transaction);

            return response;
        }

        public async Task<string> PayrollAttendanceGetById(int empid)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@v_empid", empid);

            var response = await Connection.QueryFirstOrDefaultAsync<string>("southern.fn_getattendance_by_id",
                parameters, commandType: CommandType.StoredProcedure, transaction: Transaction);

            return response;
        }

        public async Task<string> PayrollAttendanceList()
        {
            DynamicParameters datas = new DynamicParameters();

            var response = await Connection.QueryFirstOrDefaultAsync<string>("southern.fn_attendance_list",
                datas, commandType: CommandType.StoredProcedure, transaction: Transaction);

            return response;
        }

        public async Task<int> PayrollAttendanceSave(string attendanceData)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@attendance_data", attendanceData);

            var response = await Connection.ExecuteScalarAsync<int>(
                "SELECT southern.fn_attendance_save(@attendance_data::json)",
                parameters,
                commandType: CommandType.Text,
                transaction: Transaction
            );

            return response;
        }
    }
}
