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
        public string Name { get; private set; } = default!;
        public Guid CurriculumId {  get; private set; }
        public IEnumerable<Pratical> Praticals { get; private set; } = new Hashset<Pratical>();
        public IEnumerable<Exercise> Excercises { get; private set; } = new Hahset<Exercise>();
    }
    public Topic(string name, Guid curriculumid)
    {
        Name = name;
        CurriculumId = curriculumid;
    }
}
