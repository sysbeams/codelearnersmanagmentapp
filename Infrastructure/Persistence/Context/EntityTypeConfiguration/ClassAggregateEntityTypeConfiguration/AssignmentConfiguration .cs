using Domain.Aggreagtes.ClassAggregate;
using Domain.Aggreagtes.CourseAggregate;
using Domain.Aggreagtes.StaffAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Context.EntityTypeConfiguration.ClassAggregateEntityTypeConfiguration
{
    public class AssignmentEntityTypeConfiguration : IEntityTypeConfiguration<Assignment>
    {
        public void Configure(EntityTypeBuilder<Assignment> builder)
        {
            builder.HasKey(a => a.Id);
            builder.HasOne<Course>().WithMany()
           .HasForeignKey(c => c.CourseId).IsRequired();
            builder.Property(a => a.Content).IsRequired();
            builder.Property(a => a.Link);
            builder.Property(a => a.Grade);
            builder.HasOne(a => a.Class).WithMany()
           .HasForeignKey(a => a.BatchId).IsRequired();
            builder.Property(a => a.SubmissionDate).IsRequired();
        }
    }
}
