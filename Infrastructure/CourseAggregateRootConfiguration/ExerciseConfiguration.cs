using Domain.Aggreagtes.CourseAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.CourseAggregateRootConfiguration
{
    public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> builder)
        {
            builder.ToTable("Exercises");

            // Configure primary key
            builder.HasKey(e => e.Id);

            // Configure properties
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Link)
                .HasMaxLength(200); 

            builder.Property(e => e.Content)
                .HasColumnType("nvarchar(max)"); 

            builder.Property(e => e.TopicId)
                .IsRequired();

            // Configure the relationship with Topic
            builder.HasOne<Topic>()
                .WithMany(t => t.Exercises)
                .HasForeignKey(e => e.TopicId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
