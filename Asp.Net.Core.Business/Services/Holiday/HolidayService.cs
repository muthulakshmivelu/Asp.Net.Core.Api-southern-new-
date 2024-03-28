using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.Core.Business.Services.Holiday
{
    public class HolidayService : IRequest<int>
    {
        public string HolidaySave { get; set; }
    }
    public class HolidayListService : IRequest<string>
    {

    }

    public class HolidayDeleteService : IRequest<int>
    {


        public int holidayid { get; set; }
    }
}
