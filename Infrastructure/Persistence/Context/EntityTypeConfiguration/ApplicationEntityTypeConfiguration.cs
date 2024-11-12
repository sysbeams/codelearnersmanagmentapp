using Domain.Aggreagtes.ApplicantAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Context.EntityTypeConfiguration
{
    public class ApplicationEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Aggreagtes.ApplicantAggregate.Application>
    {
        public void Configure(EntityTypeBuilder<Domain.Aggreagtes.ApplicantAggregate.Application> builder)
        {
            builder.HasKey(app => app.Id);

            builder.Property(app => app.BatchId)
                .IsRequired();

            builder.Property(app => app.CourseId)
                .IsRequired();

            builder.Property(app => app.ApplicantId)
                .IsRequired();

            builder.Property(app => app.ApplicationStatus)
                .IsRequired();

            builder.Property(app => app.CourseMode)
                .IsRequired();

            builder.HasOne(app => app.Applicant)
                .WithMany(ap => ap.Applications).HasForeignKey(app => app.ApplicantId);

            builder.HasOne(app => app.Assessment)
                .WithOne(ass => ass.Application).HasForeignKey<Assessment>(ass => ass.ApplicationId);
        }
    }
}
