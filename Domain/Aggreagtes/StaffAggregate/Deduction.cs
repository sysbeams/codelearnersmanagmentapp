using Domain.Common.Contracts;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggreagtes.StaffAggregate
{
    public class Deduction : AuditableEntity
    {
        public string Name { get; private set; } = default!;
        public decimal  Amount { get; private set; } = default!;
        public Frequency Frequency { get; private set; } = default!;

        #region Constructor
        private Deduction() { }
        internal Deduction(string name)
        {
            Name = name;
        }
        #endregion
    }
}
