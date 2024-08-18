using Domain.Aggreagtes.ApplicantAggregate;
using Domain.Paging;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;

namespace Domain.Repositories
{
    public interface IApplicantRepository
    {
        Task<Applicant> CreateApplicant(Applicant newApplicant);
        Task<Applicant> GetApplicantAsync(Expression<Func<Applicant, bool>> expression);
        Task<Applicant?> GetByIdAsync(Guid applicantId);
        bool IsExitByEmail(string email);
        Task<IDbContextTransaction> BeginTransactionAsync();
        Task<Applicant> Update(Applicant applicant);
        Task<PaginatedList<Applicant>> GetAllAsync(PageRequest pageRequest, bool usePaging = true);
    }
}
