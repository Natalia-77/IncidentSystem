using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ModelBuilderconfig
{
    public class AccountConfig : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("tblAccount");
            builder.HasKey(key => key.Id);
            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.Name)
                .HasColumnName("AccountName")
                .HasMaxLength(150)
                .IsRequired();

        }
    }
}
