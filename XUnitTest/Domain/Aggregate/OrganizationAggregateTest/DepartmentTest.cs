using Domain.Aggreagtes.Organization_Aggregate;

namespace XUnitTest.Domain.Aggregate.OrganizationAggregateTest
{
    public class DepartmentTest
    {
        [Fact]
        public void Should_ThrowException_IfHeadOfStaffId_IsNot_ValidOrEmpty()
        {
            Guid headOfStaffId = Guid.Empty;
            var organization = new Organization
            { Name = "clh"};

            var exception = Assert.Throws<ArgumentException>(() => new Department("Data Science", organization, headOfStaffId)
            {
                Name = "Data Science",
                Organization = organization,
                HeadOfStaffId = headOfStaffId,
            });

            Assert.Contains("HeadOfStaffId must be a valid non-empty GUID.", exception.Message);
        }

        [Fact]
        public void Should_ThrowException_IfName_IsNull()
        {
            Guid headOfStaffId = Guid.NewGuid();
            Organization organization = null;

            var exception = Assert.Throws<ArgumentNullException>(() => new Department("Data Science", organization, headOfStaffId)
            {
                Name = "Data Science",
                Organization = organization,
                HeadOfStaffId = headOfStaffId,
            });

            Assert.Contains("Organization cannot be null.", exception.Message);
        }

    }
}
