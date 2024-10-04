using Domain.Common.Contracts;
using Domain.Enums;
using Domain.Paging;

namespace Domain.Aggreagtes.CourseAggregate
{
    public class Course : AuditableEntity<Guid>, IAggregateRoot
    {
        public string Name { get; private set; } = default!;
        public List<Batch> Batches { get; set; } = new List<Batch> ();
        public List<Topic> Topics { get; set; } = new List<Topic> ();
        public Curriculum Curriculum { get; set; }
        //public string Description { get; private set; } = default!;
        //public string CourseInformation { get; private set; } = default!;
        //public string? CoverPhotoUrl { get; private set; }
        //public int Duration { get; private set; }
        //public DurationUnit DurationUnit { get; private set; }
        //private readonly List<CourseMode> _courseMode = [];
        //public IReadOnlyList<CourseMode> CourseModes => _courseMode.AsReadOnly();

        #region Constructor
        private Course () { }

        public Course(string name)
        {
            Name = name;
        }
        #endregion


        public void AddCourseMode(CourseMode mode)
        {
            _courseMode.Add(mode);
        }
    }
}
