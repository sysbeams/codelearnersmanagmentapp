using Domain.Aggreagtes.StaffAggregate;

namespace XUnitTest.DomainTest.StaffAggregateTest
{
    public class ContactInformationTest
    {
        [Fact]
        public void Should_ThrowException_When_PhoneNumber_IsNull()
        {
            // Arrange
            string phoneNumber = null;

            // Act & Assert
            var exception = Assert.Throws<ArgumentNullException>(() =>
                new ContactInformation(phoneNumber, "john@example.com", "Address")
            );

            Assert.Equal("Phone number cannot be empty. (Parameter 'phoneNumber')", exception.Message);
        }

        [Fact]
        public void Should_ThrowException_When_Email_IsNull()
        {
            // Arrange
            string email = null;

            // Act & Assert
            var exception = Assert.Throws<ArgumentNullException>(() =>
                new ContactInformation("123456789", email, "Address")
            );

            Assert.Equal("Email cannot be empty. (Parameter 'email')", exception.Message);
        }

        [Fact]
        public void Should_ThrowException_When_Address_IsNull()
        {
            // Arrange
            string address = null;

            // Act & Assert
            var exception = Assert.Throws<ArgumentNullException>(() =>
                new ContactInformation("123456789", "john@example.com", address)
            );

            Assert.Equal("Address cannot be empty. (Parameter 'address')", exception.Message);
        }
    }
}
