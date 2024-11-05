using Application.Dtos;
using Application.Exceptions;
using Domain.Repositories;
using MediatR;

namespace Application.Queries
{
    public class GetApplicant
    {

        public record Query : IRequest<ApplicantResponse>
        {
            public Guid Id { get; set; }
        }

        public record ApplicantResponse(string FirstName, string LastName, string EmailAddress, string Message, Guid ID, bool IsSuccessful)
              : BaseResponse(Message, IsSuccessful);
        public class Handler : IRequestHandler<Query, ApplicantResponse>
        {
            private readonly IApplicantRepository _applicantRepository;

            public Handler(IApplicantRepository applicantRepository)
            {
                _applicantRepository = applicantRepository;
            }

            public async Task<ApplicantResponse> Handle(Query request, CancellationToken cancellationToken)
            {
                var applicant = await _applicantRepository.GetByIdAsync(request.Id) ?? throw new NotFoundException("Applicant not found");
                var message = "Applicant Successfully Retrieved";
                return new ApplicantResponse(applicant.FirstName, applicant.LastName, applicant.EmailAddress, message, applicant.Id, true);
            }
        }
    }


}
