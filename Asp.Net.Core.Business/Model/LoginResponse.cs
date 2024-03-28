using System;
using System.Collections.Generic;
using System.Net;

namespace Asp.Net.UserControl.Business.Model
{
    public class LoginResponse : ConnectorResponse
    {
        public int UserId { get; set; }
        public string UserName { get; set; }

        public HttpStatusCode StatusCode { get; set; }
    }
}
