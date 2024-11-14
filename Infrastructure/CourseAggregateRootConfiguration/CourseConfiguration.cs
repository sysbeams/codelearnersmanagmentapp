using Domain.Aggreagtes.CourseAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.CourseAggregateRootConfiguration
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            // Set the table name
            // Set the table name
            builder.ToTable("Courses");

            // Configure primary key
            builder.HasKey(c => c.Id);

            // Configure properties
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(c => c.CourseInformation)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(c => c.CoverPhotoUrl)
                .HasMaxLength(200);

            builder.Property(c => c.Duration)
                .IsRequired();

            builder.Property(c => c.DurationUnit)
                .IsRequired();

            // Configure relationships
            builder.HasOne(c => c.Curriculum)
                .WithOne()
                .HasForeignKey("CurriculumId") // Adjust as necessary
                .OnDelete(DeleteBehavior.Cascade);

            // Configure the relationship with CourseBatch
            builder.HasMany(c => c.Batches)
                .WithOne(cb => cb.Course) // CourseBatch has a reference back to Course
                .OnDelete(DeleteBehavior.Cascade); // Adjust delete behavior as needed
        }
    }
}
