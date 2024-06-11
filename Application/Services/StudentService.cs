using Application.Contracts.IStudentService;
using Application.Dtos;
using Application.Exceptions;
using Domain.Aggreagtes.StudentAggregate;
using Domain.Exceptions;
using Domain.Repositories;
using System.Net.Mail;

namespace Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly Domain.Services.StudentService _domainStudentService;
        private readonly IApplicantRepository _applicantRepository;
        public StudentService(IStudentRepository studentRepository, Domain.Services.StudentService domainStudentService,IApplicantRepository applicantRepository)
        {
            _studentRepository = studentRepository;
            _domainStudentService = domainStudentService;
            _applicantRepository = applicantRepository;
        }
        
        public async Task<StudentResponse> RegisterStudent(CreateStudentRequest request)
        {
            var applicantDetails = await _applicantRepository.GetApplicantAsync(applicant => applicant.Id == request.ApplicantId);
            if(applicantDetails == null)
            {
                throw new ValidationException($"This Applicant ID {request.ApplicantId} does not exist in our system");
            };
            var student = _domainStudentService.CreateStudent(applicantDetails.Firstname, applicantDetails.Lastname, request.PhoneNumber, applicantDetails.EmailAddress, request.DateOfBirth); 
            student.AddAddress(request.Street, request.City, request.State, request.Country);
            await _studentRepository.RegisterStudentAsync(student);
            var save = await _studentRepository.SaveChangesAsync();
            var message = save > 0 ? "Student created successfully" : "An error occured while creating student, pls try again";
            var address = $"Street:{student.Address.Street},City:{student.Address.City},State:{student.Address.State},Country:{student.Address.Country} ";
            return new StudentResponse(student.StudentNumber, student.Firstname, student.Lastname, student.PhoneNumber, student.EmailAddress, address, student.Sponsor.Name, message, save > 0);

        }

        

        public Task<StudentResponse> GetStudentByEMail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<StudentResponse> GetStudentByStudentNumber(string studentNo)
        {
            throw new NotImplementedException();
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
