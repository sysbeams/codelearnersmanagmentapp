using Domain.Aggreagtes.CourseAggregate;
using Domain.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggreagtes.LectureAggregate;
public class Lecture : AuditableEntity<Guid>, IAggregateRoot
{
    public string Topic { get; set; } = default!;
    public string Description { get; set; } = default!;
    public DateTime TimeDuration { get; set; }
    public string CourseId { get; set; } = default!;
    public virtual Course? Course { get; set; }

    #region Constructor
    public Lecture() { }

    public Lecture(string topic, string description, DateTime timeDuration, string courseId, Course course)
    {
        Topic = topic;
        Description = description;
        TimeDuration = timeDuration;
        CourseId = courseId;
        Course = course;
    }
    #endregion
}
