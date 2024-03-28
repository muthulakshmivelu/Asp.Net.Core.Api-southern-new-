using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Asp.Net.Core.Api.Filters
{  
    public class ApiIActionFilter : IActionFilter
    {
            private const int DefaultMaxRequestPerSecond = 3;

            private readonly IDistributedCache _cache;

            public int MaxRequestPerSecond { get; set; } = DefaultMaxRequestPerSecond;

            public ApiIActionFilter(IDistributedCache cache)
            {
                _cache = cache ?? throw new ArgumentNullException(nameof(cache));
            }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Debug.Write(MethodBase.GetCurrentMethod(), context.HttpContext.Request.Path);
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var throttleAttribute = context.ActionDescriptor.FilterDescriptors
             .Select(x => x.Filter).OfType<ThrottleAttribute>().FirstOrDefault();

            if (throttleAttribute != null)
            {
                throttleAttribute.MaxRequestPerSecond.ToString();
                context.HttpContext.Items["Example"] = "Value from attribute";
            }
        }
    }
    public class ThrottleAttribute : Attribute, IFilterMetadata
    {
        public int MaxRequestPerSecond { get; set; }
    }
}

