using Domain.Aggreagtes.ApplicantAggregate;
using Domain.Repositories;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
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
        private readonly ApplicationContext _applicationContext;
        public async Task<Applicant> CreateApplicant(Applicant newApplicant)
        private readonly ApplicationContext _context;

        public ApplicantRepository(ApplicationContext context)
        {
            
            await _applicationContext.Applicants.AddAsync(newApplicant);
            return newApplicant;
            _context = context;
        }

        public Task<Applicant> GetApplicantAsync(Expression<Func<Applicant, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task<Applicant> GetApplicantAsync(Expression<Func<Applicant, bool>> expression) 
                => await _context.Applicants.FirstOrDefaultAsync(expression);

        public bool IsExitByEmail(string email) => _context.Students.Any(s => s.EmailAddress == email);

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

    }
}
