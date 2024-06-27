using Domain.Aggreagtes.ApplicantAggregate;
using Domain.Repositories;
using Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.EfCoreRepository
{
    public class ApplicantRepository : IApplicantRepository
    {
        private readonly ApplicationContext _context;

        public ApplicantRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Task<Applicant> CreateApplicant(Applicant newApplicant)
        {
            throw new NotImplementedException();
        }

        public Task<Applicant> GetApplicantAsync(Expression<Func<Applicant, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public bool IsExitByEmail(string email) => _context.Students.Any(s => s.EmailAddress == email);

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

    }
}
