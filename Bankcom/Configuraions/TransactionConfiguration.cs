using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bankcom.Models;
namespace Bankcom.Configuraions
{
    internal class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
           builder.HasKey(t=>t.TransactionNumber);
            builder.Property(t=>t.TransactionDate).IsRequired();
            builder.Property(t=>t.Amount).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(t=>t.TransactionType).IsRequired();
            builder.Property(t=>t.Note).HasMaxLength(500);
            builder.HasOne<Account>(t => t.AccountTransaction)
                .WithMany(a => a.Transactions)
                .HasForeignKey(t => t.AccountNumber)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
