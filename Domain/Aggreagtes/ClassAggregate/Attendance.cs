using Domain.Aggreagtes.StudentAggregate;
using Domain.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggreagtes.ClassAggregate
{
    public class Attendance : AuditableEntity<Guid>, IAggregateRoot
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public Class Class { get; private set; } 
        public List<Student> AttendanceList { get; private set; } 
        public List<Student> AbsentList { get; private set; }

        #region Constructor
        private Attendance() { }
        public Attendance(Class classEntity, List<Student> attendanceList, List<Student> absentList)
        {
            Class = classEntity;
            AttendanceList = attendanceList ;
            AbsentList = absentList;
        }
        #endregion
    }
}
