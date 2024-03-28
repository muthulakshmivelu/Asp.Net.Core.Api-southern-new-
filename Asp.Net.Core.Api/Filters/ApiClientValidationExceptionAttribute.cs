using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Net.Http.Headers;
using Asp.Net.Core.Business.ApiClients;
using System.Net;
using System.Threading.Tasks;
namespace Asp.Net.Core.Api.Filters
{
    public class ApiClientValidationExceptionAttribute : ExceptionFilterAttribute
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
            var apiClientException = context.Exception as ApiClientException;

            if (apiClientException == null || apiClientException.Response.StatusCode != HttpStatusCode.BadRequest)
            {
                context.ExceptionHandled = false;
                return;
            }

            var responseContent = apiClientException.Response.Content.ReadAsStringAsync().Result;

            var result = new BadRequestObjectResult(responseContent);
            result.ContentTypes.Add(new MediaTypeHeaderValue(apiClientException.Response.Content.Headers.ContentType.MediaType));
            context.Result = result;

            context.ExceptionHandled = true;
        }
    }
}
