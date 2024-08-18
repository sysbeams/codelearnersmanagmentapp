using Domain.Common.Contracts;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggreagtes.CourseAssessmentAggregate
{
    public class CourseAssessment: AuditableEntity<Guid>, IAggregateRoot
    {
        public Guid CourseId { get; private set; }
        public DateTime AssessmentDate { get; private set; }
        public List<AssessmentMode> AssessmentMode { get; private set; } = [];


        private CourseAssessment(
            Guid courseId,
            DateTime assessmentDate,
            List<AssessmentMode> assessmentMode)
        {
            CourseId = courseId;
            AssessmentDate = assessmentDate;
            AssessmentMode = assessmentMode ?? new List<AssessmentMode>();
        }

        public static CourseAssessment NewCourseAssessment(
            Guid courseId,
            DateTime assessmentDate,
            List<AssessmentMode> assessmentMode)
        {
            if (courseId == Guid.Empty)
            
               throw new ArgumentNullException(nameof(courseId), "Course ID cannot be empty");

            /*if (assessmentDate < DateTime.)
            
                throw new ApplicationException("Assessment date must precedes the current date ");*/
            
            if (assessmentMode == null || Enum.GetValues(typeof(AssessmentMode)).Cast<AssessmentMode>().Intersect(assessmentMode).Count() == 0)
            
                throw new ArgumentNullException(nameof(assessmentMode), "Assessment mode cannot be empty");
            
            
            return new CourseAssessment(courseId, assessmentDate, assessmentMode);

        }

    }
}
