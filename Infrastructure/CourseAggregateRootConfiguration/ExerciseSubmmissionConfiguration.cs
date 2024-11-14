using Domain.Aggreagtes.CourseAggregate;
using Domain.Aggreagtes.StudentAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.CourseAggregateRootConfiguration
{
    public class ExerciseSubmmissionConfiguration : IEntityTypeConfiguration<Certificate>
    {
        public void Configure(EntityTypeBuilder<Certificate> builder)
        {
            builder.ToTable("Certificates");

            // Configure primary key
            builder.HasKey(c => c.Id);

            // Configure properties
            builder.Property(c => c.StudentId)
                .IsRequired();

            builder.Property(c => c.CourseId)
                .IsRequired();

            builder.Property(c => c.IssueDate)
                .IsRequired();

            // Configure relationships
            builder.HasOne<Student>()
                .WithMany() // Assuming Student does not contain a collection of Certificates
                .HasForeignKey(c => c.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<Course>()
                .WithMany() // Assuming Course does not contain a collection of Certificates
                .HasForeignKey(c => c.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
