using Domain.Aggreagtes.StaffAggregate;
using Domain.Repositories;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Persistence.EfCoreRepository
{
    public class BankDetailsRepository(ApplicationContext _context) : IBankDetailsRepository
    {
        public async Task<BankDetails> CreateBankDetailsAsync(BankDetails details)
        {
            await _context.BankDetails.AddAsync(details);
            return  details;
        }

        public async Task<IEnumerable<BankDetails>> GetAllBankDetailsAsync()
            => await _context.BankDetails.ToListAsync();

        public async Task<BankDetails?> GetBankDetailsAsync(Expression<Func<BankDetails, bool>> expression)
            => await _context.BankDetails.FirstOrDefaultAsync(expression);

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

        public void UpdateBankDetailsAsync(BankDetails detail)
        {
            _context.BankDetails.Update(detail);
        }
    }
}
