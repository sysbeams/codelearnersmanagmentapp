using Domain.Aggreagtes.CourseAggregate;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitTest.Domain.Aggregate.CourseAggregateTest.UnitTestCourseBatch
{
    public static class CourseBatchData
    {
        public static readonly Guid CurriculumId = new Guid("ff561594-ee6a-46af-963e-36571e2ff305");
        public static readonly string BatchNo = "12Clh";
        public static readonly DateTime DateOpened = DateTime.Now.AddHours(1);
        public static readonly DateTime DateClosed = DateTime.Now.AddHours(2);
        public static readonly int Capacity = 5;
        public static readonly IEnumerable<CourseMode> CourseModes = [];
    }
}
