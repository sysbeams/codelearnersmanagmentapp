using Domain.Aggreagtes.ApplicantAggregate;
using Domain.Aggreagtes.UserAggregate;
using Domain.Paging;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;

namespace Domain.Repositories
{
    public interface IUserRepository 
    {
        bool IsExitByEmail(string email);
        Task<User> GetUserByAsync (Expression<Func<User, bool>> predicate);
        Task<User> RegisterUserAsync(User user);
        Task<User> Update(User user);
        Task<PaginatedList<User>> GetAllAsync(PageRequest pageRequest, bool usePaging = true);
        Task<IDbContextTransaction> BeginTransactionAsync(); 
        Task DeleteUserAsync(User user);
    }
}
