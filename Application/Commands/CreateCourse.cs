using Application.Exceptions;
using Domain.Aggreagtes.CourseAggregate;
using Domain.Enums;
using Domain.Repositories;
using MediatR;

namespace Application.Commands
{
    public class CreateCourse
    {
        public class CreateCourseCommand : IRequest<CourseResponse>
        {
            public string Name { get; init; } = default!;
            public string Description { get; init; } = default!;
            public string CourseInformation { get; init; } = default!;
            public string? CoverPhotoUrl { get; init; }
            public int Duration { get; init; }
            public DurationUnit DurationUnit { get; init; }
            public IReadOnlyList<CourseMode> CourseModes { get; set; } = null!;
        }

        public record CourseResponse(Guid Id, string Name, string Description, string CourseInformation, string? CoverPhotoUrl, int Duration, DurationUnit DurationUnit, List<CourseMode> CourseModes);

        public class Handler : IRequestHandler<CreateCourseCommand, CourseResponse>
        {
            private readonly ICourseRepository _courseRepository;
            private readonly IUnitOfWork _unitOfWork;

            public Handler(ICourseRepository courseRepository, IUnitOfWork unitOfWork)
            {
                _courseRepository = courseRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<CourseResponse> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
            {
                //Check if a course already exist by name
                var courseExist = await _courseRepository.ExistAsync(request.Name);
                if (courseExist)
                {
                    throw new DuplicateException($"Course with name : {request.Name} already exist");
                }

                var course = new Course(request.Name, request.Description, request.CourseInformation, request.CoverPhotoUrl, request.Duration, request.DurationUnit);

                foreach(var mode in request.CourseModes)
                {
                    course.AddCourseMode(mode);
                }

                await _courseRepository.AddAsync(course);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
                return new CourseResponse(course.Id, course.Name, course.Description, course.CourseInformation, course.CoverPhotoUrl, course.Duration, course.DurationUnit, course.CourseModes.ToList());
            }
        }
    }
}
