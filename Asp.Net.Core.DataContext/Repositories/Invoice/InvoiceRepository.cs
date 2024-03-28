using Asp.Net.Core.DataContext.InterfaceRepository.Department;
using Asp.Net.Core.DataContext.InterfaceRepository.Invoice;
using Asp.Net.Core.DataContext.RepositoryBases;
using Asp.Net.Core.DataModel.Models;
using Dapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.Core.DataContext.Repositories.Invoice
{
    public class InvoiceRepository : RepositoryBase, IInvoiceRepository
    {
        public InvoiceRepository(IDbTransaction transaction) : base(transaction)
        {
        }

        public async Task<DataSet> GenerateTaxInvoiceReport(string obj)
        {
            var dataset = new DataSet();
            var dataTable1 = new DataTable();
            var dataTable2 = new DataTable();
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_txt", obj);
            var result = await Connection.QueryFirstOrDefaultAsync<Table2>($"contract.fn_tax_invoice_by_contract", datas,
             commandType: CommandType.StoredProcedure, transaction: Transaction);
            try
            {
                dataTable1 = JsonConvert.DeserializeObject<DataTable>(result.Records1);
                dataTable2 = JsonConvert.DeserializeObject<DataTable>(result.Records2);
            }
            catch (Exception ex)
            {
                dataTable1 = new DataTable();
                dataTable2 = new DataTable();
            }
            dataset.Tables.Add(dataTable1);
            dataset.Tables.Add(dataTable2);
            return dataset;
        }
    }
}
