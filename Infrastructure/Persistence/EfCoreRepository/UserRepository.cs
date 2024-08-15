using Domain.Aggreagtes.UserAggregate;
using Domain.Paging;
using Domain.Repositories;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;

namespace Infrastructure.Persistence.EfCoreRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;
        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<User> GetUserByAsync(Expression<Func<User, bool>> predicate)
        {
            var user = await _context.Users.FirstOrDefaultAsync(predicate);
            return user;
        }

        public bool IsExitByEmail(string email) => _context.Students.Any(s => s.EmailAddress == email);

        public async Task<User> RegisterUserAsync(User user)
        {
           await _context.Users.AddAsync(user);
           return user;
        }

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }

        public async Task DeleteUserAsync(User user)
        {
            _context.Users.Remove(user);
            await SaveChangesAsync();
        }

        public async Task<User> Update(User user)
        {
          _context.Update(user);
            return user;
        }

        public async Task<PaginatedList<User>> GetAllAsync(PageRequest pageRequest, bool usePaging = true)
        {
            var query = _context.Users.AsQueryable();

            query = query.OrderBy(r => r.CreatedOn);

            var totalItemsCount = await query.CountAsync();
            if (usePaging)
            {
                var offset = (pageRequest.Page - 1) * pageRequest.PageSize;
                var result = await query.Skip(offset).Take(pageRequest.PageSize).ToListAsync();
                return result.ToPaginatedList(totalItemsCount, pageRequest.Page, pageRequest.PageSize);
            }
            else
            {
                var result = await query.ToListAsync();
                return result.ToPaginatedList(totalItemsCount, 1, totalItemsCount);
            }
        }
    }
}
