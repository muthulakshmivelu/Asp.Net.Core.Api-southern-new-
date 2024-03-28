using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.Core.Business.Services.salarycomponent
{
    public class SalaryComponentSaveService: IRequest<int>
    {
        public string SalaryComponentSave { get; set; }
    }
    public class SalaryComponentListService : IRequest<string>
    {

    }
    //public class SalaryComponentFetchService : IRequest<string>
    //{
    //    public string SalaryComponentFetch { get; set; }
    //}
    public class SalaryComponentDeleteService : IRequest<int>
    {
        public string SalaryComponentDelete { get; set; }
        public object InputEmpId { get; internal set; }
        public object InputSalComId { get; internal set; }
    }
}
