using Application.Exceptions;
using Domain.Aggreagtes.ApplicantAggregate;
using Domain.Aggreagtes.CourseAggregate;
using Domain.Aggreagtes.StudentAggregate;
using Domain.Enums;
using Domain.Repositories;
using MediatR;

namespace Application.Queries
{
    public class GetCourse
    {

        public record Query : IRequest<CourseResponse>
        {
            public Guid Id { get; set; }
        }

        public record CourseResponse(Guid Id, string Name, string Description, string CourseInformation, string? CoverPhotoUrl, int Duration, DurationUnit DurationUnit, List<CourseMode> CourseModes);

        public class Handler : IRequestHandler<Query, CourseResponse>
        {
            private readonly ICourseRepository _courseRepository;

            public Handler(ICourseRepository courseRepository)
            {
                _courseRepository = courseRepository;
            }

            public async Task<CourseResponse> Handle(Query request, CancellationToken cancellationToken)
            {
                var course = await _courseRepository.GetByIdAsync(request.Id) ?? throw new NotFoundException("Course not found");
                return new CourseResponse(course.Id, course.Name, course.Description, course.CourseInformation, course.CoverPhotoUrl, course.Duration, course.DurationUnit, course.CourseModes.ToList());
            }
        }
    }

}
