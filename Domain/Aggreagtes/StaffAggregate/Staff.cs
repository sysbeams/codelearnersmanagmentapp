using Domain.Aggreagtes.CourseAggregate;
using Domain.Aggreagtes.EnrollmentAggregate;
using Domain.Aggreagtes.StudentAggregate;
using Domain.Aggreagtes.UserAggregate;
using Domain.Common.Contracts;
using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggreagtes.StaffAggregate
{
    public class Staff : AuditableEntity , IAggregateRoot
    {
        public string StaffNumber { get; private set; }
        public string Lastname { get; private set; } = default!;
        public string Firstname { get; private set; } = default!;
        public string PhoneNumber { get; private set; }
        public string EmailAddress { get; private set; }
        public DateOnly? DateOfBirth { get; private set; }
        public Address? Address { get; private set; }
        public ICollection<Enrollment> Enrollments { get; private set; } = new HashSet<Enrollment>();
        public ICollection<Course> Courses { get; private set; } = new HashSet<Course>();
        public Guid? UserId { get; private set; } = default!;
        public virtual User? User { get; private set; }

        public string Fullname => $"{Firstname}{Lastname}";
        internal Staff(string staffNumber, string firstname, string lastname, string phoneNumber, string emailAddress)
        {
            StaffNumber = staffNumber;
            Firstname = firstname;
            Lastname = lastname;
            PhoneNumber = phoneNumber;
            EmailAddress = emailAddress;

        }
        public void AddAddress(string street, string city, string state, string country)
        {
            if (Address != null)
                throw new InvalidAddressUpdateException($"The staff {Fullname} has address. Try update");
            Address = new Address(street, city, state, country);
        }
       
    }
}
