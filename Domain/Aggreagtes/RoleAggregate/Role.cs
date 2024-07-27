using Domain.Aggreagtes.EnrollmentAggregate;
using Domain.Aggreagtes.UserAggregate;
using Domain.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggreagtes.RoleAggregate
{
    public class Role : AuditableEntity<Guid>, IAggregateRoot
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<User> Enrollments { get; private set; } = new HashSet<User>();
        public Role(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
