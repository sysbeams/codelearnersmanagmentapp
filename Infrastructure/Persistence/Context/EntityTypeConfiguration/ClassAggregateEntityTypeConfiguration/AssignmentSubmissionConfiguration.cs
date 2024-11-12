using Domain.Aggreagtes.ClassAggregate;
using Domain.Aggreagtes.StudentAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Context.EntityTypeConfiguration.ClassAggregateEntityTypeConfiguration
{
    public class AssignmentSubmissionConfiguration : IEntityTypeConfiguration<AssignmentSubmission>
    {
        public void Configure(EntityTypeBuilder<AssignmentSubmission> builder)
        {
            builder.HasKey(asg => asg.Id);
            builder.Property(asg => asg.Content);
            builder.Property(asg => asg.Link);
            builder.Property(asg => asg.Grade);
            builder.HasOne<Assignment>().WithMany()
           .HasForeignKey(asg => asg.AssignmentId).IsRequired();
            builder.HasOne<Student>().WithMany()
             .HasForeignKey(asg => asg.StudentId).IsRequired();
        }
    }
}
