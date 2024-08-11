using Application.Dtos;
using Domain.Paging;
using Domain.Repositories;
using Mapster;
using MediatR;

namespace Application.Queries
{
    public class GetApplicants
    {
        public record Query(bool UsePaging = true) : PageRequest, IRequest<PaginatedList<ApplicantResponse>>;

        public record ApplicantResponse(string FirstName, string LastName, string EmailAddress, Guid ID);
        public class Handler : IRequestHandler<Query, PaginatedList<ApplicantResponse>>
        {
            private readonly IApplicantRepository _applicantRepository;

            public Handler(IApplicantRepository applicantRepository)
            {
                _applicantRepository = applicantRepository;
            }
            public async Task<PaginatedList<ApplicantResponse>> Handle(Query request, CancellationToken cancellationToken)
            {
                var applicant = await _applicantRepository.GetAllAsync(request, request.UsePaging);
                return applicant.Adapt<PaginatedList<ApplicantResponse>>();
            }
        }
    }
}
