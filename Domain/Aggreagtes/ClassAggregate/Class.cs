using Domain.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggreagtes.ClassAggregate
{
    public class Class : AuditableEntity<Guid>, IAggregateRoot
    {
       
        public DateTime ScheduledDateTime { get; private set; } 
        public int Duration { get; private set; } = default!;
        public string Topic { get; private set; } = default!;
        public int StaffId { get; private set; } = default!;

        #region Constructor
        private Class() { }

        public Class(DateTime scheduledDateTime, int duration, string topic, int staffId)
        {
            ScheduledDateTime = scheduledDateTime;
            Duration = duration;
            Topic = topic;
            StaffId = staffId;
        }
        #endregion
    }
}
