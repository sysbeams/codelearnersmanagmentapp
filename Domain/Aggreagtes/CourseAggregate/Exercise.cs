using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common.Contracts;
using Domain.Exceptions;

namespace Domain.Aggreagtes.CourseAggregate
{
    public  class Exercise : AuditableEntity<Guid>
    {
        public string Name { get; private set; } = default!;
        public string Link { get; private set; }
        public string Content { get; private set; }
        public Guid TopicId { get; private set; }

        public Exercise(string name, Guid topicid, string link, string content)
        {
            if (topicid == Guid.Empty) throw new ArgumentNullOrEmptyException("Topic Id cannot be empty");
            if (string.IsNullOrEmpty(link)) throw new ArgumentNullOrEmptyException("Link cannot be null or empty");
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullOrEmptyException("Exercise name cannot be null or empty");
            if (string.IsNullOrEmpty(content)) throw new ArgumentNullOrEmptyException("Content cannot be null or empty");
            Name = name;
            TopicId = topicid;
            Link = link;
            Content = content;
        }
    }
    
}
