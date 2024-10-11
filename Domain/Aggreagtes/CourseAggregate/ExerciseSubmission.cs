using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common.Contracts;

namespace Domain.Aggreagtes.CourseAggregate
{
    public class ExerciseSubmission : AuditableEntity<Guid>
    {
        public Guid StudentId { get; private set;; }
        public Guid ExerciseId { get; private set; }
        public string Link { get; private set; }
        public string Content { get; private set; }
        public string Grade { get; private set; }
    }
    public ExcerciseSubmission(Guid studentid, Guid execiseid,string link,string content, string grade)
    {
        StudentId = studentid;
        ExerciseId = execiseid;
        Link = link;
        Content = content;
        Grade = grade;
    }
}
