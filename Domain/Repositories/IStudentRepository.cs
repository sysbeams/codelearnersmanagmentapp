using Domain.Aggreagtes.StudentAggregate;
using Domain.Paging;
using System.Linq.Expressions;

namespace Domain.Repositories
{
    public interface IStudentRepository
    {
        bool IsExitByNumber(string studentNumber);
        bool IsExitByEmail(string email);
        Task<bool> DeActivateAsync(string studentNumber);
        Task<Student> ReActivateAsync(string studentNumber);
        Task<Student> GetStudentByAsync(Expression<Func<Student, bool>> expression);
        Task<Student?> GetByIdAsync(Guid studentId);
        Task<Student> Update(Student Student);
        Task<PaginatedList<Student>> GetAllAsync(PageRequest pageRequest, bool usePaging = true);
        Task<Student> RegisterStudentAsync(Student student);

    }
}
