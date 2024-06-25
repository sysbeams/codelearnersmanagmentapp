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
        private readonly ApplicationContext _applicationContext;
        public async Task<Applicant> CreateApplicant(Applicant newApplicant)
        {
            
            await _applicationContext.Applicants.AddAsync(newApplicant);
            return newApplicant;
        }

        public Task<Applicant> GetApplicantAsync(Expression<Func<Applicant, bool>> expression)
        {
            throw new NotImplementedException();
        }

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
