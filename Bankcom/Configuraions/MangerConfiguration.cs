using Bankcom.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankcom.Configuraions
{
    internal class MangerConfiguration : IEntityTypeConfiguration<Manger>
    {
        public void Configure(EntityTypeBuilder<Manger> builder)
        {
            builder.HasKey(m => m.MangerId);
            builder.Property(m => m.FullName).IsRequired().HasMaxLength(100);
            builder.Property(m => m.Email).IsRequired().HasMaxLength(90);
            builder.Property(m => m.PhoneNumber).IsRequired().HasMaxLength(20);
            builder.Property(m => m.HireDate).IsRequired();
         
        }
    }
}
