using Domain.Aggreagtes.CourseAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.CourseAggregateRootConfiguration
{
    public class TopicConfiguration : IEntityTypeConfiguration<Topic>
    {
        public void Configure(EntityTypeBuilder<Topic> builder)
        {
            builder.ToTable("Topics");

            // Configure primary key
            builder.HasKey(t => t.Id);

            // Configure properties
            builder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(t => t.CurriculumId)
                .IsRequired();

            // Configure the relationship with Curriculum
            builder.HasOne<Curriculum>()
                .WithMany(c => c.Topics)
                .HasForeignKey(t => t.CurriculumId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure the relationship with Praticals
            builder.HasMany(typeof(Pratical), "_praticals")
                .WithOne()
                .HasForeignKey("TopicId") // Shadow property in Pratical
                .OnDelete(DeleteBehavior.Cascade);

            // Configure the relationship with Exercises
            builder.HasMany(typeof(Exercise), "_exercises")
                .WithOne()
                .HasForeignKey("TopicId") // Shadow property in Exercise
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
