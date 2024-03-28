using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.Net.Core.DataModel.DBContext
{
    public class DBPostgresContext : DbContext
    {
        public DBPostgresContext(DbContextOptions<DBPostgresContext> options)
      : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
