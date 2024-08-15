using Domain.Common.Contracts;
using Domain.Enums;
using Domain.Exceptions;

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

        private readonly List<CourseMode> _courseMode = new();
        public IReadOnlyList<CourseMode> CourseModes => _courseMode.AsReadOnly();

        #region Constructor
        private Course() { }

        public Course(string name, string description, string courseInformation, string? coverPhotoUrl, int duration, DurationUnit unit)
        {
            Name = name;
            Description = description;
            CourseInformation = courseInformation;
            CoverPhotoUrl = coverPhotoUrl;
            Duration = duration;
            DurationUnit = unit;
        }
        #endregion

        public void UpdateCourse(string name, string description, string? coverPhotoUrl, int duration, DurationUnit durationUnit)
        {
            Name = name;
            Description = description;
            CoverPhotoUrl = coverPhotoUrl;
            Duration = duration;
            DurationUnit = durationUnit;
        }


        public void UpdateCourseModePrice(Guid courseModeId, decimal newPrice)
        {
            var courseMode = _courseMode.FirstOrDefault(cm => cm.Id == courseModeId);
            if (courseMode != null)
            {
                courseMode.UpdatePrice(newPrice);
            }
        }


        public void AddCourseMode(CourseMode mode)
        {
            _courseMode.Add(mode);
        }
    }
}






