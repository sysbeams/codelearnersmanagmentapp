using Domain.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggreagtes.ClassAggregate
{
    public class AssignmentSubmission : AuditableEntity<Guid>, IAggregateRoot
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public Guid StudentId { get; private set; }
        public Guid AssignmentId { get; private set; }
        public string Link { get; private set; }
        public decimal Grade { get; private set; }
        public string Content { get; private set; }

        #region Constructor
        public AssignmentSubmission(Guid studentId, Guid assignmentId, string link, decimal grade, string content)
        {
            StudentId = studentId;
            AssignmentId = assignmentId;
            Link = link ;
            Grade = grade;
            Content = content;
        }
        #endregion
    }
}
