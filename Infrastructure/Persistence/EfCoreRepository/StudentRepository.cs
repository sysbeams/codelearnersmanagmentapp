using Domain.Aggreagtes.StudentAggregate;
using Domain.Paging;
using Domain.Repositories;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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

        public async Task<PaginatedList<Student>> GetAllAsync(PageRequest pageRequest, bool usePaging = true)
        {
            var query = _context.Students.AsQueryable();

            query = query.OrderBy(r => r.CreatedOn);

            var totalItemsCount = await query.CountAsync();
            if (usePaging)
            {
                var offset = (pageRequest.Page - 1) * pageRequest.PageSize;
                var result = await query.AsNoTracking().Skip(offset).Take(pageRequest.PageSize).ToListAsync();
                return result.ToPaginatedList(totalItemsCount, pageRequest.Page, pageRequest.PageSize);
            }
            else
            {
                var result = await query.ToListAsync();
                return result.ToPaginatedList(totalItemsCount, 1, totalItemsCount);
            }
        }

        public async Task<Student?> GetByIdAsync(Guid studentId)
        {
            return await _context.Students.FirstOrDefaultAsync(x => x.Id == studentId);
        }

        public async Task<Student> GetStudentByAsync(Expression<Func<Student, bool>> expression)
        {
            return await _context.Students
                .AsNoTracking()
                .Include(s => s.Address)
                .Include(s => s.Sponsor)
                .FirstOrDefaultAsync(expression);
        }

        public bool IsExitByEmail(string email) => _context.Students.Any(s => s.EmailAddress == email);


        public bool IsExitByNumber(string studentNumber) => _context.Students.Any(s => s.StudentNumber == studentNumber);

        public Task<Student> ReActivateAsync(string studentNumber)
        {
            throw new NotImplementedException();
        }

        public async Task<Student> RegisterStudentAsync(Student student)
        {
            await _context.Students.AddAsync(student);
            return student;
        }

        public async Task<Student> Update(Student Student)
        {
            _context.Update(Student);
            return Student;
        }
    }
}
