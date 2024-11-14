using Domain.Aggreagtes.StaffAggregate;
using Domain.ValueObjects;
using Xunit;

namespace XUnitTest.DomainTest.StaffAggregateTest
{
    public class ContactInformationTest
    {

        [Fact]
        public void Should_CreateContactInformation_When_AllParametersAreValid()
        {
                var address = Address.CreateAddress(
                streetNo: 123,
                streetName: "Gbonogun",
                city: "Abeokuta",
                state: "Ogun State",
                country: "Nigeria"
                );
            var contactInformation = ContactInformation.CreateContactInformation("1234567890", "test@example.com", address);

            Assert.NotNull(contactInformation);
            Assert.Equal("1234567890", contactInformation.PhoneNumber);
            Assert.Equal("test@example.com", contactInformation.Email);
            Assert.Equal(address, contactInformation.Address);

            Assert.NotNull(contactInformation.Address);
            Assert.Equal(123, contactInformation.Address.StreetNo);
            Assert.Equal("Gbonogun", contactInformation.Address.StreetName);
            Assert.Equal("Abeokuta", contactInformation.Address.City);
            Assert.Equal("Ogun State", contactInformation.Address.State);
            Assert.Equal("Nigeria", contactInformation.Address.Country);
        }
    }
}

