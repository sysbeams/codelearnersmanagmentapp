using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common.Contracts;
using Domain.Exceptions;

namespace Domain.Aggreagtes.CourseAggregate
{
    public class Pratical : AuditableEntity<Guid>
    {
        public string Name { get; private set; } = default!;
        public Guid TopicId { get; private set; }
        public string Link { get; private set; }
        public string Content { get; private set; }

        public Pratical(string name, Guid topicId, string link, string content)
        {
            if (topicId == Guid.Empty) throw new ArgumentNullOrEmptyException("Topic Id cannot be empty");
            if (string.IsNullOrEmpty(link)) throw new ArgumentNullOrEmptyException("Link cannot be null or empty");
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullOrEmptyException("Pratical name cannot be null or empty");
            if (string.IsNullOrEmpty(content)) throw new ArgumentNullOrEmptyException("Content cannot be null or empty");
            Name = name;
            Link = link;
            Content = content;
            TopicId = topicId;
        }
    }
    
}
