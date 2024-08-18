using Application.Contracts.Services;
using Application.Dtos;
using Application.Exceptions;
using Domain.Aggreagtes.CourseAssessmentAggregate;
using Domain.Enums;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CourseAssessmentService
        (
         ICourseRepository courseRepository,
         ICourseAssessmentRepository courseAssessmentRepository,
         IUnitOfWork unitOfWork
        )
        : ICourseAssessmentService
    {
        public async Task<BaseResponse> AddNewCourseAssessment
            (CreateCourseAssessmentRequest request)
        {
            var courseObjectRetrieved = await courseRepository.GetByIdAsync(request.CourseId);

            if (courseObjectRetrieved is null) throw new 
                NotFoundException($"Course With this id: {request.CourseId} Did Not Exit");

            var courseAssessment = CourseAssessment.NewCourseAssessment
                (
                request.CourseId,
                request.AssessmentDate,
                new List<AssessmentMode>
                {
                 AssessmentMode.Hybrid,
                 AssessmentMode.Virtual,
                 AssessmentMode.Onsite
                }
                );

            await courseAssessmentRepository.CreateCourseAssessment(courseAssessment);
            await unitOfWork.SaveChangesAsync();

            return new CourseAssessmentResponse(
                courseAssessment.AssessmentDate,
                "New assessment date created successfully",
                courseAssessment.CourseId,
                true
                );
        }
    }
}
