using Application.Dtos;
using Domain.Paging;
using static Application.Services.ApplicantService;

namespace Application.Contracts.Services
{
    public interface IApplicantService
    {
        Task<BaseResponse> RegisterApplicant(CreateApplicantRequest request);
        Task<ApplicantResponse> GetApplicantById(Guid id);
        Task<PaginatedList<ApplicantResponse>> GetAllApplicantsAsync(Query request, CancellationToken cancellationToken);
    }
}
