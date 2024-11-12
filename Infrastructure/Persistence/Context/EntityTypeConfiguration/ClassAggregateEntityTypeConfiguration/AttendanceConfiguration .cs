using Domain.Aggreagtes.ClassAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Context.EntityTypeConfiguration.ClassAggregateEntityTypeConfiguration
{
    public class AttendanceConfiguration : IEntityTypeConfiguration<Attendance>
    {
        public void Configure(EntityTypeBuilder<Attendance> builder)
        {
            builder.HasKey(a => a.Id);
            builder.HasOne(a => a.Class) .WithMany().IsRequired();
            builder.HasMany(a => a.AttendanceList).WithMany();
            builder.HasMany(a => a.AbsentList).WithMany();
        }
    }
}
