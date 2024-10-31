using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common.Contracts;
using Domain.Exceptions;
using Domain.Paging;

namespace Domain.Aggreagtes.CourseAggregate
{
    public class Curriculum : AuditableEntity<Guid>
    {
        public Guid CourseId { get; private set; }
        public IReadOnlyList<Topic> Topics => _topics.AsReadOnly();
        private List<Topic> _topics = [];

        public Curriculum(Guid courseId, string topicname, string exercisename, string exerciselink, string exercisecontent)
        {
            if (courseId == Guid.Empty) throw new ArgumentNullOrEmptyException("Course ID is not a match");
            CourseId = courseId;
            AddTopic(topicname, exercisename, exerciselink, exercisecontent);
        }

        public void AddTopic(string name, string exercisename, string exerciselink, string exercisecontent)
        {
            Topic topic = new Topic(name, this.Id, exercisename, exerciselink, exercisecontent);
            ValidateTopic(topic);
        }

        public void ValidateTopic(Topic topic)
        {
            if (topic == null)
            {
                throw new ArgumentNullOrEmptyException("Topic cannot be null");
            }
            if (topic.CurriculumId != this.Id)
            {
                throw new ArgumentNullOrEmptyException("Topic Curriculum Id is not a match");
            }
            _topics.Add(topic);
        }

        public void RemoveTopic(Topic topic)
        {
            if (_topics.Count < 2) throw new OutOfSpecifiedRangeException("Topic cannot be less than 1");
            _topics.Remove(topic);
        }
    }

    
}
