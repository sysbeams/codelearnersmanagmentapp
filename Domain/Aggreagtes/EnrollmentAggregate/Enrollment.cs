﻿using Domain.Aggreagtes.CourseAggregate;
using Domain.Aggreagtes.StudentAggregate;
using Domain.Common.Contracts;

namespace Domain.Aggreagtes.EnrollmentAggregate;

public class Enrollment : AuditableEntity, IAggregateRoot
{
    public Guid StudentId { get; private set; } = default!;
    public virtual Student? Student { get; private set; }
    public Guid CourseId { get; private set; } = default!;
    public virtual Course? Course { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime EnrollmentDate { get; private set; }

    #region Constructor
    private Enrollment() { }
    internal Enrollment(Student student, Course course)
    {
        StudentId = student.Id;
        Student = student;
        CourseId = course.Id;
        Course = course;
        IsActive = true;
        EnrollmentDate = DateTime.UtcNow;
    }
    #endregion

    #region Behaviour
    public void Complete()
    {
        if (!IsActive)
            throw new InvalidOperationException("The enrollment is already completed.");
        IsActive = false;
    }
     #endregion
}

