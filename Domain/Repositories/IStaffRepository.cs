using Domain.Aggreagtes.StaffAggregate;
using System.Linq.Expressions;


namespace Domain.Repositories
{
    public interface IStaffRepository
    {
        Task<Staff> CreateStaffAsync(Staff staff);
        Task<Staff> GetStaffAsync(Expression<Func<Staff, bool>> expression);
        Task<IEnumerable<Staff>> GetAllStaffAsync();
        void UpdateStaffAsync(Staff staff);
        Task<int> SaveChangesAsync();
    }
}
