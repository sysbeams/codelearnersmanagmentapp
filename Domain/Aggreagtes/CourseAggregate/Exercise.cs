using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common.Contracts;

namespace Domain.Aggreagtes.CourseAggregate
{
    public  class Exercise : AuditableEntity<Guid>
    {
        public string Name { get; private set; } = default!;
        public string Link { get; private set; }
        public string Content { get; private set; }
        public Guid TopicId { get; private set; }

    }
    public Exercise(string name , Guid topicid, string link, string content)
    {
        Name = name;
        TopicId = topicid;
        Link = link;
        Content = content;
    }
}
