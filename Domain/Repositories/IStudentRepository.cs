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
        Task<bool> DeActivateAsync(string studentNumber);
        Task<Student> ReActivateAsync(string studentNumber);
        Task<Student> GetStudentByAsync(Expression<Func<Student, bool>> expression);
        public Task<IEnumerable<Student>> GetAllAsync();
        Task<Student> RegisterStudentAsync(Student student);
        Task<int> SaveChangesAsync();
    }
}
