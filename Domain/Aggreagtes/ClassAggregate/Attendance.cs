using Domain.Aggreagtes.StaffAggregate;
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
        public List<Staff> StaffAttendanceList { get; private set; }

        #region Constructor
        private Attendance() { }
        public Attendance(Class classObj, List<Student> attendanceList, List<Student> absentList)
        {
            if (classObj == null)
            {
                throw new ArgumentNullException("Attendance must be attached to a class.");
            }

            if (classObj.StaffId == Guid.Empty)
            {
                throw new ArgumentNullException("Attendance must have at least one staff (teaching staff).");
            }
            Class = classObj ?? throw new ArgumentNullException(nameof(classObj));
            AttendanceList = attendanceList ?? new List<Student>();
            AbsentList = absentList ?? new List<Student>();
        }
        #endregion

        #region behaviour
        public void MarkStudentAttendance(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            if (!AttendanceList.Contains(student))
            {
                AttendanceList.Add(student);
                AbsentList.Remove(student);
            }
        }

        public void MarkStaffAttendance(Staff staff)
        {
            if (staff == null)
            {
                throw new ArgumentNullException(nameof(staff));
            }

            if (!StaffAttendanceList.Contains(staff))
            {
                StaffAttendanceList.Add(staff);
            }
            if (StaffAttendanceList.Count == 0)
            {
                throw new InvalidOperationException("There must always be at least one staff member in attendance.");
            }
        }

        public void AddClass(DateTime scheduledDateTime, int duration, string topic, Guid staffId)
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
