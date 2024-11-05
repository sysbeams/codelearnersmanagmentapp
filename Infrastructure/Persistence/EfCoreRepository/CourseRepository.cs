using Domain.Aggreagtes.CourseAggregate;
using Domain.Paging;
using Domain.Repositories;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.EfCoreRepository
{
    public class CourseRepository(ApplicationContext context) : ICourseRepository
    {
        private readonly ApplicationContext _context = context;

        public async Task<Course> AddAsync(Course course)
        {
            await _context.AddAsync(course);
            return course;
        }

        public async Task<bool> ExistAsync(string name)
        {
            return await _context.Courses.AnyAsync(x => x.Name == name);
        }

        public async Task<Course?> GetByIdAsync(Guid courseId)
        {
            return await _context.Courses.Include(x => x.CourseModes).FirstOrDefaultAsync(x => x.Id == courseId);
        }

        public async Task<PaginatedList<Course>> GetCourses(PageRequest pageRequest, bool usePaging = true)
        {
            var query = _context.Courses.AsQueryable();

            query = query.OrderBy(r => r.Name);

            var totalItemsCount = await query.CountAsync();
            if (usePaging)
            {
                var offset = (pageRequest.Page - 1) * pageRequest.PageSize;
                var result = await query.Skip(offset).Take(pageRequest.PageSize).ToListAsync();
                return result.ToPaginatedList(totalItemsCount, pageRequest.Page, pageRequest.PageSize);
            }
            else
            {
                var result = await query.ToListAsync();
                return result.ToPaginatedList(totalItemsCount, 1, totalItemsCount);
            }
        }

        public async Task<Course> UpdateAsync(Course course)
        {
            _context.Update(course);
            return course;
        }
    }
}
