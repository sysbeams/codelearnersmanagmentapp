using Domain.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggreagtes.StaffAggregate
{
    public class AreaOfSpecialization : AuditableEntity
    {
        public string Name { get; private set; } = default!;

        #region
        private AreaOfSpecialization() { }
        internal AreaOfSpecialization(string name)
        {
            Name = name;
        }
        #endregion
    }
}
