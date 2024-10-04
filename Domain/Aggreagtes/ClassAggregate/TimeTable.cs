using Domain.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggreagtes.ClassAggregate
{
    internal class TimeTable : AuditableEntity<Guid>, IAggregateRoot
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public List<Class> ClassList { get; set; } = default!;


        public TimeTable(List<Class> classList)
        {
            ClassList = classList;
        }

    }


}
