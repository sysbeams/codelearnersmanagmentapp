using Domain.Aggreagtes.StudentAggregate;
using Domain.Exceptions;
using Domain.Repositories;



namespace Domain.Services
{
    public class StudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository) { 
            _studentRepository = studentRepository;
        }

        public Student CreateStudent(string firstname, string lastname, string phoneNumber, string emailAddress)
        {
            if(_studentRepository.IsExitByEmail(emailAddress))
            {
                throw new EmailDuplicateException($"This email {emailAddress} already exist in our system");
            }
            var uniqueStudentNumber = GetUniqueStudentNumber();
            return new Student (uniqueStudentNumber, firstname, lastname, phoneNumber, emailAddress);
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
    }
}
