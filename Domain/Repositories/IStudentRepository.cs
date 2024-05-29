using Domain.Aggreagtes.StudentAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IStudentRepository
    {
        bool IsExitByNumber(string studentNumber);
        bool IsExitByEmail(string email);
        Task<bool> DeActivate(string studentNumber);
        Task<Student> ReActivateAsync(string studentNumber);
        Task<Student> GetStudentByAsync(Expression<Func<Student, bool>> expression);
        Task<Student> GetAllAsync();
        Task<Student> RegisterStudentAsync(Student student);
        Task<int> SaveChangesAsync();
    }
}
