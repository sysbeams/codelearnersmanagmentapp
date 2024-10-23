using Domain.Aggreagtes.StudentAggregate;
using Domain.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggreagtes.ClassAggregate
{
    public class Attendance : AuditableEntity<Guid>
    {      
        public Class Class { get; private set; } 
        public List<Student> AttendanceList { get; private set; } 
        public List<Student> AbsentList { get; private set; }

        #region Constructor
        private Attendance() { }
        public Attendance( List<Student> attendanceList, List<Student> absentList)
        {
            AttendanceList = attendanceList ;
            AbsentList = absentList;
        }
        #endregion

        #region behaviour
        public void AddClass(DateTime scheduledDateTime, int duration, string topic, int staffId)
        {
            Class = new Class(scheduledDateTime, duration, topic, staffId);
        }

        public void MarkPresent(Student student)
        {
            if (AbsentList.Contains(student))
            {
                AbsentList.Remove(student);
            }
            if (!AttendanceList.Contains(student))
            {
                AttendanceList.Add(student);
            }
        }
      
        public void MarkAbsent(Student student)
        {
            if (AttendanceList.Contains(student))
            {
                AttendanceList.Remove(student);
            }
            if (!AbsentList.Contains(student))
            {
                AbsentList.Add(student);
            }
        }

        public void RemoveStudentFromAttendance(Student student)
        {
            AttendanceList.Remove(student);
            AbsentList.Remove(student);
        }
        #endregion
    }
}
