using ImagineBeyond.Customer.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImagineBeyond.Repository.Mappings
{
    public class CustomerMap : IEntityTypeConfiguration<CustomerEntity>
    {
        public void Configure(EntityTypeBuilder<CustomerEntity> builder)
        {
            builder.Property(c => c.Id);

            builder.Property(c => c.LastName).HasMaxLength(100).IsRequired();

            builder.Property(c => c.FirstName).HasMaxLength(100).IsRequired();

            builder.Property(c => c.Email).HasMaxLength(200).IsRequired();

            builder.Property(c => c.DateCreate);

            builder.Property(c => c.DateLastUpdate);
        }
    }
}
