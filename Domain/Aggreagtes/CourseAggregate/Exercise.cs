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
        public string Name { get; set; } = default!;
        public string Grade { get; set; } = default!;
        public Guid TopicId { get; set; }

    }
    public Exercise(string name , string grade, Guid topicid)
    {
        Name = name;
        Grade = grade;
        TopicId = topicid;
    }
}
