using Bankcom.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankcom.Configuraions
{
    internal class BranchConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Branch> builder)
        {
             builder.HasKey(b => b.BranchId);
            builder.Property(b => b.BranchCode).IsRequired().HasMaxLength(50);
            builder.Property(b => b.BranchName).IsRequired().HasMaxLength(100);
            builder.Property(b => b.Address).IsRequired().HasMaxLength(200);
                builder.Property(b => b.PhoneNumber).IsRequired().HasMaxLength(15);
           builder.HasOne(b => b.Manger)
                .WithOne(m => m.Branch)
                .HasForeignKey<Branch>(b => b.MangerId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany<Account>(b => b.BranchAccounts)
                .WithOne(a => a.Branch)
                .HasForeignKey(a => a.BranchId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
