using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.Core.Business.Services.EmployeeLeaveMapping
{
    public class EmpLeaMapService : IRequest<int>
    {
        public string EmpLeaSave { get; set; }
    }
    public class EmpLeaMapListService : IRequest<string>
    {

    }
    public class GetEmpLeaveByIdService : IRequest<string>
    {
        public int empid { get; set; }
    }




    public class EmpLeaMapDeleteService : IRequest<int>
    {


        public int inputId { get; set; }
    }
}
