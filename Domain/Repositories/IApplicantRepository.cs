using Domain.Aggreagtes.ApplicantAggregate;
using Domain.Aggreagtes.CourseAggregate;
using Domain.Paging;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;

namespace Domain.Repositories
{
    public interface IApplicantRepository
    {
        Task<Applicant> CreateApplicantAsync(Applicant newApplicant);
        Task<Applicant> GetApplicantAsync(Expression<Func<Applicant, bool>> expression);
        Task<Applicant> GetApplicantByIdAsync(Guid applicantId);
        Task<Applicant> UpdateApplicantAsync(Applicant newApplicant);
        Task<Applicant> DeleteApplicantAsync(Applicant newApplicant);
        bool IsExitByEmail(string email);
        Task<int> SaveChangesAsync();
        Task<IDbContextTransaction> BeginTransactionAsync();
        Task<PaginatedList<Applicant>> GetApplicants(PageRequest pageRequest, bool usePaging = true);
    }
}
