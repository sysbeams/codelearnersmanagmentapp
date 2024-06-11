using Domain.Aggreagtes.ApplicantAggregate;
using Domain.Aggreagtes.CourseAggregate;
using Domain.Aggreagtes.UserAggregate;
using Domain.Common.Contracts;
using Domain.Enums;
using Domain.Exceptions;

namespace Domain.Aggreagtes.StudentAggregate
{
    public class Student : AuditableEntity, IAggregateRoot
    {
        public string StudentNumber { get; private set; }
        public string Lastname { get; private set; } = default!;
        public string Firstname { get; private set; } = default!;
        public Sponsor? Sponsor { get; private set; } = default!;
        public string PhoneNumber { get; private set; }
        public string EmailAddress { get; private set; }
        public DateOnly? DateOfBirth { get; private set; }
        public Address? Address { get; private set; }
        public EducationLevel? Education { get; private set; }
        public Guid? CourseId { get; private set; }
        public virtual Course? Course { get; private set; }
        public Guid UserId { get; private set; } = default!;
        public virtual User User { get; private set; }

        public string Fullname => $"{Firstname}{Lastname}";
        internal Student(string studentNumber, string firstname, string lastname, string phoneNumber, string emailAddress,DateOnly dateOfBirth)
        {
            StudentNumber = studentNumber;
            Firstname = firstname;
            Lastname = lastname;
            PhoneNumber = phoneNumber;
            EmailAddress = emailAddress;
            DateOfBirth = dateOfBirth;
        }

        public void AddAddress(string street, string city, string state, string country) {
            if (Address != null)
                throw new InvalidAddressUpdateException($"The student {Fullname} has address. Try update");
            Address =  new Address(street, city, state, country);
        }
    }
}
