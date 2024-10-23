using Domain.Common.Contracts;
using Domain.Enums;

namespace Domain.Aggreagtes.CourseAggregate
{
    public class Course : AuditableEntity<Guid>, IAggregateRoot
    {
        public string Name { get; private set; } = default!;
        public string Description { get; private set; } = default!;
        public string CourseInformation { get; private set; } = default!;
        public string? CoverPhotoUrl { get; private set; }
        public int Duration { get; private set; }
        public DurationUnit DurationUnit { get; private set; }

        private readonly List<CourseType> _courseMode = [];
        public IReadOnlyList<CourseType> CourseModes => _courseMode.AsReadOnly();

        #region Constructor
        private Course () { }

        public Course(string name, string description, string courseInformation, string? coverPhotoUrl, int duration, DurationUnit durationUnit)
        {
            Name = name;
            Description = description;
            CourseInformation = courseInformation;
            CoverPhotoUrl = coverPhotoUrl;
            Duration = duration;
            DurationUnit = durationUnit;
        }
        #endregion


        public void AddCourseMode(CourseType mode)
        {
            _courseMode.Add(mode);
        }
    }
}
