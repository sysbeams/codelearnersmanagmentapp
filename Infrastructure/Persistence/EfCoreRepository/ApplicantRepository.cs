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
        private readonly ApplicationContext _context;

        public ApplicantRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Task<Applicant> CreateApplicant(Applicant newApplicant)
        {
            throw new NotImplementedException();
        }

        public async Task<Applicant> GetApplicantAsync(Expression<Func<Applicant, bool>> expression) 
                => await _context.Applicants.FirstOrDefaultAsync(expression);

        public bool IsExitByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
