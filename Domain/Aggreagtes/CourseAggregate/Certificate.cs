using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common.Contracts;

namespace Domain.Aggreagtes.CourseAggregate
{
    public class Certificate : AuditableEntity<Guid>
    {
        public Guid StudentId { get; set; }
        public Guid CourseId {  get; set; }
        public DateTime IssueDate { get; set; }
    }
    public Certificate(Guid studentid, Guid courseid, DateTime issuedate)
    {
        StudentId = studentid;
        CourseId = courseid;
        IssueDate = issuedate;
    }
}
