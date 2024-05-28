
using Domain.Aggreagtes.StudentAggregate;
using Domain.Repositories;
using Infrastructure.Persistence.Context;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public class StudentRepository(ApplicationContext context) : IStudentRepository
{
    private readonly ApplicationContext _context = context;

    public Task<bool> DeActivate(string studentNumber)
    {
        throw new NotImplementedException();
    }

    public Task<Student> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Student> GetStudentByAsync(Expression<Func<Student, bool>> expression)
    {
        throw new NotImplementedException();
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
}
