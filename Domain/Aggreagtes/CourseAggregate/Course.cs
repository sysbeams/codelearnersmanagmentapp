using Domain.Common.Contracts;
using Domain.Enums;
using Domain.Paging;

namespace Domain.Aggreagtes.CourseAggregate
{
    public class Course : AuditableEntity<Guid>, IAggregateRoot
    {
        public string Name { get; private set; } = default!;
        public IEnumerable<CourseBatch> Batches { get; set; } = new List<CourseBatch> ();
        public Curriculum Curriculum { get; set; }
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
