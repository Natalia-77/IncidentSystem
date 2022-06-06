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
    public class ContactConfig : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("tblContact");
            builder.HasKey(key => key.Id);
            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.FirstName)
                .HasColumnName("FirstName")
                .HasMaxLength(200)
                .IsRequired();
            builder.Property(p => p.LastName)
                .HasColumnName("LastName")
                .HasMaxLength(200)
                .IsRequired();
            builder.Property(p => p.Email)
                .HasColumnName("Email")
                .IsRequired();
            builder.HasOne(a => a.Account)
                .WithMany(c => c.Contacts)
                .HasForeignKey(fk => fk.AccountId);
        }
    }
}
