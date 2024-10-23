using Domain.Aggreagtes.CourseAggregate;
using Domain.Common.Contracts;
using Domain.Enums;

namespace Domain.Aggreagtes.ApplicantAggregate;

public class ApplicantEnrollment : AuditableEntity<Guid>, IAggregateRoot
{
    public Guid ApplicantId { get; private set; }
    public virtual Applicant Applicant { get; private set; }
    public Guid CourseId { get; private set; }
    public virtual Course Course { get; private set; }
    public DateTime SubscriptionDate { get; private set; }
    public CourseType CourseType { get; private set; }
    public AssessmentMode AssessmentMode { get; private set; }
    public Guid CourseAssessmentId { get; private set; }   
    public bool passed { get; private set; }

    #region Constructor

    private ApplicantEnrollment() 
    {
        Applicant = default!;
        Course = default!;
    }
     public ApplicantEnrollment(Guid applicantId, Applicant applicant, Guid courseId, Course course,
        DateTime subscriptionDate, CourseType courseType, 
        AssessmentMode assessmentMode, Guid courseAssessmentId, bool passed)
    {
        ApplicantId = applicantId;
        Applicant = applicant;
        CourseId = courseId;
        Course = course;
        SubscriptionDate = subscriptionDate;
        CourseType = courseType;
        AssessmentMode = assessmentMode;
        CourseAssessmentId = courseAssessmentId;
        this.passed = passed;
    }
    #endregion
}


