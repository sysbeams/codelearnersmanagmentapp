
using Domain.Repositories;
using Infrastructure.Context;

namespace Infrastructure.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly ApplicationContext _context;

    public StudentRepository(ApplicationContext context)
    {
        _context = context;
    }

    public bool IsExitByEmail(string email)
    {
        var emailExist = _context.Students.Any(s => s.EmailAddress == email);
        return emailExist;
        
    }

    public bool IsExitByNumber(string studentNumber)
    {
        var emailExist = _context.Students.Any(s => s.StudentNumber == studentNumber);
        return emailExist;
    }
}
