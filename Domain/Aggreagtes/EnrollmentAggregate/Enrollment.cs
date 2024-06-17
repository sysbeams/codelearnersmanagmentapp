using Domain.Aggreagtes.CourseAggregate;
using Domain.Aggreagtes.StudentAggregate;
using Domain.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggreagtes.EnrollmentAggregate;

    public class Enrollment : AuditableEntity, IAggregateRoot
    {
        public Guid StudentId { get; private set; }
        public virtual Student Student { get; private set; } = default!;
        public Guid CourseId { get; private set; }
        public virtual Course Course { get; private set; } = default!;
        public bool IsActive { get; private set; }
        public DateTime EnrollmentDate { get; private set; }

        internal Enrollment(Student student, Course course)
        {
            StudentId = student.Id;
            Student = student;
            CourseId = course.Id;
            Course = course;
            IsActive = true;
            EnrollmentDate = DateTime.UtcNow;
        }

        public void Complete()
        {
            if (!IsActive)
                throw new InvalidOperationException("The enrollment is already completed.");
            IsActive = false;
        }
    }

