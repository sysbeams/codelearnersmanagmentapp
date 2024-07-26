using Application.Contracts.Services;
using Application.Dtos;
using Application.Exceptions;
using Domain.Aggreagtes.ApplicantAggregate;
using Domain.Repositories;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ApplicantService : IApplicantService
    {
        
        private readonly IApplicantRepository _applicantRepository;
        
        private readonly IUserRepository _userRepository;

        public ApplicantService(IApplicantRepository applicantRepository,IUserRepository userRepository)
        {
            _applicantRepository = applicantRepository;
            _userRepository = userRepository;
        }

        public async Task<BaseResponse> RegisterApplicant(CreateApplicantRequest request)
        {
            var userDetails = await _userRepository.GetUserByAsync(user => user.UserName == request.UserName) ?? throw new ValidationException($"This Applicant Username {request.UserName} does not exist in our system");

            if (request == null || string.IsNullOrEmpty(request.FirstName) || string.IsNullOrEmpty(request.LastName) || string.IsNullOrEmpty(request.EmailAddress))
            {
                return new ApplicantResponse(null, null, null, "Invalid request data." ,false );
            }
                var applicant = new Applicant(request.FirstName,request.LastName,request.EmailAddress);
                await _applicantRepository.CreateApplicant(applicant);
                 await _userRepository.RegisterUserAsync(userDetails);
                var result = await _applicantRepository.SaveChangesAsync();
                bool isSuccessful = result >= 1;
                var message = isSuccessful ? "Applicant created successfully" : throw new ApplicationException("An error occurred while saving the applicant to the database.");
                return new ApplicantResponse( request.FirstName, request.LastName, request.EmailAddress, message, isSuccessful);
        }
    }
}
