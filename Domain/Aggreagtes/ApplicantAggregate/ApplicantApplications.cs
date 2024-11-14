using Domain.Aggreagtes.ApplicantAggregate;
using Domain.Aggreagtes.CourseAggregate;
using Domain.Common.Contracts;
using Domain.Enums;
using Domain.Exceptions;
using System.Linq;

namespace Domain.Aggreagtes.ApplicantAggregate
{
    public class ApplicantApplications : AuditableEntity
    {
        public Guid BatchId { get; private set; }
        public Guid CourseId { get; private set; }
        public CourseMode CourseMode { get; private set; }
        public ApplicationStatus ApplicationStatus { get; private set; }
        public Applicant Applicant { get; private set; }
        public Assessment Assessment { get; private set; }
        public ApplicantApplications() { }

        public ApplicantApplications(Guid batchId, Guid courseId, CourseMode courseMode, 
            Applicant applicant, Assessment assessment)
        {
            BatchId = batchId != Guid.Empty ? batchId
                 : throw new ArgumentNullOrEmptyException("Batch id must be provided"); 
            CourseId = courseId != Guid.Empty ? courseId
                 : throw new ArgumentNullOrEmptyException("Course id cannot be empty"); 
            CourseMode = (courseMode != default(CourseMode)) ? courseMode
                 : throw new ArgumentNullOrEmptyException("Course mode cannot be empty");
            ApplicationStatus = ApplicationStatus.New;
            //we are checking if the applicant list is having an application
            if (!applicant.HasAtLeastOneApplication())
            {
                //lets add this application to applicants list
                applicant.AddApplication(this);
            }
            
            Applicant = applicant;
            Assessment = assessment != null ? assessment
                 : throw new ArgumentNullOrEmptyException("Assessment cannot be null");
        }

        
    }
}