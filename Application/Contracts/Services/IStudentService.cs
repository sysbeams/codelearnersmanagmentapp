

using Application.Dtos;

namespace Application.Contracts.IStudentService
{
    public interface IStudentService
    {
        Task<BaseResponse> RegisterStudent(CreateStudentRequest request);
        Task<GetStudentResponse> GetStudentByEMail(string email);
        Task<GetStudentResponse> GetStudentByStudentNumber(string studentNo);
        Task<GetAllStudentResponse> GetAllStudents();

    }
}

