using Application.Contracts.IStudentService;
using Application.Dtos;
using Domain.Aggreagtes.StudentAggregate;
using Domain.Exceptions;
using Domain.Repositories;
using System.Net.Mail;

namespace Domain.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository) { 
            _studentRepository = studentRepository;
        }

        public async Task<StudentResponse> RegisterStudent(CreateStudentRequest request)
        {
            if (_studentRepository.IsExitByEmail(request.EmailAddress))
            {
                throw new EmailDuplicateException($"This email {request.EmailAddress} already exist in our system");
            }
            var uniqueStudentNumber = GetUniqueStudentNumber();
            var student = new Student(uniqueStudentNumber, request.FirstName,request.LastName,request.PhoneNumber,request.EmailAddress);
            await _studentRepository.RegisterStudentAsync(student);
            var save = await _studentRepository.SaveChangesAsync();
            var message = (save > 0) ? "Student created successfully" : "An error occured while creating student, pls try again";
            var address = $"Street:{student.Address.Street},City:{student.Address.City},State:{student.Address.State},Country:{student.Address.Country} ";
            return new StudentResponse(student.StudentNumber, student.Firstname, student.Lastname, student.PhoneNumber, student.EmailAddress,address, student.Sponsor.Name, message,(save > 0));
            
        }

        private string GetUniqueStudentNumber()
        {
            var uniqueNumber = GetStudentNumber();
            bool checkUniqueNumber = true;
            while (checkUniqueNumber)
            {
                var isExist = _studentRepository.IsExitByNumber(uniqueNumber);
                if (!isExist)
                {
                    break;
                }
                uniqueNumber = GetStudentNumber();
            }
            return uniqueNumber;
        }

        private string GetStudentNumber() { 
            var rnd = new Random();
            var number = rnd.Next(1000000,9999999);
            return $"c{number}";
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
