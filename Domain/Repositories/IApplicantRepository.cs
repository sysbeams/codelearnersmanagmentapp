using Domain.Aggreagtes.ApplicantAggregate;
using Domain.Aggreagtes.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IApplicantRepository
    {
        Task<Applicant> CreateApplicant(Applicant newApplicant,User user);
        Task<Applicant> GetApplicantAsync(Expression<Func<Applicant, bool>> expression);
        bool IsExitByEmail(string email);
        Task<int> SaveChangesAsync();
    }
}
