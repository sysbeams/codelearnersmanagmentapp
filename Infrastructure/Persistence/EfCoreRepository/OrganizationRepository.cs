using Domain.Aggreagtes.Organization_Aggregate;
using Domain.Repositories;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Persistence.EfCoreRepository
{
    public class OrganizationRepository(ApplicationContext _context) : IOrganizationRepository
    {
        public async Task<Organization?> GetOrganizationAsync(Expression<Func<Organization, bool>> expression) => await _context.Organizations
            .Include(o => o.Departments)
            .FirstOrDefaultAsync(expression);
    }
}
