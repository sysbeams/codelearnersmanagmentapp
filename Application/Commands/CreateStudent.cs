using Application.Dtos;
using Application.Exceptions;
using Domain.Enums;
using Domain.Repositories;
using MediatR;

namespace Application.Commands
{
    public class CreateStudent
    {

        public class RegisterStudentCommand : IRequest<StudentResponse>
        {
            public string? PhoneNumber { get; init; }

            public string? Street { get; init; }

            public string? City { get; init; }

            public string? State { get; init; }

            public string? Country { get; init; }

            public EducationLevel EducationLevel { get; init; }

            public string? SponsorName { get; init; }

            public string? SponsorEmailAddress { get; init; }

            public string? SponsorPhoneNumber { get; init; }

            public Guid ApplicantId { get; init; }
        }

        public record StudentResponse(
       string StudentNumber,
       string FirstName,
       string LastName,
       string PhoneNumber,
       string EmailAddress,
       string Address,
       string SponsorName,
       string Message,
       bool IsSuccessful
       ) : BaseResponse(Message, IsSuccessful);
        public class CreateStudentCommandHandler : IRequestHandler<RegisterStudentCommand, StudentResponse>
        {
            private readonly IStudentRepository _studentRepository;
            private readonly Domain.Services.StudentService _domainStudentService;
            private readonly IApplicantRepository _applicantRepository;
            private readonly IUnitOfWork _unitOfWork;

            public CreateStudentCommandHandler(IStudentRepository studentRepository, Domain.Services.StudentService domainStudentService, IApplicantRepository applicantRepository, IUnitOfWork unitOfWork)
            {
                _studentRepository = studentRepository;
                _domainStudentService = domainStudentService;
                _applicantRepository = applicantRepository;
                _unitOfWork = unitOfWork;
            }
            public async Task<StudentResponse> Handle(RegisterStudentCommand request, CancellationToken cancellationToken)
            {
                var applicantDetails = await _applicantRepository
                    .GetApplicantAsync(applicant => applicant.Id == request.ApplicantId) ?? throw new ValidationException($"This Applicant ID {request.ApplicantId} does not exist in our system");

                var student = _domainStudentService.CreateStudent(applicantDetails.FirstName, applicantDetails.LastName, request.PhoneNumber, applicantDetails.EmailAddress);
                student.AddAddress(request.Street, request.City, request.State, request.Country);

                await _studentRepository.RegisterStudentAsync(student);
                var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
                bool isSuccessful = result >= 1;
                var message = isSuccessful ? "Student created successfully" : throw new ApplicationException("An error occurred while saving the student to the database.");
                var address = $"Street: {student.Address.Street}, City: {student.Address.City}, State: {student.Address.State}, Country: {student.Address.Country}";
                return new StudentResponse(student.StudentNumber, student.Firstname, student.Lastname, student.PhoneNumber, student.EmailAddress, address, student.Sponsor?.Name, message, isSuccessful);
            }
        }
    }
}
