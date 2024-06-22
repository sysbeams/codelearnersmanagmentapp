using Domain.Aggreagtes.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IUserRepository 
    {
        Task<int> SaveChangesAsync();
        bool IsExitByEmail(string email);
        Task<User> GetUserByAsync (Expression<Func<User, bool>> predicate);
        Task<User> RegisterUserAsync(User user);
    }
}
