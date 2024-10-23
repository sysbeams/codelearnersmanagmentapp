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
        private readonly List<CourseModeDetails> _courseMode = [];
        public IReadOnlyList<CourseModeDetails> CourseModes => _courseMode.AsReadOnly();

        #region Constructor
        private Course () { }

        public Course(string name, string description, string courseInformation, string? coverPhotoUrl, int duration)
        {
            Name = name;
            Description = description;
            CourseInformation = courseInformation;
            CoverPhotoUrl = coverPhotoUrl;
            Duration = duration;
        }
        #endregion


        public void AddCourseMode(CourseModeDetails mode)
        {
            _courseMode.Add(mode);
        }
    }
}
