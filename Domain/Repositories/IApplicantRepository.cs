using Domain.Aggreagtes.ApplicantAggregate;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;

namespace Domain.Repositories
{
    public interface IApplicantRepository
    {
        Task<Applicant> CreateApplicant(Applicant newApplicant);
        Task<Applicant> GetApplicantAsync(Expression<Func<Applicant, bool>> expression);
        bool IsExitByEmail(string email);
        Task<int> SaveChangesAsync();
        Task<IDbContextTransaction> BeginTransactionAsync();
        Task<IEnumerable<Applicant>> GetAllAsync();
    }
}
