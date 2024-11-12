using Domain.Aggreagtes.ApplicantAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Context.EntityTypeConfiguration
{
    public class AssessmentEntityTypeConfiguration : IEntityTypeConfiguration<Assessment>
    {
        public void Configure(EntityTypeBuilder<Assessment> builder)
        {
            builder.HasKey(ass => ass.Id);

            builder.Property(ass => ass.ScheduledDateTime)
                .IsRequired();

            builder.Property(ass => ass.AssessmentStatus)
                .IsRequired();

            builder.Property(ass => ass.AssessmentMode)
                .IsRequired();

            builder.Property(ass => ass.AssessmentType)
                .IsRequired();

            builder.Property(ass => ass.AssessmentResult)
                .IsRequired();

            builder.Property(ass => ass.Remark)
                .IsRequired().HasMaxLength(500);

            builder.HasOne(ass => ass.Application)
                .WithOne(app => app.Assessment)
                .HasForeignKey<Assessment>(ass => ass.ApplicationId);
        }
    }
}
