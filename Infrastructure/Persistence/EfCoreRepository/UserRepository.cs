using Domain.Aggreagtes.UserAggregate;
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
    public class UserRepository(ApplicationContext applicationContext) : IUserRepository
    {
        private readonly ApplicationContext _context;
        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }
        public Task<User> GetUserByAsync(Expression<Func<User, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool IsExitByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<User> RegisterUserAsync(User user)
        {
           await _context.AddAsync(user);
           return user;
        }

        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
