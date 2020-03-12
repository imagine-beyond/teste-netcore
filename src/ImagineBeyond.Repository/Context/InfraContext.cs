using ImagineBeyond.Repository.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImagineBeyond.Repository.Context
{
    public class InfraContext : DbContext
    {
        
        public InfraContext(DbContextOptions<InfraContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CustomerMap());

            base.OnModelCreating(builder);
        }
    }
}
