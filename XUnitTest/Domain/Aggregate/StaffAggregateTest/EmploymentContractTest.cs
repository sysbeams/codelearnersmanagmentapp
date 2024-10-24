using Domain.Aggreagtes.StaffAggregate;
using Xunit;

namespace XUnitTest.DomainTest.StaffAggregateTest
{
    public class EmploymentContractTest
    {

        [Fact]
        public void Should_ThrowException_When_StartDate_IsDefault()
        {
            // Arrange
            Guid organizationId = Guid.NewGuid();
            DateTime startDate = default; // Invalid date

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() =>
                new EmploymentContract(organizationId, 50000m, "Health Insurance", "None", startDate)
            );

            Assert.Equal("StartDate must be a valid date. (Parameter 'startDate')", exception.Message);
        }

        [Fact]
        public void Should_CreateEmploymentContract_When_AllParametersAreValid()
        {
            // Arrange
            var organizationId = Guid.NewGuid();
            var employmentContract = new EmploymentContract(organizationId, 50000m, "Health Insurance", "None", DateTime.Now);

            // Assert
            Assert.NotNull(employmentContract);
            Assert.Equal(organizationId, employmentContract.OrganizationId);
            Assert.Equal(50000m, employmentContract.Salary);
            Assert.True(employmentContract.IsActive);
        }
    }
}
