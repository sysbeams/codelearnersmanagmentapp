

using Domain.Aggreagtes.StaffAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class StaffEntityTypeConfiguration : IEntityTypeConfiguration<Staff>
{
    public void Configure(EntityTypeBuilder<Staff> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.StaffNo)
            .IsRequired();
        builder.Property(x => x.Firstname)
            .IsRequired();
        builder.Property(x => x.EmailAddress)
            .IsRequired();
        builder.Property(x => x.Phonenumber)
            .IsRequired();
        builder.Property(x => x.Gender)
            .IsRequired();
        builder.Property(x => x.DateOfBirth)
            .IsRequired();
        builder.HasOne(x => x.ContactInfo)
            .WithOne()
            .IsRequired();
        builder.HasOne(x => x.NextOfKin)
           .WithOne();
        builder.HasOne(x => x.BankDetails)
           .WithOne();
        builder.HasMany(x => x.AdjunctDepartments)
            .WithOne();
        builder.HasMany(x => x.EmploymentContracts)
            .WithOne();

    }
}