using Xunit;

namespace XUnitTest.DomainTest.StaffAggregateTest
{
    public class NextOfKinTest
    {
        [Fact]
        public void Should_ThrowException_When_Name_IsNull()
        {
            string name = null;

            var exception = Assert.Throws<ArgumentNullException>(() =>
                new NextOfKin(name, "Sister", "123456789")
            );

            Assert.Equal("Name cannot be null or empty. (Parameter 'name')", exception.Message);
        }

        [Fact]
        public void Should_CreateNextOfKin_When_ValidParameters()
        {
            string name = "Jane Doe";
            string relationship = "Sister";
            string phoneNumber = "123456789";

            var nextOfKin = new NextOfKin(name, relationship, phoneNumber);

            Assert.Equal(name, nextOfKin.Name);
            Assert.Equal(relationship, nextOfKin.Relationship);
            Assert.Equal(phoneNumber, nextOfKin.PhoneNumber);
        }
    }
}






