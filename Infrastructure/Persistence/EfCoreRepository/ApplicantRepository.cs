using Domain.Aggreagtes.ApplicantAggregate;
using Domain.Aggreagtes.UserAggregate;
using Domain.Paging;
using Domain.Repositories;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;

namespace Infrastructure.Persistence.EfCoreRepository
{
    public class ApplicantRepository : IApplicantRepository
    {
        private readonly ApplicationContext _context;
        public ApplicantRepository(ApplicationContext context) => _context = context;
        public async Task<Applicant> CreateApplicantAsync(Applicant newApplicant)
        {
            await _context.Applicants.AddAsync(newApplicant);
            return newApplicant;
        }

        public async Task<Applicant?> GetApplicantAsync(Expression<Func<Applicant, bool>> expression)
        {
            var applicant = await _context.Applicants
                .Include(a => a.User)
                .Include(a => a.Applications)
                .ThenInclude(a => a.Assessment)
                .FirstOrDefaultAsync(expression);
            return applicant;
        }

        public bool IsExitByEmail(string email) => _context.Applicants.Any(s => s.EmailAddress == email);

        public async Task<IDbContextTransaction> BeginTransactionAsync() => await _context.Database.BeginTransactionAsync();


        public async Task<Applicant> GetApplicantByIdAsync(Guid applicantId)
        {
            var applicant = await _context
                .Applicants.Include(a => a.User)
                .Include(a => a.Applications)
                .ThenInclude(a => a.Assessment)
                .FirstOrDefaultAsync(a => a.Id == applicantId);
            return applicant;
        }

        public async Task<Applicant> UpdateApplicantAsync(Applicant newApplicant)
        {
            _context.Applicants.Update(newApplicant);
            return newApplicant;
        }

        public async Task<Applicant> DeleteApplicantAsync(Applicant newApplicant)
        {
           _context.Applicants.Remove(newApplicant);
            return newApplicant;
        }

        public async Task<PaginatedList<Applicant>> GetApplicants(PageRequest pageRequest, bool usePaging = true)
        {
            var query = _context.Applicants
                .Include(a => a.User)
                .Include(a => a.Applications)
                .ThenInclude(a => a.Assessment).AsQueryable();

            query = query.OrderBy(a => a.FirstName);

            var totalItemsCount = await query.CountAsync();

            if (usePaging)
            {
                var offSet = pageRequest.PageSize * (pageRequest.Page - 1);
                var result = await query.Skip(offSet).Take(pageRequest.PageSize).ToListAsync();
                return result.ToPaginatedList(totalItemsCount, pageRequest.Page, pageRequest.PageSize);
            }
            else
            {
                var result = await query.ToListAsync();
                return result.ToPaginatedList(totalItemsCount, 1, totalItemsCount);
            }
        }

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
