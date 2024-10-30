using Domain.Aggreagtes.UserAggregate;
using Domain.Common.Contracts;
using Domain.Enums;
using Domain.ValueObjects;
using System.Reflection;

namespace Domain.Aggreagtes.ApplicantAggregate;

public class Applicant : AuditableEntity, IAggregateRoot
{
    public string FirstName { get; private set; } = default!;
    public string LastName { get; private set; } = default!;
    public string MiddleName { get; private set; } = default!;
    public string EmailAddress { get; private set; } = default!;
    public string PhoneNumber { get; private set; }
    public DateOnly DateOfBirth { get; private set; }
    public Gender Gender { get; private set; }
    public NextOfKin NextOfKin { get; private set; }
    public Address Address { get; private set; }
    public Guid? UserId { get; private set; } = default!;
    public virtual User? User { get; private set; }
    public IReadOnlyCollection<Application> Applications { get; private set; } = new HashSet<Application>();
    public string Fullname => $"{FirstName} {LastName} {MiddleName}";

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