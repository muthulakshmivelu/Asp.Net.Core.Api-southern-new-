using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.Core.Business.Services.PayrollAttendance
{
    public class PayrollAttendanceService: IRequest<int>
    {
        public string PayrollAttendanceSave { get; set; }
    }
    public class PayrollAttendanceListService : IRequest<string>
    {

    }
    public class PayrollAttendanceGetByIdService : IRequest<string>
    {
        public int empid { get; set; }
    }



    public class PayrollAttendanceDeleteService : IRequest<int>
    {


        public int inputId { get; set; }
    }
}
