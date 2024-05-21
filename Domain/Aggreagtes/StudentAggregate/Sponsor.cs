using Domain.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggreagtes.StudentAggregate
{
    public class Sponsor : AuditableEntity<Guid>
    {
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string? Email { get; set; }   

        internal Sponsor(string name, string phone) {
            Name = name;
            PhoneNumber = phone;
        }
    }
}
