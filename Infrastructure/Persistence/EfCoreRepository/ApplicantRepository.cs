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
        public ApplicantRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<Applicant> CreateApplicant(Applicant newApplicant)
        {
            await _applicationContext.Applicants.AddAsync(newApplicant);
            return newApplicant;
        }
        private readonly ApplicationContext _context;

        public async Task<Applicant> GetApplicantAsync(Expression<Func<Applicant, bool>> expression) 
                => await _context.Applicants.FirstOrDefaultAsync(expression);

        public bool IsExitByEmail(string email) => _context.Students.Any(s => s.EmailAddress == email);

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

    }
}
