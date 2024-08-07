using Domain.Aggreagtes.ApplicantAggregate;
using Domain.Aggreagtes.UserAggregate;
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
            await _context.Applicants.AddAsync(newApplicant);
            return newApplicant;
        }

        public async Task<Applicant> GetApplicantAsync(Expression<Func<Applicant, bool>> expression) 
                => await _context.Applicants.FirstOrDefaultAsync(expression);

        public bool IsExitByEmail(string email) => _context.Students.Any(s => s.EmailAddress == email);

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
        public async Task<IDbContextTransaction> BeginTransactionAsync() => await _context.Database.BeginTransactionAsync();

        public async Task<IEnumerable<Applicant>> GetAllAsync() => await _context.Applicants.ToListAsync();
    }
}
