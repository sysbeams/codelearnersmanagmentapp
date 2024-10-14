using Domain.Common.Contracts;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggreagtes.StaffAggregate
{
    public class Benefit : AuditableEntity
    {
        public required string Name { get; set; } = default!;
        public decimal  Amount { get; private set; } = default!;
        public Frequency  Frequency { get; private set; } = default!;

        #region Construction
        private Benefit() { }
        internal Benefit(string name)
        {
            Name = name;
        }

        #endregion
    }
}
