using Domain.Common.Contracts;
using Domain.Enums;
using Domain.Exceptions;
using Domain.Paging;

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
        public IReadOnlyList<CourseType> CourseModes => _courseMode.AsReadOnly();
        public IReadOnlyList<CourseBatch> Batches => _batches.AsReadOnly();
        public Curriculum Curriculum { get; private set; }
        private List<CourseBatch> _batches = new List<CourseBatch> { };
        private readonly List<CourseType> _courseMode = [];

        #region Constructor
        private Course () { }

        public Course(string name, CourseBatch batches, string topicname, string exercisename,
            string exerciselink, string exercisecontent)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullOrEmptyException("Course name cannot be null or empty");
           /* ValidateCourseBatch(batches);*/
            AddBatch(batches);
            AddAndValidateCurriculum(topicname, exercisename, exerciselink, exercisecontent);
            Name = name;

        }
        #endregion
       

        /*private void ValidateCourseBatch(CourseBatch batch)

        {
            if (batch == null)
            {
                throw new ArgumentNullOrEmptyException("Batch cannot be empty");
            }
        }*/
        public void AddBatch(CourseBatch batch)
        {
            if (batch == null)
            {
                throw new ArgumentNullOrEmptyException("Batch cannot be null");
            }
            _batches.Add(batch);
            batch.SetCourse(this);
        }
        public void AddAndValidateCurriculum(string topicname, string exercisename, 
            string exerciselink, string exercisecontent)
        {
            if (Curriculum != null) throw new ArgumentNullOrEmptyException("Course belongs to a Curriculum");
            Curriculum = new Curriculum(this.Id, topicname, exercisename, exerciselink, exercisecontent);
        }

        public Course(string name, string description, string courseInformation, 
            string? coverPhotoUrl, int duration, DurationUnit unit)
        {
            Name = name;
            Description = description;
            CourseInformation = courseInformation;
            CoverPhotoUrl = coverPhotoUrl;
            Duration = duration;
            DurationUnit = unit;
        }

        public void AddCourseMode(CourseType mode)
        {
            _courseMode.Add(mode);
        }
    }
}
