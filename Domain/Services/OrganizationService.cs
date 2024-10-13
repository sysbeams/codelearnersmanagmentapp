using Domain.Exceptions;
using Domain.Repositories;

namespace Domain.Services
{
    public class OrganizationService(IOrganizationRepository _organizationRepo) 
    {
        public async Task EnsureOrganizationNameIsUnique(string name)
        {
            var existingOrganization = await _organizationRepo.GetOrganizationAsync(O => O.Name.ToLower() == name.ToLower());

            if (existingOrganization != null)
            {
                throw new OrganizationRuleException($"This Organization Name {name} Already Exist In Our System");
            }
        }

        public async Task EnsureDepartmentNameIsUnique(Guid organizationId, string name)
        {
            var existingOrganization = await _organizationRepo.GetOrganizationAsync(O => O.Id == organizationId);

            if (existingOrganization.Departments.Any(d => d.Name == name))
            {
                throw new OrganizationRuleException($"This Department Name {name} Already Exist In Our System");
            }
        }
    }
}
