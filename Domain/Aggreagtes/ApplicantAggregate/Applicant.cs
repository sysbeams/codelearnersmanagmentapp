using Domain.Aggreagtes.StudentAggregate;
using Domain.Common.Contracts;

namespace Domain.Aggreagtes.ApplicantAggregate;

public class Applicant : AuditableEntity, IAggregateRoot
{
    public string FirstName { get; private set; } = default!;
    public string LastName { get; private set; } = default!;
    public string MiddleName { get; private set; } = default!;
    public string EmailAddress { get; private set; } = default!;
    public string PhoneNumber { get; private set; }
    public DateOnly? DateOfBirth { get; private set; }
    public Gender Gender { get; private set; } = default!;
    public NextOfKin NextOfKin { get; private set; } 
    public Address Address { get; private set; } = default!;
    public ICollection<Application> Applications = new HashSet<Application>();

    #region Constructor
    private Applicant() { }

    public Applicant(string firstName, string lastName, string middleName, string emailAddress, string phoneNumber, DateOnly dateOfBirth, Gender gender, NextOfKin nextOfKin, Address address)
    {
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
        EmailAddress = emailAddress;
        PhoneNumber = phoneNumber;
        DateOfBirth = dateOfBirth;
        Gender = gender;
        NextOfKin = nextOfKin;
        Address = address;
    }
    #endregion
}