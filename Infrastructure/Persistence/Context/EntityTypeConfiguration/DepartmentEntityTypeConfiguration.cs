using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Context.EntityTypeConfiguration
{
    public class DepartmentEntityTypeConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Organization).WithMany(x => x.Departments);
            builder.Property(x => x.HeadOfStaffId).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.HasMany(x => x.Staffs).WithMany(x => x.AdjunctDepartments);
            builder.HasMany(x => x.AdjuncStaffs).WithOne(x => x.Department);
        }
    }
}
