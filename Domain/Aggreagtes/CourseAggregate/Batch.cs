using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common.Contracts;
using Domain.Aggreagtes.CourseAggregate.Enum;

namespace Domain.Aggreagtes.CourseAggregate
{
    public class Batch : AuditableEntity<Guid>
    {
        public string BatchNo { get; set; } = default!;
        public DateTime DateOpened { get; set; }
        public DateTime DateClosed { get; set; }
        public int Capacity { get; set; }
        public IEnumerable<Course_Mode> CourseModes { get; set; } 

        public Batch(string batchno,DateTime dateopened,DateTime dateclosed,int capacity,List<Course_Mode> coursemodes)
        {
            BatchNo = batchno;
            DateOpened = dateopened;
            DateClosed = dateclosed;
            Capacity = capacity;
            CourseModes = coursemodes ?? new List<Course_Mode> (); 
        }

    }
}
