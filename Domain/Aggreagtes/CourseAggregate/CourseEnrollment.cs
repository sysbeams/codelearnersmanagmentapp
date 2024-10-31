using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Aggreagtes.ApplicantAggregate;
using Domain.Common.Contracts;

namespace Domain.Aggreagtes.CourseAggregate
{
    public class CourseEnrollment : AuditableEntity<Guid>
    {
        public Guid BatchId { get; private set; }
        public IEnumerable<Applicant> Applicants { get; private set; } = new HashSet<Applicant>();

        public DateTime DateEnrolled { get; private set; }

        public CourseEnrollment(Guid batchid, DateTime dateenrolled)
        {
            BatchId = batchid;
            DateEnrolled = dateenrolled;
        }
    }
    
}
