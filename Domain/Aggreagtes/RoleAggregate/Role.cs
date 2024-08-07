using Domain.Aggreagtes.EnrollmentAggregate;
using Domain.Aggreagtes.UserAggregate;
using Domain.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggreagtes.RoleAggregate;

public class Role : AuditableEntity<Guid>, IAggregateRoot
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public ICollection<User> Users { get; private set; } = new HashSet<User>();

    #region Constructor
    private Role() { }

    public Role(string name, string description)
    {
        Name = name;
        Description = description;
    }
    #endregion
}

