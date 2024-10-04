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
        public Guid CourseId { get; set; }
        public IEnumerable<Topic> Topics {get; set;} 
    }

    public Curriculum(Guid courseId, IEnumerable<Topic> topics)
    {
        CourseId = courseId;
        Topics = topics ?? new List<Topic>();
    }
}
