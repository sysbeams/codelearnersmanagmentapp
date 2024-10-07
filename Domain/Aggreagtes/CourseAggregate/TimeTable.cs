using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common.Contracts;

namespace Domain.Aggreagtes.CourseAggregate
{
    public class TimeTable : AuditableEntity<Guid>
    {
        public IEnumerable<Class> Classes { get; set; } = new List<Class>();
    }
}
