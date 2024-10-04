using Domain.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggreagtes.Organization_Aggregate
{
    public class Faculty : AuditableEntity<Guid>
    {
        public required string Name { get; set; } 
        public Guid StaffId { get; set; }
        public required Organization Organization { get; set; }
    }
}
