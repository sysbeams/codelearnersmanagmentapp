using Domain.Aggreagtes.StaffAggregate;
using System.Linq.Expressions;

namespace Domain.Repositories
{
    public interface IBankDetailsRepository
    {
        Task<BankDetails> CreateBankDetailsAsync(BankDetails details);
        Task<BankDetails> GetBankDetailsAsync(Expression<Func<BankDetails, bool>> expression);
        Task<IEnumerable<BankDetails>> GetAllBankDetailsAsync();
        void UpdateBankDetailsAsync(BankDetails detail);
        Task<int> SaveChangesAsync();
    }
}
