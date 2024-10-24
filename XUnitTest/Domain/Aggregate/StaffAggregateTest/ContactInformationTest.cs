using Domain.Aggreagtes.StaffAggregate;
using Xunit;

namespace XUnitTest.DomainTest.StaffAggregateTest
{
    public class ContactInformationTest
    {

        [Fact]
        public void Should_CreateContactInformation_When_AllParametersAreValid()
        {
            // Arrange
            var contactInformation = new ContactInformation("1234567890", "test@example.com", "123 Main St");

            // Assert
            Assert.NotNull(contactInformation);
            Assert.Equal("1234567890", contactInformation.PhoneNumber);
            Assert.Equal("test@example.com", contactInformation.EmailAddress);
            Assert.Equal("123 Main St", contactInformation.PhysicalAddress);
        }
    }
}

