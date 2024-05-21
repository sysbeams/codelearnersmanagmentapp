using Domain.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggreagtes.CourseAggregate
{
    public class Course : AuditableEntity<Guid>, IAggregateRoot
    {
        public string Name { get; set; }

        public Course(string name) {
            Name = name;
        }
    }
}
