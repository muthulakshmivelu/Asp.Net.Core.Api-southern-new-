using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.Core.Business.Services.Payslip
{
    public class PayslipService: IRequest<int>

    {
        public string PayslipSave { get; set; }
    }
    public class PayslipListService : IRequest<string>
    {

    }




    public class PayslipDeleteService : IRequest<int>
    {


        public int month { get; set; }

        public int year { get; set; }

    }
}
