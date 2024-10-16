using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Aggreagtes.ApplicantAggregate;
using Domain.Common.Contracts;

namespace Domain.Aggreagtes.CourseAggregate
{
    public class Enrollment : AuditableEntity<Guid>
    {
        public Guid BatchId { get; private set; }
        public IEnumerable<Applicant> Applicants { get; private set; } = new Hashset<Applicant>();
        public DateTime DateEnrolled { get; private set; }
    }
    public Enrollment(Guid batchid, DateTime dateenrolled)
    {
        BatchId = batchid;
        DateEnrolled = dateenrolled;
    }
}
