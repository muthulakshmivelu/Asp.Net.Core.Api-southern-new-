using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.Core.DataContext.InterfaceRepository.Holiday
{
    public interface IHolidayRepository
    {
        Task<int> HolidaySave(string value);
        Task<string> HolidayList();

        Task<int> HolidayDelete(int holidayid);
    }
}
