using Bankcom.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankcom.Configuraions
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c=>c.CustomerId);
            builder.Property(c => c.FullName).IsRequired().HasMaxLength(100);
            builder.Property(c=>c.Email).IsRequired().HasMaxLength(90);
            builder.Property(c=>c.PhoneNumber).IsRequired().HasMaxLength(20);
            builder.Property(c=>c.DateOfBirth).IsRequired();
            builder.Property(c=>c.Address).IsRequired().HasMaxLength(200);
             builder.Property(c => c.CustomerType).IsRequired();


        }
    }
}
