using Application.Exceptions;
using Domain.Aggreagtes.CourseAggregate;
using Domain.Enums;
using Domain.Repositories;
using MediatR;

namespace Application.Commands;

public class UpdateCourse
{
    public class UpdateCourseCommand : IRequest<UpdateCourseResponse>
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = default!;
        public string? CoverPhotoUrl { get; init; }
        public string Description { get; init; } = default!;
        public int Duration { get; init; }
        public DurationUnit DurationUnit { get; init; }
        public List<UpdateCourseModeDto> CourseModes { get; set; } = null!;
    }

    public class UpdateCourseModeDto
    {
        public Guid CourseModeId { get; set; }
        public decimal Price { get; set; }
    }

    public record UpdateCourseResponse(Guid Id, string Name, string Description, string CourseInformation, string? CoverPhotoUrl, int Duration, DurationUnit DurationUnit, List<CourseMode> CourseModes);


    public class Handler : IRequestHandler<UpdateCourseCommand, UpdateCourseResponse>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public Handler(ICourseRepository courseRepository, IUnitOfWork unitOfWork)
        {
            _courseRepository = courseRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdateCourseResponse> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            
            var course = await _courseRepository.GetByIdAsync(request.Id);
            if (course == null)
            {
                throw new NotFoundException($"Course with ID {request.Id} not found.");
            }


            course.UpdateCourse(request.Name, request.Description,  request.CoverPhotoUrl, request.Duration, request.DurationUnit);


            foreach (var modeUpdate in request.CourseModes)
            {
                course.UpdateCourseModePrice(modeUpdate.CourseModeId, modeUpdate.Price);
            }

            await _courseRepository.UpdateAsync(course);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new UpdateCourseResponse(
                course.Id,
                course.Name,
                course.Description,
                course.CourseInformation,
                course.CoverPhotoUrl,
                course.Duration,
                course.DurationUnit,
                course.CourseModes.ToList()
            );
        }
    }


}

