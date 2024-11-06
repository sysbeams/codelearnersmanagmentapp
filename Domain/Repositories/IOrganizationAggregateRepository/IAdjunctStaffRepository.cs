using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Aggreagtes.Organization_Aggregate;

namespace Domain.Repositories.IOrganizationAggregateRepository
{
    public interface IAdjunctStaffRepository
    {
        Task<AdjunctStaff?> GetAdjunctStaffByIdAsync(Guid adjunctStaffId);
        Task<AdjunctStaff> AddAdjunctStaffAsync(AdjunctStaff adjunctStaff);
        Task<AdjunctStaff> UpdateAdjunctStaffAsync(AdjunctStaff adjunctStaff);
        Task DeleteAdjunctStaffAsync(AdjunctStaff adjunctStaff);
        Task<bool> ExistsAsync(Guid adjunctStaffId);
    }
}