using Domain.Common.Contracts;

namespace Domain.Aggreagtes.Organization_Aggregate
{
    public class Organization : AuditableEntity, IAggregateRoot
    {
        public required string Name { get; set; } 
        public ICollection<Department> Departments { get; set; } = new HashSet<Department>();
    }
}
