using Domain.Aggreagtes.StaffAggregate;
using System.Linq.Expressions;

namespace Domain.Repositories
{
    public interface IEmploymentContractRepository
    {
        Task<EmploymentContract> CreateEmploymentContractAsync(EmploymentContract details);
        Task<EmploymentContract> GetEmploymentContractAsync(Expression<Func<EmploymentContract, bool>> expression);
        Task<IEnumerable<EmploymentContract>> GetAllEmploymentContractAsync();
        void UpdateEmploymentContractAsync(EmploymentContract detail);
        Task<int> SaveChangesAsync();
    }
}
