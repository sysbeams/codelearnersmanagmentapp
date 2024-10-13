using Domain.Aggreagtes.Organization_Aggregate;
using System.Linq.Expressions;
namespace Domain.Repositories
{
    public interface IOrganizationRepository
    {
        Task<Organization?> GetOrganizationAsync(Expression<Func<Organization, bool>> expression);
    }
}
