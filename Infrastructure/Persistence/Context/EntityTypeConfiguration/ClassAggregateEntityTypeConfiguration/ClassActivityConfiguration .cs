using Domain.Aggreagtes.ClassAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Context.EntityTypeConfiguration.ClassAggregateEntityTypeConfiguration
{
    public class ClassActivityConfiguration : IEntityTypeConfiguration<ClassActivity>
    {
        public void Configure(EntityTypeBuilder<ClassActivity> builder)
        {
                builder.HasKey(ca => ca.Id);
                builder.Property(ca => ca.ActivityType);
                builder.Property(ca => ca.Grade);
                builder.HasOne(ca => ca.Student).WithMany().IsRequired();
                builder.HasOne(ca => ca.Class).WithMany().IsRequired();
           
        }
    }
}
