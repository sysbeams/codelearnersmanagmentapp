using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Repositories.IOrganizationAggregateRepository
{
    public interface IDepartmentRepository
    {
        Task<Department?> GetDepartmentByIdAsync(Guid departmentId);
        Task<Department> AddDepartmentAsync(Department department);
        Task<Department> UpdateDepartmentAsync(Department department);
        Task DeleteDepartmentAsync(Department department);
        Task<bool> ExistsAsync(Guid departmentId);
    }

}