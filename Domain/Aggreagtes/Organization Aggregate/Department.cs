using Domain.Aggreagtes.StaffAggregate;
using Domain.Common.Contracts;

namespace Domain.Aggreagtes.Organization_Aggregate
{
    public class Department : AuditableEntity<Guid>
    {
        public required string Name { get; set; } 
        public required Organization Organization { get; set; }
        public required  Guid HeadOfStaffId  { get; set; }
        public ICollection<Staff> Staffs { get; set; } = new HashSet<Staff>();
        public ICollection<AdjuncStaff> AdjuncStaffs { get; set; } = new HashSet<AdjuncStaff>();

        public Department(string name, Guid headOfStaffId, Organization organization)
        {
            if (headOfStaffId == Guid.Empty)
            {
                throw new NullReferenceException($"Department {Name}  must have a Head of Staff before Creation.");
            }

            Name = name;
            HeadOfStaffId = headOfStaffId;
            Organization = organization;
        }

    }
}
