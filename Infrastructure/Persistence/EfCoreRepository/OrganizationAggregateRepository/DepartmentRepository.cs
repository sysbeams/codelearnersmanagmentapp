using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Repositories.IOrganizationAggregateRepository;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.EfCoreRepository.OrganizationAggregateRepository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationContext _context;

        public DepartmentRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Department?> GetDepartmentByIdAsync(Guid departmentId)
        {
            return await _context.Departments
                .Include(d => d.Staffs)
                .Include(d => d.AdjunctStaffs)
                .FirstOrDefaultAsync(d => d.Id == departmentId);
        }

        public async Task<Department> AddDepartmentAsync(Department department)
        {
            await _context.Departments.AddAsync(department);
            return department;
        }

        public async Task<Department> UpdateDepartmentAsync(Department department)
        {
            _context.Departments.Update(department);
            return department;
        }

        public async Task DeleteDepartmentAsync(Department department)
        {
            _context.Departments.Remove(department);
        }

        public async Task<bool> ExistsAsync(Guid departmentId)
        {
            return await _context.Departments.AnyAsync(d => d.Id == departmentId);
        }
    }
}