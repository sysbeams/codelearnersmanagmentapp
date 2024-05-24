
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
        return _context.Students.Any(s => s.EmailAddress == email);
       
        
    }

    public bool IsExitByNumber(string studentNumber)
    {
        return _context.Students.Any(s => s.StudentNumber == studentNumber);
        
    }
}
