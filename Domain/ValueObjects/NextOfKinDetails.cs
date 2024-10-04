using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public class NextOfKinDetails
    {
        public string NokFirstName { get; private set; } = default!;
        public string NokLastName { get; private set; } = default!;
        public string Relationship { get; private set; } = default!;
        public ContactInformation ContactInformation { get; private set; }

        #region Constructor
        private NextOfKinDetails() { }
        internal NextOfKinDetails(string nokFirstName, string nokLastName, string relationship, ContactInformation contactInformation)
        {
            NokFirstName = nokFirstName;
            NokLastName = nokLastName;
            Relationship = relationship;
            ContactInformation = contactInformation;
        }
        #endregion

        #region Behaviour
        public static NextOfKinDetails CreateNextOfKinDetails(string nokFirstName, string nokLastName, string relationship, ContactInformation contactInformation)
            => new NextOfKinDetails(nokFirstName, nokLastName, relationship, contactInformation);
        public void UpdateNokFirstName(string nokFirstName) => NokFirstName = nokFirstName;
        public void UpdateNokLastName(string nokLastName) => NokLastName = nokLastName;
        public void UpdateReationship(string reationship) => Relationship = reationship;
        public void UpdateContactInformation(ContactInformation contactInformation) => ContactInformation = contactInformation;
        public override int GetHashCode() => HashCode.Combine(NokFirstName, NokLastName, Relationship, ContactInformation);
        public override bool Equals(object obj)
        {
            if (obj is not NextOfKinDetails other) return false;
            return NokFirstName == other.NokFirstName &&
                NokLastName == other.NokLastName && 
                Relationship == other.Relationship &&
                ContactInformation.Equals(other.ContactInformation);
        }
        #endregion
    }
}
