using Domain.Common.Contracts;
namespace Domain.Aggreagtes.StaffAggregate
{
    public class NextOfKin : AuditableEntity<Guid>
    {
        public string FullName { get; private set; } = default!;
        public string Relationship { get; private set; } = default!;
        public string ContactNumber { get; private set; } = default!;

        #region Constructor
        public NextOfKin(string fullName, string relationship, string contactNumber)
        {
            FullName = fullName ?? throw new ArgumentNullException(nameof(fullName));
            Relationship = relationship ?? throw new ArgumentNullException(nameof(relationship));
            ContactNumber = contactNumber ?? throw new ArgumentNullException(nameof(contactNumber));
        }
        #endregion
    }
}




