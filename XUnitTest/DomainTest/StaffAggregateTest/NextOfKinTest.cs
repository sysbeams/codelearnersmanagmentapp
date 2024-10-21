using Domain.Aggreagtes.StaffAggregate;
using System;
using Xunit;

namespace XUnitTest.DomainTest.StaffAggregateTest
{
    public class NextOfKinTest
    {
        [Fact]
        public void Should_ThrowException_When_Name_IsNull()
        {
            // Arrange
            string name = null;

            // Act & Assert
            var exception = Assert.Throws<ArgumentNullException>(() =>
                new NextOfKin(name, "Sister", "123456789")
            );

            Assert.Equal("Name cannot be empty. (Parameter 'name')", exception.Message);
        }

        [Fact]
        public void Should_ThrowException_When_Relationship_IsNull()
        {
            // Arrange
            string relationship = null;

            // Act & Assert
            var exception = Assert.Throws<ArgumentNullException>(() =>
                new NextOfKin("Jane Doe", relationship, "123456789")
            );

            Assert.Equal("Relationship cannot be empty. (Parameter 'relationship')", exception.Message);
        }

        [Fact]
        public void Should_ThrowException_When_PhoneNumber_IsNull()
        {
            // Arrange
            string phoneNumber = null;

            // Act & Assert
            var exception = Assert.Throws<ArgumentNullException>(() =>
                new NextOfKin("Jane Doe", "Sister", phoneNumber)
            );

            Assert.Equal("Phone number cannot be empty. (Parameter 'phoneNumber')", exception.Message);
        }
    }
}
