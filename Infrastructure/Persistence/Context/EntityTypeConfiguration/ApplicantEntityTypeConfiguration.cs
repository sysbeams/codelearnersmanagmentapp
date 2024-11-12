using Domain.Aggreagtes.ApplicantAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Context.EntityTypeConfiguration
{
    public class ApplicantEntityTypeConfiguration : IEntityTypeConfiguration<Applicant>
    {
        public void Configure(EntityTypeBuilder<Applicant> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.FirstName)
                .IsRequired().HasMaxLength(50);

            builder.Property(a => a.MiddleName)
                .IsRequired().HasMaxLength(50);

            builder.Property(a => a.LastName)
                .IsRequired().HasMaxLength(50);

            builder.Property(a => a.EmailAddress)
                .IsRequired().HasMaxLength(30);

            builder.Property(a => a.PhoneNumber) 
                .IsRequired().HasMaxLength(15);

            builder.Property(a => a.DateOfBirth)
                .IsRequired();

            builder.Property(a => a.Gender)
                .IsRequired();

            builder.OwnsOne(a => a.NextOfKin, nextOfKin =>
            {
                builder.Property(nk => nk.NextOfKin.NokFirstName).IsRequired().HasMaxLength(50);
                builder.Property(nk => nk.NextOfKin.NokLastName).IsRequired().HasMaxLength(50);
                builder.Property(nk => nk.NextOfKin.Relationship).IsRequired().HasMaxLength(50);
            });

            builder.OwnsOne(a => a.Address, address =>
            {
                builder.Property(add => add.Address.StreetName).IsRequired().HasMaxLength(50);
                builder.Property(add => add.Address.StreetNo).IsRequired().HasMaxLength(50);
                builder.Property(add => add.Address.City).IsRequired().HasMaxLength(50);
                builder.Property(add => add.Address.State).IsRequired().HasMaxLength(50);
                builder.Property(add => add.Address.Country).IsRequired().HasMaxLength(50);
            });

            builder.HasMany(a => a.Applications)
                .WithOne(app => app.Applicant).HasForeignKey(app => app.ApplicantId);

            builder.HasOne(a => a.User)
                .WithOne().HasForeignKey<Applicant>(a => a.UserId);
        }
    }
}
