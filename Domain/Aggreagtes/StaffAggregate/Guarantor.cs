using Domain.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggreagtes.StaffAggregate
{
    public class Guarantor : AuditableEntity
    {
        public string FullName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public Address Address { get; set; } = default!;
        public string CurrentEmployment { get; set; } = default!;
        public string Position { get; set; } = default!;
    }
   
}
