using Application.Dtos;

namespace Application.Contracts.Services
{
    public interface IApplicantService
    {
        Task<BaseResponse> RegisterApplicant(CreateApplicantRequest request);
        Task<ApplicantResponse> GetApplicantById(Guid id);
        Task<IEnumerable<ApplicantResponse>> GetAllApplicantsAsync();
    }
}
