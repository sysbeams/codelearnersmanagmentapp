using Domain.ValueObjects;
using Xunit;

namespace XUnitTest.DomainTest.StaffAggregateTest
{
    public class NextOfKinTest
    {
        [Fact]
        public void Should_CreateNextOfKin_When_ValidParameters()
        {
            string firstName = "Jane";
            string lastName = "Doe";
            string relationship = "Sister";
            var address = Address.CreateAddress(
               streetNo: 123,
               streetName: "Gbonogun",
               city: "Abeokuta",
               state: "Ogun State",
               country: "Nigeria"
               );
            var contactInformation = ContactInformation.CreateContactInformation("1234567890", "test@example.com", address);

            var nextOfKin = NextOfKinDetails.CreateNextOfKinDetails(firstName,lastName, relationship, contactInformation);

            Assert.Equal(firstName, nextOfKin.NokFirstName);
            Assert.Equal(lastName, nextOfKin.NokLastName);
            Assert.Equal(relationship, nextOfKin.Relationship);

            Assert.NotNull(nextOfKin.ContactInformation);
            Assert.Equal("1234567890", nextOfKin.ContactInformation.PhoneNumber);
            Assert.Equal("test@example.com", nextOfKin.ContactInformation.Email);
            Assert.Equal(123, nextOfKin.ContactInformation.Address.StreetNo);
            Assert.Equal("Gbonogun", nextOfKin.ContactInformation.Address.StreetName);
            Assert.Equal("Abeokuta", nextOfKin.ContactInformation.Address.City);
            Assert.Equal("Ogun State", nextOfKin.ContactInformation.Address.State);
            Assert.Equal("Nigeria", nextOfKin.ContactInformation.Address.Country);
        }
    }
}






