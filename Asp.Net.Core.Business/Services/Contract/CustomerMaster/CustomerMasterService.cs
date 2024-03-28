using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.Net.Core.Business.Services.Contract.CustomerMaster
{
    public class CustomerSaveService : IRequest<int>
    {
        public string CustomerSave { get; set; }
    }
    public class CustomerListService : IRequest<string>
    {
        
    }
    public class CustomerFetchService : IRequest<string>
    {
        public string CustomerFetch { get; set; }
    }
}
