using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Aggreagtes.Organization_Aggregate;

namespace Domain.Repositories.IOrganizationAggregateRepository
{
    public interface IOrganizationRepository
    {
        Task<Organization?> GetByIdAsync(Guid organizationId);
        Task<IEnumerable<Organization>> GetAllAsync();
        Task<Organization> AddAsync(Organization organization);
        Task<Organization> UpdateAsync(Organization organization);
        Task DeleteAsync(Organization organization);
        Task<bool> ExistsAsync(Guid organizationId);
    }

}