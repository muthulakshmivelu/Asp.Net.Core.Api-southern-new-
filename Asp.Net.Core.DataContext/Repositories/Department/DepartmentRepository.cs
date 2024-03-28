using Asp.Net.Core.DataContext.InterfaceRepository.Department;
using Asp.Net.Core.DataContext.RepositoryBases;
using Asp.Net.Core.DataModel.Models;
using Asp.Net.Core.DataModel.Models.Department;
using Asp.Net.Core.DataModel.Utilities;
using Dapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.Core.DataContext.Repositories.Department
{
    public class DepartmentRepository : RepositoryBase,IDepartmentRepository
    {
        public DepartmentRepository(IDbTransaction transaction) : base(transaction)
        {
        }

        //public async Task<List<DepartmentEntity>> GetDepartmentList()
        //{
        //    var result = new List<DepartmentEntity>();
        //    var dataTable = new DataTable();
        //    var response = await Connection.ExecuteReaderAsync($"test.fn_department_list",
        //         commandType: CommandType.StoredProcedure, transaction: Transaction);
        //    dataTable.Load(response);
        //    result = Utilities.ConvertDataTableToEntityList<DepartmentEntity>(dataTable);
        //    return result;
        //}

        //public async Task<int> DeartmentSave(DepartmentEntity value)
        //{
        //    DynamicParameters datas = new DynamicParameters();
        //    datas.Add("@v_department_id", value.id);
        //    datas.Add("@v_department_code", value.department_code);
        //    datas.Add("@v_department_name", value.department_name);
        //    var response = await Connection.QueryFirstOrDefaultAsync<int>($"test.fn_department_save",
        //         datas,commandType: CommandType.StoredProcedure, transaction: Transaction);
        //    return response;
        //}

        //public async Task<List<DepartmentEntity>> DepartmentFetch(DepartmentIdEntity value)
        //{
        //    DynamicParameters datas = new DynamicParameters();
        //    datas.Add("@v_department_id", value.id);
        //    var result = new List<DepartmentEntity>();
        //    var dataTable = new DataTable();
        //    var response = await Connection.ExecuteReaderAsync($"test.fn_department_fetch",
        //        datas,commandType: CommandType.StoredProcedure, transaction: Transaction);
        //    dataTable.Load(response);
        //    result = Utilities.ConvertDataTableToEntityList<DepartmentEntity>(dataTable);
        //    return result;
        //}

        //public async Task<int> DepartmentDelete(DepartmentIdEntity value)
        //{
        //    DynamicParameters datas = new DynamicParameters();
        //    datas.Add("@v_department_id", value.id);
        //    var response = await Connection.QueryFirstOrDefaultAsync<int>($"test.fn_department_delete",
        //         datas,commandType: CommandType.StoredProcedure, transaction: Transaction);
        //    return response;
        //}
        //public async Task<DataSet> DepartmentListReport(bool Active)
        //{
        //    var dataset = new DataSet();
        //    var dataTable = new DataTable();
        //    var result = await Connection.QueryFirstOrDefaultAsync<Table>($"public.fn_department_list", 
        //     commandType: CommandType.StoredProcedure, transaction: Transaction);
        //    try
        //    {
        //        dataTable = JsonConvert.DeserializeObject<DataTable>(result.Records);
        //    }
        //    catch (Exception ex)
        //    {
        //        dataTable = new DataTable();
        //    }
        //    dataset.Tables.Add(dataTable);
        //    return dataset;
        //}

        public async Task<int> DepartmentSave(string value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_txt", value);
            var response = await Connection.QueryFirstOrDefaultAsync<int>($"southern.",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response;
        }

        public async Task<string> DepartmentList()
        {
            var response = await Connection.QueryFirstOrDefaultAsync<Table>($"southern.",
                 commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response.Records;
        }

        public async Task<string> DepartmentFetch(string value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_txt", value);
            var response = await Connection.QueryFirstOrDefaultAsync<Table>($"southern.",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response.Records;
        }
        public async Task<int> DepartmentDelete(string value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_txt", value);
            var response = await Connection.QueryFirstOrDefaultAsync<int>($"southern.",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response;
        }
    }
}
