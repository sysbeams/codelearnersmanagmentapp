using Domain.Aggreagtes.Organization_Aggregate;
using Domain.Aggreagtes.StaffAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Context.EntityTypeConfiguration
{
    public class EmploymentContractEntityTypeConfiguration : IEntityTypeConfiguration<EmploymentContract>
    {
        public void Configure(EntityTypeBuilder<EmploymentContract> builder)
        {
            builder.HasKey(x => x.ContractId);
            builder.HasOne<Staff>()
                .WithMany(x => x.EmploymentContracts)
                .HasForeignKey(x => x.StaffId);
            builder.HasOne<Organization>()
                .WithOne()
                .HasForeignKey("OrganizationId");
            builder.Property(x => x.Salary)
                .IsRequired();
            builder.Property(x => x.Benefits)
                .IsRequired();
            builder.Property(x => x.OrganizationId)
                .IsRequired();
            builder.Property(x => x.StartDate)
                .IsRequired();

        }
    }
}
