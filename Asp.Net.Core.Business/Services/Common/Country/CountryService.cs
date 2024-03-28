using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.Net.Core.Business.Services.Common.Country
{
    public class CountrySaveService : IRequest<int>
    {
        public string Country { get; set; }
    }
    public class CountryListService : IRequest<string>
    {
        public string Country { get; set; }
    }
    public class CountryByIdService : IRequest<string>
    {
        public string Country { get; set; }
    }
    public class CountryDeleteService : IRequest<int>
    {
        public string Country { get; set; }
    }
}
