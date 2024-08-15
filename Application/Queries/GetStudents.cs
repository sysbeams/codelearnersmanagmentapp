using Application.Dtos;
using Domain.Paging;
using Domain.Repositories;
using Mapster;
using MediatR;

namespace Application.Queries
{
    public class GetStudents
    {
        public record Query(bool UsePaging = true) : PageRequest, IRequest<PaginatedList<StudentResponse>>;

        public record StudentResponse(
            string StudentNumber,
            string FirstName,
            string LastName,
            string PhoneNumber,
            string EmailAddress,
            string Address,
            string SponsorName);
        public class Handler : IRequestHandler<Query, PaginatedList<StudentResponse>>
        {
            private readonly IStudentRepository _studentRepository;

            public Handler(IStudentRepository studentRepository)
            {
                _studentRepository = studentRepository;
            }
            public async Task<PaginatedList<StudentResponse>> Handle(Query request, CancellationToken cancellationToken)
            {
                var student = await _studentRepository.GetAllAsync(request, request.UsePaging);
                return student.Adapt<PaginatedList<StudentResponse>>();
            }
        }
    }
}
