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
    public class BankDetailsEntityTypeConfiguration : IEntityTypeConfiguration<BankDetails>
    {
        public void Configure(EntityTypeBuilder<BankDetails> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.BankName).IsRequired();
            builder.Property(x => x.AccountNumber).IsRequired();
        }
    }
}
