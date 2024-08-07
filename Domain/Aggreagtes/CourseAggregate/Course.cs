using Domain.Aggreagtes.ApplicantAggregate;
using Domain.Aggreagtes.EnrollmentAggregate;
using Domain.Aggreagtes.LectureAggregate;
using Domain.Common.Contracts;

namespace Domain.Aggreagtes.CourseAggregate
{
    public class Course : AuditableEntity<Guid>, IAggregateRoot
    {
        public string Name { get; private set; } = default!;
        public string Level { get; private set; } = default!;
        public decimal Price { get; private set; }
        public string Description { get; private set; } = default!;
        public string CoverPhotoUrl { get; private set; } = default!;
        public ICollection<Lecture>? Lectures { get; private set; }
        public ICollection<Enrollment>? Enrolled { get; private set; }
        public ICollection<ApplicantEnrollment>? applicantEnrollments { get; private set; }
        public string Duration { get; private set; } = default!;

        #region Constructor
        private Course () { }

        internal Course(string name, string level, decimal price, string description, string coverPhotoUrl,string duration)
        {
            Name = name;
            Level = level;
            Price = price;
            Description = description;
            CoverPhotoUrl = coverPhotoUrl;
            Duration = duration;
        }
        #endregion
    }
}
