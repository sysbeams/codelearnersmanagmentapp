using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common.Contracts;
using Domain.Paging;

namespace Domain.Aggreagtes.CourseAggregate
{
    public class Topic : AuditableEntity<Guid>
    {
        public string Name { get; set; } = default!;
        public Guid CurriculumId {  get; set; }
        public Guid CourseId { get; set; }
        public IEnumerable<Pratical> Praticals { get; set; } = new List<Pratical>();
        public IEnumerable<Exercise> Excercises { get; set; } = new List<Exercise>();
    }
    public Topic(string name, Guid curriculumid, Guid courseid)
    {
        Name = name;
        CurriculumId = curriculumid;
        CourseId = courseid;
    }
}
