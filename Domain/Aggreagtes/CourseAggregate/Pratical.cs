using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common.Contracts;

namespace Domain.Aggreagtes.CourseAggregate
{
    public class Pratical : AuditableEntity<Guid>
    {
        public string Name { get; set; } = default!;
        public Guid TopicId { get; set; }
        public string Grade { get; set; }
    }
    public Pratical (string name, Guid topicId, string grade)
    {
        Name = name;
        Grade = grade;
        TopicId = topicId;
    }
}
