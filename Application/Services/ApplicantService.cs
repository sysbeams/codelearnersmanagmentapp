using Application.Contracts.Services;
using Application.Dtos;
using Application.Exceptions;
using Domain.Repositories;

namespace Application.Services;

public class ApplicantService : IApplicantService
{

    private readonly IApplicantRepository _applicantRepository;
    private readonly Domain.Services.UserService _userService;
    private readonly Domain.Services.ApplicantService _applicantDomain;
    private readonly IUserRepository _userRepository;

    public ApplicantService(IApplicantRepository applicantRepository, Domain.Services.UserService userService, IUserRepository userRepository, Domain.Services.ApplicantService applicantDomain)
    {
        _applicantRepository = applicantRepository;
        _userRepository = userRepository;
        _applicantDomain = applicantDomain;
        _userService = userService;
    }

    public async Task<ApplicantResponse> GetApplicantById(Guid id)
    {
        var applicants = await _applicantRepository.GetApplicantAsync(applicant => applicant.Id == id);
        if (applicants == null)
        {
            throw new ApplicationException($"Applicant With This {id} Did Not Exist");
        }
        var message = "Applicant Successfully Retrieved";
        return new ApplicantResponse(applicants.FirstName, applicants.LastName, applicants.EmailAddress, message, true);
    }

    public async Task<BaseResponse> RegisterApplicant(CreateApplicantRequest request)
    {

        if (request == null || string.IsNullOrEmpty(request.FirstName) || string.IsNullOrEmpty(request.LastName) || string.IsNullOrEmpty(request.UserName) || string.IsNullOrEmpty(request.EmailAddress) || string.IsNullOrEmpty(request.Password) || string.IsNullOrEmpty(request.ConfirmPassword))
        {
            throw new ValidationException("All The Field Are Required");
        }

        if (request.Password != request.ConfirmPassword)
        { 
            throw new ValidationException("InCorrect Confirm Password");
        }

        var userDetails = await _userRepository.GetUserByAsync(user => user.UserName == request.UserName || user.EmailAddress == request.EmailAddress);
        if (userDetails != null)
        {
            throw new ValidationException("User With This Email Or UserName Already Exist");
        }

        var user = _userService.CreateUser(request.UserName, request.EmailAddress, request.Password);
        var applicant = _applicantDomain.CreateApplicant(request.FirstName, request.LastName, request.EmailAddress);
        await _applicantRepository.CreateApplicant(applicant);
        await _userRepository.RegisterUserAsync(user);
        var result = await _applicantRepository.SaveChangesAsync();
        bool isSuccessful = result >= 1;
        var message = isSuccessful ? "Applicant created successfully" : throw new ApplicationException("An error occurred while saving the applicant to the database.");
        return new ApplicantResponse(request.FirstName, request.LastName, request.EmailAddress, message, isSuccessful);
    }
}
