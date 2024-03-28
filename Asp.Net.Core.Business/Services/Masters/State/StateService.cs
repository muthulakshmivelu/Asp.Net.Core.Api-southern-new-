using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.Net.Core.Business.Services.Masters.State
{
    public class StateSaveService : IRequest<int>
    {
        public string StateSave { get; set; }
    }
    public class StateListService : IRequest<string>
    {
        public string StateList { get; set; }
    }
    public class StateFetchService : IRequest<string>
    {
        public string StateFetch { get; set; }
    }
    public class StateDeleteService : IRequest<int>
    {
        public string StateDelete { get; set; }
    }
}
