using Domain.Aggreagtes.Organization_Aggregate;
using Domain.Aggreagtes.StaffAggregate;
using Domain.Enums;

namespace XUnitTest.DomainTest.StaffAggregateTest
{
    public class StaffTest
    {

        [Fact]
        public void Should_ThrowException_When_StaffNo_IsNull()
        {
            // Arrange
            string staffNo = null;

            // Act & Assert
            var exception = Assert.Throws<ArgumentNullException>(() =>
                new Staff(staffNo, "John", "Doe", Gender.Male, DateTime.Now, "john@example.com", "123456789",
                    new ContactInformation("123456789", "john@example.com", "Address"),
                    new NextOfKin("Jane Doe", "Sister", "123456789"),
                    new BankDetails("Bank", "1234567890", "Branch"), null
                )
            );

            Assert.Equal("Staff number cannot be empty. (Parameter 'staffNo')", exception.Message);
        }


        [Fact]
        public void Should_ThrowException_When_Firstname_IsNull()
        {
            // Arrange
            string firstname = null;

            // Act & Assert
            var exception = Assert.Throws<ArgumentNullException>(() =>
                new Staff("123", firstname, "Doe", Gender.Male, DateTime.Now, "john@example.com", "123456789",
                          new ContactInformation("123456789", "john@example.com", "Address"),
                          new NextOfKin("Jane Doe", "Sister", "123456789"),
                          new BankDetails("Bank", "1234567890", "Branch"),null)
            );

            Assert.Equal("Firstname cannot be empty. (Parameter 'firstname')", exception.Message);
        }

        [Fact]
        public void Should_ThrowException_When_PrimaryDepartment_IsNull()
        {
            // Act & Assert
            var exception = Assert.Throws<ArgumentNullException>(() =>
                new Staff("123", "John", "Doe", Gender.Male, DateTime.Now, "john@example.com", "123456789",
                          new ContactInformation("123456789", "john@example.com", "Address"),
                          new NextOfKin("Jane Doe", "Sister", "123456789"),
                          new BankDetails("Bank", "1234567890", "Branch"),
                          null)
            );

            Assert.Equal("Primary department is required. (Parameter 'primaryDepartment')", exception.Message);
        }
    }
}



