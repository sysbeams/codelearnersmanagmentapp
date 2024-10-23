using Domain.Aggreagtes.StudentAggregate;
using Domain.Common.Contracts;
using static System.Net.Mime.MediaTypeNames;

namespace Domain.Aggreagtes.ApplicantAggregate;

public class Applicant : AuditableEntity, IAggregateRoot
{
    public string LastName { get; private set; } = default!;
    public string FirstName { get; private set; } = default!;
    public string MiddleName { get; private set; } = default!;
    public string EmailAddress { get; private set; } = default!;
    public DateOnly DateOfBirth { get; private set; }
    public string PhoneNumber { get; private set; } = default!;
    public Gender Gender { get; private set; }
    public NextOfKin NextOfKin { get; private set; }
    public Address Address { get; private set; }
    public IReadOnlyCollection<Application> Applications { get; private set; } = new HashSet<Application>();
    public string FullName => $"{FirstName} {LastName} {MiddleName}";

    #region Constructor
    private Applicant() { }

    public Applicant(string firstName, string lastName, string middleName, string emailAddress, DateOnly                         dateOfBirth, string phoneNumber, Gender gender, NextOfKin nextOfKin, Address address)
    {
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
        EmailAddress = emailAddress;
        DateOfBirth = dateOfBirth;
        PhoneNumber = phoneNumber;
        Gender = gender;
        NextOfKin = nextOfKin;
        Address = address;
    }
    #endregion

}

