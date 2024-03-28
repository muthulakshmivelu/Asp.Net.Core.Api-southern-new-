using System;
using System.Net.Http;

namespace Asp.Net.Core.Business.ApiClients
{
    public class ApiClientException : Exception
    {
        public ApiClientException(HttpResponseMessage response) : base(GenerateMessage(response))
        {
            Response = response;
        }

        private static string GenerateMessage(HttpResponseMessage response) =>
            $@"Request: {response.RequestMessage.Method} {response.RequestMessage.RequestUri}
            Response: {response.StatusCode}
            Content: {response.Content.ReadAsStringAsync().Result}";

        public HttpResponseMessage Response { get; }
    }
}
