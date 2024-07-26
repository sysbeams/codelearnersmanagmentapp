using Application.Contracts.IStudentService;
using Application.Dtos;
using Application.Exceptions;
using Domain.Repositories;

namespace Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly Domain.Services.StudentService _domainStudentService;
        private readonly IApplicantRepository _applicantRepository;
        public StudentService(IStudentRepository studentRepository, Domain.Services.StudentService domainStudentService, IApplicantRepository applicantRepository)
        {
            _studentRepository = studentRepository;
            _domainStudentService = domainStudentService;
            _applicantRepository = applicantRepository;
        }

        public async Task<StudentResponse> RegisterStudent(CreateStudentRequest request)
        {
            var applicantDetails = await _applicantRepository
                .GetApplicantAsync(applicant => applicant.Id == request.ApplicantId) ?? throw new ValidationException($"This Applicant ID {request.ApplicantId} does not exist in our system");

            var student = _domainStudentService.CreateStudent(applicantDetails.Firstname, applicantDetails.Lastname, request.PhoneNumber, applicantDetails.EmailAddress);
            student.AddAddress(request.Street, request.City, request.State, request.Country);

            await _studentRepository.RegisterStudentAsync(student);


            var result = await _studentRepository.SaveChangesAsync();
            bool isSuccessful = result >= 1;
            var message = isSuccessful ? "Student created successfully" : throw new ApplicationException("An error occurred while saving the student to the database.");
            var address = $"Street: {student.Address.Street}, City: {student.Address.City}, State: {student.Address.State}, Country: {student.Address.Country}";
            return new StudentResponse(student.StudentNumber, student.Firstname, student.Lastname, student.PhoneNumber, student.EmailAddress, address, student.Sponsor?.Name, message, isSuccessful);
        }



        public Task<StudentResponse> GetStudentByEMail(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<StudentResponse> GetStudentByStudentNumber(string studentNo)
        {
            var student =  await _studentRepository.GetStudentByAsync(s => s.StudentNumber == studentNo);
            if(student == null)
            {
                return null;
            }
            var address = $"Street: {student.Address.Street}, City: {student.Address.City}, State: {student.Address.State}, Country: {student.Address.Country}";
            return new StudentResponse(student.StudentNumber, student.Firstname, student.Lastname, student.PhoneNumber, student.EmailAddress, address, student.Sponsor?.Name, "SuccessFull",true);
        }

        public Task<GetStudentsResponse> GetStudents()
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> DeActivate(string studentNo)
        {
            throw new NotImplementedException();
        }

        public Task<StudentResponse> ReActivate(string studentNo)
        {
            throw new NotImplementedException();
        }
    }
}
