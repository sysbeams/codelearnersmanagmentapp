using Domain.Common.Contracts;
using Domain.Enums;

namespace Domain.Aggreagtes.StudentAggregate
{
    public class Student : AuditableEntity, IAggregateRoot
    {
        public string Lastname { get; private set; } = default!;
        public string Firstname { get; private set; } = default!;
        public Sponsor? Sponsor { get; private set; } = default!;
        public string PhoneNumber { get; private set; }
        public string EmailAddress { get; private set; }
        public DateOnly? DateOfBirth { get; private set; }
        public Address? Address { get; private set; }
        public EducationLevel? Education { get; private set; }

        public string Fullname => $"{Firstname}{Lastname}";
        public Student(string firstname, string lastname, string phoneNumber, string emailAddress)
        {
            Firstname = firstname;
            Lastname = lastname;
            PhoneNumber = phoneNumber;
            EmailAddress = emailAddress;
        }
    }
}
