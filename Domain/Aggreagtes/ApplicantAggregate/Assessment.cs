using Domain.Common.Contracts;
using Domain.Enums;

namespace Domain.Aggreagtes.ApplicantAggregate
{
    public class Assessment : AuditableEntity
    {
        public DateTime ScheduledDateTime { get; private set; }
        public string Remark { get; private set; }
        public AssessmentStatus AssessmentStatus { get; private set; }
        public AssessmentMode AssessmentMode { get; private set; }
        public AssessmentType AssessmentType { get; private set; }
        public AssessmentResult AssessmentResult { get; private set; }


        public Assessment() { }

        public Assessment(DateTime scheduledDateTime, string remark, AssessmentStatus assessmentStatus, AssessmentMode assessmentMode, AssessmentType assessmentType, AssessmentResult assessmentResult)
        {
            ScheduledDateTime = scheduledDateTime;
            Remark = remark;
            AssessmentStatus = assessmentStatus;
            AssessmentMode = assessmentMode;
            AssessmentType = assessmentType;
            AssessmentResult = assessmentResult;
        }
    }
}
