

using Application.Dtos;

namespace Application.Contracts.IStudentService
{
    public interface IStudentService
    {
        Task<CreateStudentResponse> RegisterStudent(CreateStudentRequest request);
        Task<GetStudentResponse> GetStudentByEMail(string email);
        Task<GetStudentResponse> GetStudentByStudentNumber(string studentNo);
        Task<GetAllStudentResponse> GetStudents();
        Task<BaseResponse> DeActivate (string studentNo);
        Task<GetStudentResponse> ReActivate(string studentNo);

    }
}

