using Domain.Aggreagtes.CourseAggregate;


namespace Domain.Repositories.ICourseAggregateRepository
{
    public interface ICourseTypeRepository
    {
        Task<CourseType> AddAsync(CourseType courseType);
        Task<CourseType?> GetByIdAsync(Guid courseTypeId);
        Task<List<CourseType>> GetAllAsync();
        Task<CourseType> UpdateAsync(CourseType courseType);
        Task DeleteAsync(Guid courseTypeId);
    }
}
