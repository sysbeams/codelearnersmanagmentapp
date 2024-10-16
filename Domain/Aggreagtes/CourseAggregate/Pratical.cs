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
        public string Name { get; private set; } = default!;
        public Guid TopicId { get; private set; }
        public string Link { get; private set; }
        public string Content { get; private set; }
    }
    public Pratical (string name, Guid topicId, string link, string content)
    {
        Name = name;
        Link = link;
        Content = content;
        TopicId = topicId;
    }
}
