using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.Core.Business.Services.EmployeeSalaryMasterMapping
{
    public class EmployeeSalarySaveService : IRequest<int>
    {
        public string EmployeeSalarySave { get; set; }
    }
    public class EmployeeSalaryListService : IRequest<string>
    {

    }
    public class GetByIdService : IRequest<string>
    {
        public int empid { get; set; }
    }



    public class EmployeeSalaryDeleteService : IRequest<int>
    {

        // public string EmployeeSalaryDelete { get; set; }
        public int inputId { get; set; }
    }
}
