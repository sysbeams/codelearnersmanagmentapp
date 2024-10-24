using Domain.Aggreagtes.StaffAggregate;

namespace XUnitTest.DomainTest.StaffAggregateTest
{
    public class EmploymentContractTest
    {
        [Fact]
        public void Should_ThrowException_When_OrganizationId_IsEmpty()
        {
            // Arrange
            Guid organizationId = Guid.Empty;
            decimal salary = 5000;
            string benefits = "Health Insurance";
            string deductions = "Tax";
            DateTime startDate = DateTime.Now;

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() =>
                new EmploymentContract(organizationId, salary, benefits, deductions, startDate)
            );

            Assert.Equal("Organization ID must be a valid GUID. (Parameter 'organizationId')", exception.Message);
        }

        [Fact]
        public void Should_ThrowException_When_Salary_IsNegative()
        {
            // Arrange
            decimal salary = -1000;
            Guid organizationId = Guid.NewGuid();
            string benefits = "Health Insurance";
            string deductions = "Tax";
            DateTime startDate = DateTime.Now;

            // Act & Assert
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() =>
                new EmploymentContract(organizationId, salary, benefits, deductions, startDate)
            );

            Assert.Equal("Salary must be a positive value. (Parameter 'salary')", exception.Message);
        }

        [Fact]
        public void Should_ThrowException_When_Benefits_IsNull()
        {
            // Arrange
            string benefits = null;
            Guid organizationId = Guid.NewGuid();
            decimal salary = 5000;
            string deductions = "Tax";
            DateTime startDate = DateTime.Now;

            // Act & Assert
            var exception = Assert.Throws<ArgumentNullException>(() =>
                new EmploymentContract(organizationId, salary, benefits, deductions, startDate)
            );

            Assert.Equal("Benefits cannot be empty. (Parameter 'benefits')", exception.Message);
        }

        [Fact]
        public void Should_ThrowException_When_Deductions_IsNull()
        {
            // Arrange
            string deductions = null;
            Guid organizationId = Guid.NewGuid();
            decimal salary = 5000;
            string benefits = "Health Insurance";
            DateTime startDate = DateTime.Now;

            // Act & Assert
            var exception = Assert.Throws<ArgumentNullException>(() =>
                new EmploymentContract(organizationId, salary, benefits, deductions, startDate)
            );

            Assert.Equal("Deductions cannot be empty. (Parameter 'deductions')", exception.Message);
        }

        [Fact]
        public void Should_ThrowException_When_StartDate_IsInThePast()
        {
            // Arrange
            Guid organizationId = Guid.NewGuid();
            decimal salary = 5000;
            string benefits = "Health Insurance";
            string deductions = "Tax";
            DateTime startDate = DateTime.Now.AddDays(-1); // Past date

            // Act & Assert
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() =>
                new EmploymentContract(organizationId, salary, benefits, deductions, startDate)
            );

            Assert.Equal("Start date must be today or in the future. (Parameter 'startDate')", exception.Message);
        }
    }
}







