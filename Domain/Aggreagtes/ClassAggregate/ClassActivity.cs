using Domain.Aggreagtes.StudentAggregate;
using Domain.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggreagtes.ClassAggregate
{
    public class ClassActivity : AuditableEntity<Guid>, IAggregateRoot
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Student Student { get; set; } = default!;
        public string ActivityType { get; set; } = default!;
        public Class Class { get; set; } 
        public decimal Grade { get; set; } = default!;

        #region constructor 
        private ClassActivity () { }
        public ClassActivity(Student student, string activityType, Class classEntity, decimal grade)
        {
            Student = student;
            ActivityType = activityType;
            Class = classEntity;
            Grade = grade;
        }
        #endregion

    }
}
