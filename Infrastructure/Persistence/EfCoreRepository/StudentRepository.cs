using Domain.Aggreagtes.StudentAggregate;
using Domain.Repositories;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationContext _context;

        public StudentRepository(ApplicationContext context)
        {
            _context = context;
        }


        public Task<bool> DeActivateAsync(string studentNumber)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Student>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Student> GetStudentByAsync(Expression<Func<Student, bool>> expression)
        {
            return await _context.Students.FirstOrDefaultAsync(expression);
        }

        public bool IsExitByEmail(string email) => _context.Students.Any(s => s.EmailAddress == email);


        public bool IsExitByNumber(string studentNumber) => _context.Students.Any(s => s.StudentNumber == studentNumber);

        public Task<Student> ReActivateAsync(string studentNumber)
        {
            throw new NotImplementedException();
        }

        public Task<Student> RegisterStudentAsync(Student student)
        {
            throw new NotImplementedException();
        }

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

    }
}
