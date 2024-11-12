using Domain.Aggreagtes.CourseAggregate;
using Domain.Aggreagtes.UserAggregate;
using Domain.Common.Contracts;
using Domain.Enums;
using Domain.Exceptions;
using Domain.ValueObjects;
using System;
using static System.Net.Mime.MediaTypeNames;



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
    public NextOfKinDetails NextOfKin { get; private set; }
    public Address Address { get; private set; }
    public Guid? UserId { get; private set; } = default!;
    public virtual User? User { get; private set; }
    public IReadOnlyCollection<Application> Applications  => _applications.AsReadOnly();
    public string Fullname => $"{FirstName} {LastName} {MiddleName}";
    private List<Application> _applications = [];


    #region Constructor
    private Applicant() { }
    public Applicant(string firstName, string lastName, string emailAddress, Guid userId)
       
    {
        FirstName = firstName;
        LastName = lastName;
        EmailAddress = emailAddress;
        UserId = userId;
    }
    public Applicant(string firstName, string lastName, string middleName, Gender gender,
        string phonenumber, string emailAddress, Guid userId, int streetNo, string streetName, string city,
         string state, string country, NextOfKinDetails nextOfKin)
    {
        FirstName = !string.IsNullOrWhiteSpace(firstName) ? firstName
            : throw new ArgumentNullOrWhiteSpaceException("First name cannot be null or start with an empty space");
        LastName = !string.IsNullOrWhiteSpace(lastName) ? lastName
            : throw new ArgumentNullOrWhiteSpaceException("Last name cannot be null or start with an empty space");
        MiddleName = !string.IsNullOrWhiteSpace(middleName) ? middleName
            : throw new ArgumentNullOrWhiteSpaceException("Middle name cannot be null or start with an empty space");
        Gender = gender != null ? gender
                 : throw new ArgumentNullOrEmptyException("Gender cannot be empty");
        PhoneNumber = !string.IsNullOrWhiteSpace(phonenumber) ? phonenumber
            : throw new ArgumentNullOrWhiteSpaceException("Phonenumber cannot be null or start with an empty space");
        EmailAddress = !string.IsNullOrWhiteSpace(emailAddress) ? emailAddress
            : throw new ArgumentNullOrWhiteSpaceException("Email address cannot be null or start with an empty space");
        UserId = !(userId == Guid.Empty) ? userId
            : throw new ArgumentNullOrWhiteSpaceException("User id cannot be empty");
        NextOfKin = nextOfKin != null? nextOfKin 
            : throw new ArgumentNullOrWhiteSpaceException("Nextofkin data cannot be empty");
        AddAddress(streetNo, streetName, city, state, country);
    }

    public void AddAddress(int streetNo, string streetName, string city, string state, string country)
    {
        if (Address != null)
            throw new InvalidAddressUpdateException($"The student {Fullname} has address. Try update");
        Address = new Address(streetNo, streetName, city, state, country);
    }

    public void AddApplication(Application application)
    {
        if (application == null)
        {
            throw new ArgumentNullOrEmptyException ("Application cannot be null");
        }

        _applications.Add(application);
    }
    public bool HasAtLeastOneApplication()
    {
        return Applications.Count < 0;
    }

    public void SubmitAssessment(Guid applicationId)
    {
        // Find the application associated with the applicant
        var application = _applications.FirstOrDefault(a => a.Id == applicationId);
        if (application == null)
        {
            throw new ArgumentNullOrEmptyException("Application not found.");
        }

        // Get the assessment associated with the application
        var assessment = application.Assessment;
        if (assessment == null)
        {
            throw new ArgumentNullOrEmptyException("Assessment not found.");
        }
        // Mark the assessment as taken
        assessment.MarkAsTaken();
    }

    public void ChangeStatus(ApplicationStatus status, Guid applicationId)
    {
        // Check if the assessment has been taken
        var application = _applications.FirstOrDefault(a => a.Id == applicationId);
        if (application == null)
        {
            throw new ArgumentNullOrEmptyException("Application not found.");
        }
        if (application.Assessment != null && application.Assessment.AssessmentStatus == AssessmentStatus.Taken)
        {
            if (status == ApplicationStatus.Cancelled)
            {
                throw new ArgumentNullOrEmptyException("An application with an assessment that has been taken cannot be cancelled.");
            }
        }
    }
   
    public void SetResult(Guid applicationId, AssessmentResult status)
    {
        // Find the application associated with the applicant
        var application = _applications.FirstOrDefault(a => a.Id == applicationId);
        if (application == null)
        {
            throw new ArgumentNullOrEmptyException("Application not found.");
        }

        // Check if the assessment has been taken
        var assessment = application.Assessment;
        if (assessment == null || assessment.AssessmentStatus != AssessmentStatus.Taken )
        {
            throw new ArgumentNullOrEmptyException("Cannot set result to pass or fail before the assessment is taken.");
        }

        assessment.SetAssessmentResult(status);
    }

    #endregion
}