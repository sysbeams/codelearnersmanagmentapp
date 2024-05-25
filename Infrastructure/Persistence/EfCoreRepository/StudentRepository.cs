
using Domain.Repositories;
using Infrastructure.Context;

namespace Infrastructure.Repositories;

public class StudentRepository(ApplicationContext context) : IStudentRepository
{
    private readonly ApplicationContext _context = context;

    public bool IsExitByEmail(string email) => _context.Students.Any(s => s.EmailAddress == email);

    public bool IsExitByNumber(string studentNumber) => _context.Students.Any(s => s.StudentNumber == studentNumber);
}
