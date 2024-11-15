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
    public class AdjunctStaffRepository : IAdjunctStaffRepository
    {
        private readonly ApplicationContext _context;

        public AdjunctStaffRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<AdjunctStaff?> GetAdjunctStaffByIdAsync(Guid adjunctStaffId)
        {
            return await _context.AdjunctStaffs
                .Include(a => a.Department)
                .FirstOrDefaultAsync(a => a.Id == adjunctStaffId);
        }

        public async Task<AdjunctStaff> AddAdjunctStaffAsync(AdjunctStaff adjunctStaff)
        {
            await _context.AdjunctStaffs.AddAsync(adjunctStaff);
            return adjunctStaff;
        }

        public async Task<AdjunctStaff> UpdateAdjunctStaffAsync(AdjunctStaff adjunctStaff)
        {
            _context.AdjunctStaffs.Update(adjunctStaff);
            return adjunctStaff;
        }

        public async Task DeleteAdjunctStaffAsync(AdjunctStaff adjunctStaff)
        {
            _context.AdjunctStaffs.Remove(adjunctStaff);
        }

        public async Task<bool> ExistsAsync(Guid adjunctStaffId)
        {
            return await _context.AdjunctStaffs.AnyAsync(a => a.Id == adjunctStaffId);
        }
    }
}