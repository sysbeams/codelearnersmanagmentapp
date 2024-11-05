using Domain.Aggreagtes.ClassAggregate;
using Domain.Aggreagtes.StudentAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitTest.Domain.Aggregate.ClassAggregateTest
{
    public class AttendanceTests
    {
        [Fact]
        public void Constructor_ShouldThrowException_WhenClassIsNull()
        {
            var ex = Assert.Throws<ArgumentException>(() => new Attendance(null, new List<Student>(), new List<Student>()));
            Assert.Equal("Attendance must be attached to a class.", ex.Message);
        }

        [Theory]
        [InlineData(0, "Attendance must have at least one staff (teaching staff).")]
        [InlineData(-1, "Attendance must have at least one staff (teaching staff).")]
        public void Constructor_ShouldThrowException_WhenStaffIdInvalid(int staffId, string expectedMessage)
        {
            var classObj = new Class(DateTime.Now, 90, "Conditional Statement", staffId);
            var ex = Assert.Throws<ArgumentException>(() => new Attendance(classObj, new List<Student>(), new List<Student>()));
            Assert.Equal(expectedMessage, ex.Message);
        }

        [Fact]
        public void Constructor_ShouldInitializeProperties_WhenArgumentsValid()
        {
            var classObj = new Class(DateTime.Now, 90, "Biology", 1);
            var attendanceList = new List<Student> ();
            var attendance = new Attendance(classObj, attendanceList, new List<Student>());
            Assert.Equal(classObj, attendance.Class);
            Assert.Equal(attendanceList, attendance.AttendanceList);
        }
    }
}
