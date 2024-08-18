using Application.Dtos;
using Application.Exceptions;
using Domain.Aggreagtes.CourseAssessmentAggregate;
using Domain.Enums;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class CreateCourseAssessmentCommand : IRequest<CourseAssessmentResponseModel>
    {
        public Guid CourseId { get; init; } = default!;
        public DateTime AssessmentDate { get; init; } = default!;
    }

    public record CourseAssessmentResponseModel
        (Guid Id,  
        string Message, 
        bool IsSuccessful)
        :BaseResponse(Message, IsSuccessful);


    public class CreateCourseAssessmentCommandHandler
        (ICourseRepository courseRepository,
         ICourseAssessmentRepository courseAssessmentRepository,
         IUnitOfWork unitOfWork)
        : IRequestHandler<CreateCourseAssessmentCommand, CourseAssessmentResponseModel>
    {
        public async Task<CourseAssessmentResponseModel> Handle(CreateCourseAssessmentCommand request, CancellationToken cancellationToken)
        {
            var courseObjectRetrieved = await courseRepository.GetByIdAsync(request.CourseId);

            if (courseObjectRetrieved is null) throw new
                NotFoundException($"Course With this id: {request.CourseId} Did Not Exit");

            var courseAssessment = CourseAssessment.NewCourseAssessment
                (
                courseObjectRetrieved.Id,
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

            return new CourseAssessmentResponseModel(
                courseAssessment.Id,
                "New assessment date created successfully",
                true
                );
        }
    }
}
