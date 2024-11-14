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
        public static readonly DateTime DateOpened = new DateTime(2025, 11, 10, 12, 0, 0);
        public static readonly DateTime DateClosed = new DateTime(2026, 12, 1, 12, 0, 0);
        public static readonly int Capacity = 5;
        public static readonly IEnumerable<CourseMode> CourseModes = [];
    }
}
