using Asp.Net.Core.DataContext.InterfaceRepository.orders;
using Asp.Net.Core.DataContext.RepositoryBases;
using Asp.Net.Core.DataModel.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.Core.DataContext.Repositories.orders
{
    public class OrdersRepository: RepositoryBase,IordersRepository
    {
        public OrdersRepository(IDbTransaction transaction): base(transaction) 
        { 

        }

        public async Task<int> ordersDelete(string value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@json_data", value);
            var response = await Connection.QueryFirstOrDefaultAsync<int>($"test.insert_update_order",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response;
        }

    //    public async Task<string> ordersFetch(string value)
      //  {
        //    DynamicParameters datas = new DynamicParameters();
          //  datas.Add("@json_data", value);
            //var response = await Connection.QueryFirstOrDefaultAsync<Table>($"test.insert_update_order",
              //   datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            //return response.Records;
        //}
    
        public async Task<string> ordersList(string value)
        { 
                DynamicParameters datas = new DynamicParameters();
                datas.Add("@v_txt", value);
            var response = await Connection.QueryFirstOrDefaultAsync<Table>($"test.fn_order_save",
                     datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
                return response.Records;
            
        }

        public async Task<int> ordersSave(string value)
        {
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_txt", value);
            var response = await Connection.QueryFirstOrDefaultAsync<int>($"test.fn_order_save",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response;
        }

        public async Task<string> ordersFetch(string value)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@json_data", value);

            var result = await Connection.ExecuteAsync("test.insert_update_order", parameters, commandType: CommandType.StoredProcedure, transaction: Transaction);

            return result.ToString(); // Assuming you want to return the number of affected records or some other indication of success/failure
        }

    }
}
