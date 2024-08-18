using Domain.Aggreagtes.CourseAggregate;
using Domain.Aggreagtes.CourseAssessmentAggregate;
using Domain.Repositories;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.EfCoreRepository
{
    public class CourseAssessmentRepository
        (ApplicationContext context)
        : ICourseAssessmentRepository
    {
        public async Task<CourseAssessment> CreateCourseAssessment(CourseAssessment courseAssessment)
        {
            await context.CourseAssessments.AddAsync(courseAssessment);
            return courseAssessment;
        }
    }
}
