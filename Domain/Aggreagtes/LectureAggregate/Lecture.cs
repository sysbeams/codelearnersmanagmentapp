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
        public string Topic { get; set; }
        public string Description { get; set; }
        public DateTime TimeDuration {get; set; }
        public string CourseId { get; set; }
        public virtual Course Course { get; set; }
        public Lecture(string topic, string description, DateTime timeDuration, string courseId, Course course)
        {
            Topic = topic;
            Description = description;
            TimeDuration = timeDuration;
            CourseId = courseId;
            Course = course;
        }
    }
