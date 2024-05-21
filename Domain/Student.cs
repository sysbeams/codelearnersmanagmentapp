using Domain.Common.Contracts;
using Domain.Enums;

namespace Domain
{ 
    public class Student : AuditableEntity, IAggregateRoot
    {
        public string FullName { get; private set; } = default!;
        public string Sponsor { get; private set; } = default!;
        public string PhoneNumber { get; private set; } = default!;
        public string Password { get; private set; } = default!;
        public string Age { get; private set; } = default!;
        public Address Address { get; private set; } = default!;
        public EducationLevel Education { get; private set; } = default!;
        public string EmailAddress { get; private set; } = default!;

        public Student(string fullName, string sponsor, string phoneNumber, string password, string age, EducationLevel education, string emailAddress)
        {
            FullName = fullName;
            Sponsor = sponsor;
            PhoneNumber = phoneNumber;
            Password = password;
            Age = age;
            Education = education;
            EmailAddress = emailAddress;
        }
    }
}
