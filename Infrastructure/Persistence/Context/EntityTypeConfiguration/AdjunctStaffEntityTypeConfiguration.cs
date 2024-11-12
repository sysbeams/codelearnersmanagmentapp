using Domain.Aggreagtes.Organization_Aggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Context.EntityTypeConfiguration
{
    public class AdjunctStaffEntityTypeConfiguration : IEntityTypeConfiguration<AdjuncStaff>
    {
        public void Configure(EntityTypeBuilder<AdjuncStaff> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.StaffId).IsRequired();
            builder.Property(x => x.StartDate).HasColumnType("datetime(0)");
            builder.Property(x => x.EndDate).HasColumnType("datetime(0)");
            builder.HasOne(x => x.Department).WithMany(x => x.AdjuncStaffs);
        }
    }
}
