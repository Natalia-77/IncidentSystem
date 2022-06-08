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
    public class IncidentConfig : IEntityTypeConfiguration<Incident>
    {
        public void Configure(EntityTypeBuilder<Incident> builder)
        {
            builder.ToTable("tblIncident");
            builder.HasKey(o => new { o.Name });          
            builder.Property(p => p.Name)
                .HasColumnName("Name")
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(p => p.Description)
              .HasColumnName("Description")
              .HasMaxLength(200)
              .IsRequired();
            builder.HasMany(im => im.Accounts)
               .WithOne(u => u.Incident)
               .HasForeignKey(r => r.IncidentNameKey);
        }
    }
}
