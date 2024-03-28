using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;

namespace Asp.Net.Core.Api.Filters
{
    public class FluentValidationExceptionAttribute : ExceptionFilterAttribute
    {
        public override Task OnExceptionAsync(ExceptionContext context)
        {
            HandleException(context);
            return Task.CompletedTask;
        }

        public override void OnException(ExceptionContext context)
        {
            HandleException(context);
        }

        private static void HandleException(ExceptionContext context)
        {
            var validationException = context.Exception as ValidationException;

            if (validationException == null)
            {
                context.ExceptionHandled = false;
                return;
            }

            var modelState = new ModelStateDictionary();
            foreach (var error in validationException.Errors)
            {
                modelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
            context.ExceptionHandled = true;
            context.Result = new BadRequestObjectResult(modelState);
        }
    }
}
