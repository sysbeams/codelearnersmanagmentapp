using Domain.Aggreagtes.UserAggregate;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;

namespace Domain.Repositories
{
    public interface IUserRepository 
    {
        Task<int> SaveChangesAsync();
        bool IsExitByEmail(string email);
        Task<User> GetUserByAsync (Expression<Func<User, bool>> predicate);
        Task<User> RegisterUserAsync(User user);
        Task<IDbContextTransaction> BeginTransactionAsync(); 
        Task DeleteUserAsync(User user);
    }
}
