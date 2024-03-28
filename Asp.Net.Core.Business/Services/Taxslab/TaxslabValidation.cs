using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.Core.Business.Services.Taxslab
{
    public class TaxslabValidation : AbstractValidator<TaxslabService>
    {
    }
    public class TaxslabListValidation : AbstractValidator<TaxslabListService>
    {

    }

    public class TaxslabDeleteValidation : AbstractValidator<TaxslabDeleteService>
    {

    }
}
