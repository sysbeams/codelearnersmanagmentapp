using Domain.Aggreagtes.CourseAggregate;
using Domain.Common.Contracts;

namespace Domain.Aggreagtes.ApplicantAggregate
{
    public class Application : AuditableEntity
    {
        public Guid BatchId { get; private set; }
        public Guid CourseId { get; private set; }
        public Applicant Applicant { get; private set; }
        public Assessment Assessment { get; private set; }
        public CourseMode CourseMode { get; private set; }
        public ApplicationStatus ApplicationStatus { get; private set; }

        public Application(Applicant applicant, Guid batchId, Guid courseId, Assessment assessment, CourseMode courseMode, ApplicationStatus applicationStatus)
        {
            Applicant = applicant;
            BatchId = batchId;
            CourseId = courseId;
            Assessment = assessment;
            CourseMode = courseMode;
            ApplicationStatus = applicationStatus;
        }
    }
}