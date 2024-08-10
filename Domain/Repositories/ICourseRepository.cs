using Domain.Aggreagtes.CourseAggregate;
using Domain.Paging;

namespace Domain.Repositories
{
    public interface ICourseRepository
    {
        Task<Course> AddAsync(Course course);
        Task<Course?> GetByIdAsync(Guid courseId);
        Task<bool> ExistAsync(string name);

        Task<Course> UpdateAsync(Course course);
        Task<PaginatedList<Course>> GetCourses(PageRequest pageRequest, bool usePaging = true);
    }
}
