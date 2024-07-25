using Domain.Aggreagtes.UserAggregate;
using Domain.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggreagtes.AdminAggregate
{
    public class Admin : AuditableEntity, IAggregateRoot
    {
        public string Lastname { get; private set; } = default!;
        public string Firstname { get; private set; } = default!;
        public string EmailAddress { get; private set; }
        public Guid? UserId { get; private set; } = default!;
        public virtual User? User { get; private set; }
        public string Fullname => $"{Firstname}{Lastname}";

        internal Admin(string firstname, string lastname, string emailAddress)
        {
            Firstname = firstname;
            Lastname = lastname;
            EmailAddress = emailAddress;
        }
    }
}
