using Domain.Aggreagtes.CourseAggregate;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.CourseAggregateRootConfiguration
{
    public class CourseBatchConfiguration : IEntityTypeConfiguration<CourseBatch>
    {
        public void Configure(EntityTypeBuilder<CourseBatch> builder)
        {
            builder.HasKey(cb => cb.Id);
            builder.Property(cb => cb.BatchNo).IsRequired();
            builder.Property(cb => cb.DateOpened).IsRequired();
            builder.Property(cb => cb.DateClosed).IsRequired();
            builder.Property(cb => cb.Capacity).IsRequired();

            // Configure the navigation property
            
            builder.HasOne(cb => cb.Course)
                .WithMany(c => c.Batches)
                .HasForeignKey("CourseId");

            // COnfigure the enum navigation property
           /* builder.Property(cb => cb.CourseModes)
            .HasConversion<int>();*/
            builder.Property(cb => cb.CourseModes)
            .HasConversion(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                v => JsonSerializer.Deserialize<List<CourseMode>>(v, (JsonSerializerOptions)null)
            )
            .HasColumnType("nvarchar(max)"); // Adjust the type as necessary
        }
    }
}
