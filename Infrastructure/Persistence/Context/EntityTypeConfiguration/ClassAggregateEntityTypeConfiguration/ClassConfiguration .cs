using Domain.Aggreagtes.ClassAggregate;
using Domain.Aggreagtes.StaffAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Context.EntityTypeConfiguration.ClassAggregateEntityTypeConfiguration
{
    public class ClassConfiguration : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.ScheduledDateTime).IsRequired();
            builder.Property(c => c.Duration).IsRequired();
            builder.Property(c => c.Topic).IsRequired().HasMaxLength(200);
            builder.HasOne<Staff>().WithMany()
            .HasForeignKey(c => c.StaffId).IsRequired();
        }
    }
}
