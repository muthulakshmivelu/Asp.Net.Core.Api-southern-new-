using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.Net.Core.Business.Services.Designation
{
    public class DesignationSaveService : IRequest<int>
    {
        public string DesignationSave { get; set; }
    }
    public class DesignationListService : IRequest<string>
    {

    }
    public class DesignationFetchService : IRequest<string>
    {
        public string DesignationFetch { get; set; }
    }
    public class DesignationDeleteService : IRequest<int>
    {
        public string DesignationDelete { get; set; }
    }
}
