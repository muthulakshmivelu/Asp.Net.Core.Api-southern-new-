using Microsoft.EntityFrameworkCore;
using System;

namespace Asp.Net.Core.DataModel
{
    public class APIUserControlContext : DbContext
    {
        public APIUserControlContext(DbContextOptions<APIUserControlContext> options)
       : base(options)
        { 
        }
    }
}
