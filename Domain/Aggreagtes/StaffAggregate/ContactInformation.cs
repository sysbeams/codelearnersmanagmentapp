using Domain.Common.Contracts;

namespace Domain.Aggreagtes.StaffAggregate
{
    public class ContactInformation : AuditableEntity<Guid>
    {
        public string PhoneNumber { get; private set; } = default!;
        public string EmailAddress { get; private set; } = default!;
        public string PhysicalAddress { get; private set; } = default!;

        #region Constructor
        public ContactInformation(string phoneNumber, string emailAddress, string physicalAddress)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new ArgumentException("Phone number cannot be null or empty.");
            if (string.IsNullOrWhiteSpace(emailAddress))
                throw new ArgumentException("Email address cannot be null or empty.");
            if (string.IsNullOrWhiteSpace(physicalAddress))
                throw new ArgumentException("Physical address cannot be null or empty.");

            PhoneNumber = phoneNumber;
            EmailAddress = emailAddress;
            PhysicalAddress = physicalAddress;
        }
        #endregion

        public void UpdateContactInformation(string phoneNumber, string emailAddress, string physicalAddress)
        {
            if (!string.IsNullOrWhiteSpace(phoneNumber))
                PhoneNumber = phoneNumber;

            if (!string.IsNullOrWhiteSpace(emailAddress))
                EmailAddress = emailAddress;

            if (!string.IsNullOrWhiteSpace(physicalAddress))
                PhysicalAddress = physicalAddress;
        }
    }
}

