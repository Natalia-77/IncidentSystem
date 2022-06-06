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
            builder.HasKey(key => key.Id);
            builder.Property(p => p.Id)
                .HasColumnName("Id");
            builder.Property(p => p.Title)
                .HasColumnName("Title")
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(p => p.Description)
              .HasColumnName("Description")
              .HasMaxLength(200)
              .IsRequired();
        }
    }
}
