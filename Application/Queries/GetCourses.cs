using Domain.Aggreagtes.CourseAggregate;
using Domain.Enums;
using Domain.Paging;
using Domain.Repositories;
using Mapster;
using MediatR;

namespace Application.Queries
{
    public class GetCourses
    {
        public record Query(bool UsePaging = true) : PageRequest, IRequest<PaginatedList<CourseResponse>>;

        public record CourseResponse(Guid Id, string Name, string Description, string CourseInformation, string? CoverPhotoUrl, int Duration, DurationUnit DurationUnit, List<CourseMode> CourseModes);

        public class Handler : IRequestHandler<Query, PaginatedList<CourseResponse>>
        {
            private readonly ICourseRepository _courseRepository;

            public Handler(ICourseRepository courseRepository)
            {
                _courseRepository = courseRepository;
            }
            public async Task<PaginatedList<CourseResponse>> Handle(Query request, CancellationToken cancellationToken)
            {
                var courses = await _courseRepository.GetCourses(request, request.UsePaging);
                return courses.Adapt<PaginatedList<CourseResponse>>();
            }
        }
    }
}
