using Domain.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggreagtes.ClassAggregate
{
    public class Assignment : AuditableEntity<Guid>
    {
        public Guid CourseId { get; private set; } = default!;
        public Guid BatchId { get; private set; } = default!;
        public Class Class { get; private set; } 
        public DateTime SubmissionDate { get; private set; } = default!;
        public decimal Grade { get; private set; } = default!;
        public string Content { get; private set; }

        #region Constructor
        private Assignment () { }
        public Assignment(int courseId, int batchId, DateTime submissionDate, decimal grade, string content)
        {
            CourseId = courseId;
            BatchId = batchId;
            SubmissionDate = submissionDate;
            Grade = grade;
            Content = content;
        }
        #endregion

        #region behaviour
        public void AddClass (DateTime scheduledDateTime, int duration, string topic, int staffId) 
        {
            Class = new Class(scheduledDateTime, duration, topic, staffId);
        }
        #endregion
    }
}
