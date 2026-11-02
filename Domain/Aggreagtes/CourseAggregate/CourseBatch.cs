using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common.Contracts;
using Domain.Enums;
using Domain.Exceptions;

namespace Domain.Aggreagtes.CourseAggregate
{
    public class CourseBatch : AuditableEntity<Guid>
    {
        public string BatchNo { get; private set; } = default!;
        public DateTime DateOpened { get; private set; }
        public DateTime DateClosed { get; private set; }
        public int Capacity { get; private set; }
        public Course Course { get; private set; }
        public IEnumerable<CourseMode> CourseModes { get; private set; } = [];

        public CourseBatch(string batchno, DateTime dateopened, DateTime dateclosed, int capacity,
            List<CourseMode> coursemodes)
        {
            if (string.IsNullOrEmpty(batchno)) throw new ArgumentNullOrEmptyException("Batch No cannot be null or empty");
            if (capacity <= 0) throw new ArgumentNullOrEmptyException("Capacity cannot be zero or less");
            if (dateopened == dateclosed || dateopened < DateTime.Now || dateclosed < dateopened)
                throw new ArgumentNullOrEmptyException("Date Opened cannot be same or greater than Date Closed");
            if (coursemodes == null || Enum.GetValues(typeof(CourseMode)).Cast<CourseMode>()
                .Intersect(coursemodes).Count() == 0)
                throw new ArgumentNullOrEmptyException("Course mode cannot be empty");
            BatchNo = batchno;
            DateOpened = dateopened;
            DateClosed = dateclosed;
            Capacity = capacity;
            CourseModes = coursemodes;
        }

        public void SetCourse(Course course)
        {
            Course = course ?? throw new ArgumentNullOrEmptyException("Course cannot be null");
        }

    }
}
