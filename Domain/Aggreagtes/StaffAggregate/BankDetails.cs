using Domain.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggreagtes.StaffAggregate
{
    public class BankDetails : AuditableEntity
    {
        public long AccountNumber { get; private set; } = default!;
        public string BankName { get; private set; } = default!;

        #region Constructor
        private BankDetails() { }
        internal BankDetails(long accountNumber, string bankName)
        {
            AccountNumber = accountNumber;
            BankName = bankName;
        }
        #endregion
    }
}
