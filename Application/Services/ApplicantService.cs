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
        var applicant = await _applicantRepository.GetApplicantAsync(applicant => applicant.Id == id);
        if (applicant == null)
        {
            throw new ApplicationException($"Applicant With This {id} Did Not Exist");
        }
        var message = "Applicant Successfully Retrieved";
        return new ApplicantResponse(applicant.FirstName, applicant.LastName, applicant.EmailAddress, message, applicant.Id, true);
    }

    public async Task<BaseResponse> RegisterApplicant(CreateApplicantRequest request)
    {
        if (request == null || string.IsNullOrEmpty(request.FirstName) || string.IsNullOrEmpty(request.LastName) || string.IsNullOrEmpty(request.UserName) || string.IsNullOrEmpty(request.EmailAddress) || string.IsNullOrEmpty(request.Password) || string.IsNullOrEmpty(request.ConfirmPassword))
        {
            throw new ValidationException("All The Field Are Required");
        }

        if (request.Password != request.ConfirmPassword)
        {
            throw new ValidationException("Incorrect Confirm Password");
        }

        var userDetails = await _userRepository.GetUserByAsync(user => user.UserName == request.UserName || user.EmailAddress == request.EmailAddress);
        if (userDetails != null)
        {
            throw new ValidationException("User With This Email Or UserName Already Exists");
        }

        var user = _userService.CreateUser(request.UserName, request.EmailAddress, request.Password);

        using (var transaction = await _userRepository.BeginTransactionAsync())
        {
            try
            {
                await _userRepository.RegisterUserAsync(user);
                await _userRepository.SaveChangesAsync();

                var applicant = _applicantDomain.CreateApplicant(request.FirstName, request.LastName, request.EmailAddress, user.Id);
                await _applicantRepository.CreateApplicant(applicant);
                var result = await _applicantRepository.SaveChangesAsync();

                if (result >= 1)
                {
                    await transaction.CommitAsync();
                    return new ApplicantResponse(request.FirstName, request.LastName, request.EmailAddress, "Applicant created successfully", applicant.Id, true);
                }
                else
                {
                    throw new ApplicationException("An error occurred while saving the applicant to the database.");
                }
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                await _userRepository.DeleteUserAsync(user);
                await _userRepository.SaveChangesAsync();
                throw;
            }
        }
    }

    public async Task<IEnumerable<ApplicantResponse>> GetAllApplicantsAsync()
    {
        var applicants = await _applicantRepository.GetAllAsync();
        return applicants.Select(applicant => new ApplicantResponse(applicant.FirstName, applicant.LastName, applicant.EmailAddress, "Applicant successfully retrieved.", applicant.Id, true));
    }
}

