using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.Core.Business.Services.Taxslab
{
    public class TaxslabService : IRequest<int>
    {
        public string TaxslabSave { get; set; }
    }
    public class TaxslabListService : IRequest<string>
    {

    }




    public class TaxslabDeleteService : IRequest<int>
    {


        public int taxslabid { get; set; }
    }
}
