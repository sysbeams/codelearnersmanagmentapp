using Domain.Aggreagtes.ApplicantAggregate;
using Domain.Aggreagtes.StudentAggregate;
using Domain.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggreagtes.UserAggregate
{
    public class User : AuditableEntity, IAggregateRoot
    {
        public string UserName { get; private set; }
        public string EmailAddress { get; private set; } = default!;
        public string PasswordHash { get; private set; }
        public string PasswordSalt { get; private set; }   

        internal User(string userName, string emailAddress,string passwordHash, string passwordSalt) 
        {
            UserName = userName;
            EmailAddress = emailAddress;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
        }

    }
}
