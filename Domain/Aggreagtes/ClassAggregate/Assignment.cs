using Domain.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggreagtes.ClassAggregate
{
    public class Assignment : AuditableEntity<Guid>, IAggregateRoot
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public int CourseId { get; private set; } = default!;
        public int BatchId { get; private set; } = default!;
        public Class Class { get; private set; } 
        public DateTime SubmissionDate { get; private set; } = default!;
        public decimal Grade { get; private set; } = default!;

        #region Constructor
        private Assignment () { }
        public Assignment(int courseId, int batchId, Class classEntity, DateTime submissionDate, decimal grade)
        {
            CourseId = courseId;
            BatchId = batchId;
            Class = classEntity;
            SubmissionDate = submissionDate;
            Grade = grade;
        }
        #endregion
    }
}
