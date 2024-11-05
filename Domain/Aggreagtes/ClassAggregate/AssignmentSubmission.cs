using Domain.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggreagtes.ClassAggregate
{
    public class AssignmentSubmission : AuditableEntity<Guid>
    {
        public Guid StudentId { get; private set; }
        public Guid AssignmentId { get; private set; }
        public string Link { get; private set; }
        public decimal Grade { get; private set; }
        public string Content { get; private set; }

        #region Constructor
        public AssignmentSubmission(Guid studentId, Guid assignmentId, decimal grade, string? link = null, string? content = null)
        {
            if (string.IsNullOrEmpty(link) && string.IsNullOrEmpty(content))
            {
                throw new ArgumentException("A submission must have either a link or content set.");
            }
            StudentId = studentId;
            AssignmentId = assignmentId;
            Grade = grade;
            Link = link;
            Content = content;
        }
        #endregion
    }
}
