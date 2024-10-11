using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common.Contracts;
using Domain.Aggreagtes.CourseAggregate.Enum;

namespace Domain.Aggreagtes.CourseAggregate
{
    public class CourseBatch : AuditableEntity<Guid>
    {
        public string BatchNo { get; private set; } = default!;
        public DateTime DateOpened { get; private set; }
        public DateTime DateClosed { get; private set; }
        public int Capacity { get; private set; }
        public IEnumerable<Course_Mode> CourseModes { get; private set; } 

        public CourseBatch(string batchno,DateTime dateopened,DateTime dateclosed,int capacity,List<Course_Mode> coursemodes)
        {
            BatchNo = batchno;
            DateOpened = dateopened;
            DateClosed = dateclosed;
            Capacity = capacity;
            CourseModes = coursemodes ?? new List<Course_Mode> (); 
        }

    }
}
