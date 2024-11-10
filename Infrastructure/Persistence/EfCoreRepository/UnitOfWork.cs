using Domain.Repositories;
using Infrastructure.Persistence.Context;

namespace Infrastructure.Persistence.EfCoreRepository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context.ApplicationContext _context;

        public UnitOfWork(Context.ApplicationContext context)
        {
            _context = context;
        }
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
