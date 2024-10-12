using Domain.Aggreagtes.StudentAggregate;
using Domain.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggreagtes.ClassAggregate
{
    public class ClassActivity : AuditableEntity<Guid>
    {
        public Student Student { get; set; } = default!;
        public string ActivityType { get; set; } = default!;
        public Class Class { get; set; } 
        public decimal Grade { get; set; } = default!;

        #region constructor 
        private ClassActivity () { }
        public ClassActivity(Student student, string activityType,  decimal grade)
        {
            Student = student;
            ActivityType = activityType;
            Grade = grade;
        }
        #endregion

        #region behaviour
        public void AddClass(DateTime scheduledDateTime, int duration, string topic, int staffId)
        {
            Class = new Class(scheduledDateTime, duration, topic, staffId);
        }
        public void AddStudent (string studentNumber, string firstname, string lastname, string phoneNumber, string emailAddress)
        {
            Student = new Student (studentNumber,firstname,lastname,phoneNumber,emailAddress)
        }
        #endregion



    }
}
