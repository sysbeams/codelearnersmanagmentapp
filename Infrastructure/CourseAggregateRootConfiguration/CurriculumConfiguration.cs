using Domain.Aggreagtes.CourseAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.CourseAggregateRootConfiguration
{
    public class CurriculumConfiguration : IEntityTypeConfiguration<Curriculum>
    {
        public void Configure(EntityTypeBuilder<Curriculum> builder)
        {
            builder.ToTable("Curriculums"); // Optional: set table name

            // Configure primary key
            builder.HasKey(c => c.Id);

            // Configure the relationship with Course
            builder.HasOne<Course>()
                .WithOne(c => c.Curriculum)
                .HasForeignKey<Curriculum>(c => c.CourseId)
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete to remove curriculum with course

            // Configure CourseId as required
            builder.Property(c => c.CourseId)
                .IsRequired();

            // Configure Topics collection as a one-to-many relationship
            builder.HasMany(typeof(Topic), "_topics")
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
