using Domain.Aggreagtes.CourseAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.CourseAggregateRootConfiguration
{
    public class PracticalConfiguration : IEntityTypeConfiguration<Pratical>
    {
        public void Configure(EntityTypeBuilder<Pratical> builder)
        {
            builder.ToTable("Praticals");

            // Configure primary key
            builder.HasKey(p => p.Id);

            // Configure properties
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Link)
                .HasMaxLength(200); // Optional length constraint for URLs

            builder.Property(p => p.Content)
                .HasColumnType("nvarchar(max)"); // Assuming content could be large

            builder.Property(p => p.TopicId)
                .IsRequired();

            // Configure the relationship with Topic
            builder.HasOne<Topic>()
                .WithMany(t => t.Praticals)
                .HasForeignKey(p => p.TopicId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
