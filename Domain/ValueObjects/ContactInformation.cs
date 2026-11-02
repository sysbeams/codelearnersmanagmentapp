using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public class ContactInformation
    {
        public string PhoneNumber { get; private set; } = default!;
        public string Email { get; private set; } = default!;
        public Address Address { get; private set; }

        #region Constructor
        private ContactInformation() { }
        internal ContactInformation(string phoneNumber, string email, Address address)
        {
            PhoneNumber = phoneNumber;
            Email = email;
            Address = address;
        }
        #endregion

        #region Behaviour
        public static ContactInformation CreateContactInformation(string phoneNumber, string email, Address address) 
            => new ContactInformation(phoneNumber, email, address);
        public void UpdatePhoneNumber(string phoneNumber) => PhoneNumber = phoneNumber;
        public void UpdateEmail(string email) => Email = email;
        public void UpdateAddress(Address address) => Address = address;
        public override int GetHashCode() => HashCode.Combine(PhoneNumber, Email, Address);
        public override bool Equals(object obj)
        {
            if (obj is not ContactInformation other) return false;
            return PhoneNumber == other.PhoneNumber &&
                Email == other.Email &&
                Address.Equals(other.Address);
        }
        #endregion
    }
}
