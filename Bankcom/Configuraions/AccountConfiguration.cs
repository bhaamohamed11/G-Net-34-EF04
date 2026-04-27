using Bankcom.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankcom.Configuraions
{
    internal class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(a => a.AccountNumber);

            builder.Property(a => a.Type)
                .IsRequired();
            builder.Property(a => a.OpeningDate)
                .IsRequired();
            builder.Property(a => a.CurrentBalance)
                .IsRequired();
           

        }
    }
}
