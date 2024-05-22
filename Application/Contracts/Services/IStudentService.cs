

using Application.Dtos;

namespace Application.Contracts.IStudentService;

public  interface IStudentService
{
    BaseResponse CreateStudent(CreateStudentrequest request);
    StudentResponse GetStudentByMail(string mail);
    StudentResponse GetStudentBy(string mail);
    StudentsResponse GetStudents();

}
