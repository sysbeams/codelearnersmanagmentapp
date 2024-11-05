using Application.Dtos;
using Application.Exceptions;
using Domain.Repositories;
using MediatR;

namespace Application.Commands
{
    public class CreateApplicant
    {
        public class CreateApplicantCommand : IRequest<ApplicantResponse>
        {
            public string? LastName { get; init; }
            public string? FirstName { get; init; }
            public string? EmailAddress { get; init; }
            public string? UserName { get; init; }
            public string? Password { get; init; }
            public string? ConfirmPassword { get; init; }
        }

        public record ApplicantResponse(string FirstName, string LastName, string EmailAddress, string Message, Guid ID, bool IsSuccessful)
            : BaseResponse(Message, IsSuccessful);

        public class CreateApplicantCommandHandler : IRequestHandler<CreateApplicantCommand, ApplicantResponse>
    {
        private readonly IApplicantRepository _applicantRepository;
        private readonly Domain.Services.UserService _userService;
        private readonly Domain.Services.ApplicantService _applicantDomain;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

            public CreateApplicantCommandHandler(
            IApplicantRepository applicantRepository,
            Domain.Services.UserService userService,
            IUserRepository userRepository,
            IUnitOfWork unitOfWork,
            Domain.Services.ApplicantService applicantDomain)
        {
            _applicantRepository = applicantRepository;
            _userRepository = userRepository;
            _applicantDomain = applicantDomain;
            _userService = userService;
            _unitOfWork = unitOfWork;
        }

        public async Task<ApplicantResponse> Handle(CreateApplicantCommand request, CancellationToken cancellationToken)
        {
            if (request == null || string.IsNullOrEmpty(request.FirstName) || string.IsNullOrEmpty(request.LastName) ||
                string.IsNullOrEmpty(request.UserName) || string.IsNullOrEmpty(request.EmailAddress) ||
                string.IsNullOrEmpty(request.Password) || string.IsNullOrEmpty(request.ConfirmPassword))
            {
                throw new ValidationException("All fields are required.");
            }

            if (request.Password != request.ConfirmPassword)
            {
                throw new ValidationException("Password and Confirm Password do not match.");
            }

            var existingUser = await _userRepository.GetUserByAsync(user =>
                user.UserName == request.UserName || user.EmailAddress == request.EmailAddress);

            if (existingUser != null)
            {
                throw new ValidationException("A user with this email or username already exists.");
            }

            var user = _userService.CreateUser(request.UserName, request.EmailAddress, request.Password);

            using (var transaction = await _userRepository.BeginTransactionAsync())
            {
                try
                {
                    await _userRepository.RegisterUserAsync(user);
                    await _unitOfWork.SaveChangesAsync(cancellationToken);

                    var applicant = _applicantDomain.CreateApplicant(request.FirstName, request.LastName, request.EmailAddress, user.Id);
                    await _applicantRepository.CreateApplicant(applicant);
                    var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

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
                    await _unitOfWork.SaveChangesAsync(cancellationToken);
                    throw;
                }
            }
        }
    }

}
}
