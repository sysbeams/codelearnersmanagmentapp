using Domain.Aggreagtes.UserAggregate;
using Domain.Repositories;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
    }
}
