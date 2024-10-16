using Domain.Common.Contracts;
using Domain.Enums;
using Domain.Paging;

namespace Domain.Aggreagtes.CourseAggregate
{
    public class Course : AuditableEntity<Guid>, IAggregateRoot
    {
        public string Name { get; private set; } = default!;
        public IEnumerable<CourseBatch> Batches { get; private set; } = new Hashset<CourseBatch> ();
        public Curriculum Curriculum { get; private set; }
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
