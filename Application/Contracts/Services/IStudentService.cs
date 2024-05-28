

using Application.Dtos;

namespace Application.Contracts.IStudentService
{
    public interface IStudentService
    {
        Task<StudentResponse> RegisterStudent(CreateStudentRequest request);
        Task<StudentResponse> GetStudentByEMail(string email);
        Task<StudentResponse> GetStudentByStudentNumber(string studentNo);
        Task<GetStudentsResponse> GetStudents();
        Task<BaseResponse> DeActivate (string studentNo);
        Task<StudentResponse> ReActivate(string studentNo);

    }
}

