using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net.Core.Api.Filters
{
    //public class AuthorizationFilterContext : FilterContext
    //{
    //    //public AuthorizationFilterContext(IAuthorizationPolicyProvider policyProvider, IEnumerable<IAuthorizeData> authorizeData)
    //    //{
    //    //    policyProvider.GetDefaultPolicyAsync();
    //    //    //if (policyProvider == null)
    //    //    //{
    //    //    //    // throw new ArgumentNullException(nameof(policyProvider));
    //    //    //    policyProvider.GetDefaultPolicyAsync();
    //    //    //}

    //    //    //PolicyProvider = policyProvider;
    //    //}
    //}
}
        //public static class datastructure 
        //{
        //    private static bool HasAllowAnonymous(AuthorizationFilterContext context)
        //    {
        //        var filters = context.Filters;
        //        for (var i = 0; i < filters.Count; i++)
        //        {
        //            if (filters[i] is IAllowAnonymousFilter)
        //            {
        //                return true;
        //            }
        //        }
        //        return false;
        //    }
        //}
    
