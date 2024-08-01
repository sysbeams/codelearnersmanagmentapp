using Domain.Aggreagtes.UserAggregate;
using Domain.Common.Contracts;

namespace Domain.Aggreagtes.ApplicantAggregate;

    public class Applicant : AuditableEntity, IAggregateRoot
    {
        public string LastName { get; private set; } = default!;
        public string FirstName { get; private set; } = default!;
        public string EmailAddress { get; private set; }
        public Guid? UserId { get; private set; } = default!;
        public virtual User? User { get; private set; }
        public string Fullname => $"{FirstName}{LastName}";
        public  Applicant(string firstname, string lastname, string emailAddress)
        {
            FirstName = firstname;
            LastName = lastname;
            EmailAddress = emailAddress;
        }
        
        
    }

