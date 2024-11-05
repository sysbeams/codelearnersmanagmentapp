using Domain.Aggreagtes.ApplicantAggregate;
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
        public async Task<Applicant> CreateApplicant(Applicant newApplicant)
        {
            await _context.AddAsync(newApplicant);
            return newApplicant;
        }

        public async Task<Applicant> GetApplicantAsync(Expression<Func<Applicant, bool>> expression) 
                => await _context.Applicants.FirstOrDefaultAsync(expression);

        public bool IsExitByEmail(string email) => _context.Students.Any(s => s.EmailAddress == email);

        public async Task<IDbContextTransaction> BeginTransactionAsync() => await _context.Database.BeginTransactionAsync();


        public async Task<Applicant?> GetByIdAsync(Guid applicantId)
        {
            return await _context.Applicants.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == applicantId);
        }

        public async Task<PaginatedList<Applicant>> GetAllAsync(PageRequest pageRequest, bool usePaging = true)
        {
            var query = _context.Applicants.AsQueryable();

            query = query.OrderBy(r => r.CreatedOn);

            var totalItemsCount = await query.CountAsync();
            if (usePaging)
            {
                var offset = (pageRequest.Page - 1) * pageRequest.PageSize;
                var result = await query.AsNoTracking().Skip(offset).Take(pageRequest.PageSize).ToListAsync();
                return result.ToPaginatedList(totalItemsCount, pageRequest.Page, pageRequest.PageSize);
            }
            else
            {
                var result = await query.ToListAsync();
                return result.ToPaginatedList(totalItemsCount, 1, totalItemsCount);
            }
        }

        public async Task<Applicant> Update(Applicant applicant)
        {
            _context.Update(applicant);
            return applicant;
        }
    }
}
