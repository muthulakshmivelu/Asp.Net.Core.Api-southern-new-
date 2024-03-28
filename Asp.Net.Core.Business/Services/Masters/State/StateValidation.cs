using Asp.Net.Core.Business.Services.State;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.Net.Core.Business.Services.Masters.State
{
    public class StateSaveValidation : AbstractValidator<StateSaveService>
    {

    }
    public class StateListValidation : AbstractValidator<StateListService>
    {

    }
    public class StateFetchValidation : AbstractValidator<StateFetchService>
    {

    }
    public class StateDeleteValidation : AbstractValidator<StateDeleteService>
    {

    }
}
