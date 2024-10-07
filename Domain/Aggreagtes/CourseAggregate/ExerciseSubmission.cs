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
        public Guid StudentId { get; set; }
        public Guid ExerciseId { get; set; }
        public string Link { get; set; }
        public string Content { get; set; }
        public string Grade { get; set; }
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
