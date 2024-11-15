using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Aggreagtes.Organization_Aggregate;
using Domain.Repositories.IOrganizationAggregateRepository;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.EfCoreRepository.OrganizationAggregateRepository
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly ApplicationContext _context;

        public OrganizationRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Organization?> GetByIdAsync(Guid organizationId)
        {
            return await _context.Organizations
                .Include(o => o.Departments)
                    .ThenInclude(d => d.Staffs)
                .Include(o => o.Departments)
                    .ThenInclude(d => d.AdjunctStaffs)
                .FirstOrDefaultAsync(o => o.Id == organizationId);
        }

        public async Task<IEnumerable<Organization>> GetAllAsync()
        {
            return await _context.Organizations
                .Include(o => o.Departments)
                    .ThenInclude(d => d.Staffs)
                .Include(o => o.Departments)
                    .ThenInclude(d => d.AdjunctStaffs)
                .ToListAsync();
        }

        public async Task<Organization> AddAsync(Organization organization)
        {
            await _context.Organizations.AddAsync(organization);
            return organization;
        }

        public async Task<Organization> UpdateAsync(Organization organization)
        {
            _context.Organizations.Update(organization);
            return organization;
        }

        public async Task DeleteAsync(Organization organization)
        {
            _context.Organizations.Remove(organization);
        }

        public async Task<bool> ExistsAsync(Guid organizationId)
        {
            return await _context.Organizations.AnyAsync(o => o.Id == organizationId);
        }
    }
}