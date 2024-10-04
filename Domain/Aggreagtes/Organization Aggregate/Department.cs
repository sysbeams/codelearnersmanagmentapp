using Domain.Aggreagtes.StaffAggregate;
using Domain.Common.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggreagtes.Organization_Aggregate
{
    public class Department : AuditableEntity<Guid>
    {
        public required string Name { get; set; } 
        public required Organization Organization { get; set; }
        public required  Guid StaffHodId  { get; set; }
    }
}
