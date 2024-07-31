using Domain.Aggreagtes.CourseAggregate;
using Domain.Aggreagtes.EnrollmentAggregate;
using Domain.Aggreagtes.StudentAggregate;
using Domain.Aggreagtes.UserAggregate;
using Domain.Common.Contracts;
using Domain.Exceptions;

namespace Domain.Aggreagtes.StaffAggregate
{
    public class Staff : AuditableEntity, IAggregateRoot
    {
        public string Firstname { get; private set; } = default!;
        public string Lastname { get; private set; } = default!;
        public string EmailAddress { get; private set; }
        public string Phonenumber { get; private set; } = default!;
        public Guid? UserId { get; private set; } = default!;
        public virtual User? User { get; private set; }
        public string Fullname => $"{Firstname}{Lastname}";
        public Address? Address { get; private set; }
        public ICollection<Course> Courses { get; private set; } = new HashSet<Course>();

        internal Staff(string firstname, string lastname, string emailAddress, string phonenumber)
        {
            Firstname = firstname;
            Lastname = lastname;
            EmailAddress = emailAddress;
            Phonenumber = phonenumber;
        }

        public void AddAddress(string street, string city, string state, string country)
        {
            if (Address != null)
                throw new InvalidAddressUpdateException($"The staff {Fullname} has address. Try update");
            Address = new Address(street, city, state, country);
        }
    }
}
