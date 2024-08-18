using Domain.Aggreagtes.ApplicantAggregate;
using Domain.Aggreagtes.CourseAssessmentAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ICourseAssessmentRepository
    {
        Task<CourseAssessment> CreateCourseAssessment(CourseAssessment courseAssessment);
    }
}
