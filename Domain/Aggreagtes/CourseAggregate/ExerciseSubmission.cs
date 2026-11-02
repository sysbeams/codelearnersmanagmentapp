using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common.Contracts;
using Domain.Exceptions;

namespace Domain.Aggreagtes.CourseAggregate
{
    public class ExerciseSubmission : AuditableEntity<Guid>
    {
        public Guid StudentId { get; private set; }
        public Guid ExerciseId { get; private set; }
        public string Link { get; private set; }
        public string Content { get; private set; }
        public string Grade { get; private set; }

        public ExerciseSubmission(Guid studentid, Guid execiseid, string link, string content, string grade)
        {
            if (studentid == Guid.Empty) throw new ArgumentNullOrEmptyException("Course name cannot be empty");
            if (execiseid == Guid.Empty) throw new ArgumentNullOrEmptyException("Course name cannot be empty");
            if (string.IsNullOrEmpty(link)) throw new ArgumentNullOrEmptyException("Course name cannot be null or empty");
            if (string.IsNullOrEmpty(grade)) throw new ArgumentNullOrEmptyException("Course name cannot be null or empty");
            if (string.IsNullOrEmpty(content)) throw new ArgumentNullOrEmptyException("Course name cannot be null or empty");
            StudentId = studentid;
            ExerciseId = execiseid;
            Link = link;
            Content = content;
            Grade = grade;
        }
    }
    
}
