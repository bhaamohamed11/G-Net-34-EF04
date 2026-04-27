using Bankcom.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankcom.Configuraions
{
    internal class CustomerAccountConfiguration : IEntityTypeConfiguration<CustomerAccount>
    {
        public void Configure(EntityTypeBuilder<CustomerAccount> builder)
        {
          builder.HasKey(ca => new { ca.CustomerId, ca.AccountNumber });
            builder.Property(ca => ca.OwnerShipDate)
                 .IsRequired();
    
                builder.Property(ca => ca.OwnershipType)
                 .IsRequired();
    
                builder.Property(ca => ca.AccountStatus)
                 .IsRequired();
            builder.HasOne(ca => ca.Customer)
                .WithMany(c => c.CustomerAccounts)
                .HasForeignKey(ca => ca.CustomerId);

            builder.HasOne(ca => ca.Account)
                .WithMany(a => a.CustomerAccounts)
                .HasForeignKey(ca => ca.AccountNumber);
        }
    }
}