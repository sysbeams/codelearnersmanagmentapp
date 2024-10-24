using Domain.Aggreagtes.StaffAggregate;

namespace XUnitTest.DomainTest.StaffAggregateTest
{
    public class BankDetailsTest
    {
        [Fact]
        public void Should_ThrowException_When_BankName_IsNull()
        {
            // Arrange
            string bankName = null;

            // Act & Assert
            var exception = Assert.Throws<ArgumentNullException>(() =>
                new BankDetails(bankName, "1234567890", "Main Branch")
            );

            Assert.Equal("Bank name cannot be empty. (Parameter 'bankName')", exception.Message);
        }

        [Fact]
        public void Should_ThrowException_When_AccountNumber_IsNull()
        {
            // Arrange
            string accountNumber = null;

            // Act & Assert
            var exception = Assert.Throws<ArgumentNullException>(() =>
                new BankDetails("Bank", accountNumber, "Main Branch")
            );

            Assert.Equal("Account number cannot be empty. (Parameter 'accountNumber')", exception.Message);
        }

        [Fact]
        public void Should_ThrowException_When_Branch_IsNull()
        {
            // Arrange
            string branch = null;

            // Act & Assert
            var exception = Assert.Throws<ArgumentNullException>(() =>
                new BankDetails("Bank", "1234567890", branch)
            );

            Assert.Equal("Branch cannot be empty. (Parameter 'branch')", exception.Message);
        }
    }
}







