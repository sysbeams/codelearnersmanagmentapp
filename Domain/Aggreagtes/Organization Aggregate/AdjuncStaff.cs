using Domain.Common.Contracts;

namespace Domain.Aggreagtes.Organization_Aggregate
{
    public class AdjuncStaff : AuditableEntity<Guid>
    {
        public required Guid StaffId { get; set; } 
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan Duration { get; set; } = default!;
        public required Department Department  { get; set; }

    }
}
