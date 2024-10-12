using Domain.Aggreagtes.ApplicantAggregate;
using Domain.Aggreagtes.CourseAggregate;
using Domain.Aggreagtes.EnrollmentAggregate;
using Domain.Aggreagtes.UserAggregate;
using Domain.Common.Contracts;
using Domain.Enums;
using Domain.Exceptions;
using Domain.ValueObjects;

namespace Domain.Aggreagtes.StudentAggregate;
public class Student : AuditableEntity, IAggregateRoot
{
    public string StudentNumber { get; private set; } = default!;
    public string Lastname { get; private set; } = default!;
    public string Firstname { get; private set; } = default!;
    public Sponsor? Sponsor { get; private set; } 
    public string? PhoneNumber { get; private set; }
    public string EmailAddress { get; private set; } = default!;
    public DateOnly? DateOfBirth { get; private set; }
    public Address? Address { get; private set; }
    public EducationLevel? Education { get; private set; }
    public ICollection<Enrollment> Enrollments { get; private set; } = new HashSet<Enrollment>();
    public Guid? UserId { get; private set; } = default!;
    public virtual User? User { get; private set; }

    public string Fullname => $"{Firstname}{Lastname}";

    #region Constructor
    private Student() { }
    internal Student(string studentNumber, string firstname, string lastname, string phoneNumber,  string emailAddress)
    {
        StudentNumber = studentNumber;
        Firstname = firstname;
        Lastname = lastname;
        PhoneNumber = phoneNumber;
        EmailAddress = emailAddress;

    }
    #endregion

    #region behaviour
    public void AddAddress(string street, string city, string state, string country)
    {
        if (Address != null)
            throw new InvalidAddressUpdateException($"The student {Fullname} has address. Try update");
        Address = new Address(street, city, state, country);
    }

    public void EnrollInCourse(Course course)
    {
        if (Enrollments.Any(e => e.IsActive))
            throw new InvalidOperationException("The student is already enrolled in an active course.");
        Enrollments.Add(new Enrollment(this, course));
    }

    public void CompleteCourse(Guid courseId)
    {
        var enrollment = Enrollments.FirstOrDefault(e => e.CourseId == courseId && e.IsActive);
        if (enrollment == null)
            throw new InvalidOperationException("The student is not enrolled in this course or the course is not active.");
        enrollment.Complete();
    }
    #endregion
}

