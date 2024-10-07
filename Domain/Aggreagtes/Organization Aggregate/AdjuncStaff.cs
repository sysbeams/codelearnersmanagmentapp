using Domain.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggreagtes.Organization_Aggregate
{
    public class AdjuncStaff : AuditableEntity<Guid>
    {
        public required Guid StaffId { get; set; } 
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Duration { get; set; } = default!;
        public required string Department  { get; set; }

    }
}
