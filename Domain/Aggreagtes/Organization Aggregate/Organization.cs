using Domain.Common.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggreagtes.Organization_Aggregate
{
    public class Organization : AuditableEntity, IAggregateRoot
    {
        public required string Name { get; set; } = default!;

    }
}
