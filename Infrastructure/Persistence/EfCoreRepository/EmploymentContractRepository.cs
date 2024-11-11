using Domain.Aggreagtes.StaffAggregate;
using Domain.Repositories;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace Infrastructure.Persistence.EfCoreRepository
{
    public class EmploymentContractRepository(ApplicationContext _context) : IEmploymentContractRepository
    {
        public async Task<EmploymentContract> CreateEmploymentContractAsync(EmploymentContract details)
        {
            await _context.EmploymentContracts.AddAsync(details);
            return details;
        }

        public async Task<IEnumerable<EmploymentContract>> GetAllEmploymentContractAsync()
            => await _context.EmploymentContracts.ToListAsync();

        public async Task<EmploymentContract?> GetEmploymentContractAsync(Expression<Func<EmploymentContract, bool>> expression)
            => await _context.EmploymentContracts.FirstOrDefaultAsync(expression);

        public void UpdateEmploymentContractAsync(EmploymentContract detail)
            => _context.EmploymentContracts.Update(detail);

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
