using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common.Contracts;
using Domain.Paging;

namespace Domain.Aggreagtes.CourseAggregate
{
    public class Curriculum : AuditableEntity<Guid>
    {
        public Guid CourseId { get; private set; }
        public IEnumerable<Topic> Topics {get; set; } = new Hashset<Topic>();
    }

    public Curriculum(Guid courseId)
    {
        CourseId = courseId;
    }
}
