using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.Core.DataContext.InterfaceRepository.Common
{
    public interface ICountryRepository
    {
        Task<int> CountrySave(string value);
        Task<string> CountryList(string value);
        Task<string> CountryById(string value);
        Task<int> CountryDelete(string value);
    }
}
