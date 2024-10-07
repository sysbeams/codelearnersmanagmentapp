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
        public string Link { get; set; }
        public string Content { get; set; }
    }
    public Pratical (string name, Guid topicId, string link, string content)
    {
        Name = name;
        Link = link;
        Content = content;
        TopicId = topicId;
    }
}
