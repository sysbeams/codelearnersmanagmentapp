using Domain.Common.Contracts;
using Domain.Enums;

namespace Domain.Aggreagtes.ApplicantAggregate
{
    public class Assessment : AuditableEntity
    {
        public DateTime ScheduledDateTime { get; private set; }
        public AssessmentStatus AssessmentStatus { get; private set; }
        public AssessmentMode AssessmentMode { get; private set; }
        public AssessmentType AssessmentType { get; private set; }  
        public AssessmentResult AssessmentResult { get; private set; }
        public string Remark { get; private set; }

        public Assessment() { }

        public Assessment(DateTime scheduledDateTime, AssessmentStatus assessmentStatus,
            AssessmentMode assessmentMode, AssessmentType assessmentType)
        {
            if (scheduledDateTime < DateTime.Now)
                throw new ArgumentException("Scheduled date and time cannot be in the past.");
            ScheduledDateTime = scheduledDateTime;
            AssessmentStatus = assessmentStatus;
            AssessmentMode = assessmentMode;
            AssessmentType = assessmentType;
            
        }
       /* public void CompleteAssessment(AssessmentResult result, string remark)
        {
            AssessmentResult = result;
            Remark = remark; 
            IsCompleted = true;
            AssessmentStatus = AssessmentStatus.Completed; 
        }*/
        public void MarkAsTaken()
        {
            AssessmentStatus = AssessmentStatus.Taken;
        }

        public void SetAssessmentResult(AssessmentResult assessmentResult)
        {
            AssessmentResult = assessmentResult;
        }
    }
}