using Domain.Aggreagtes.Organization_Aggregate;
using Domain.Aggreagtes.StaffAggregate;
using Domain.Enums;
using Domain.ValueObjects;

namespace XUnitTest.DomainTest.StaffAggregateTest
{
    public class StaffTest
    {
        private ContactInformation CreateContactInformation()
        {
                 var address = Address.CreateAddress(
                 streetNo: 123,
                 streetName: "Gbonogun",
                 city: "Abeokuta",
                 state: "Ogun State",
                 country: "Nigeria"
                 );

            return  ContactInformation.CreateContactInformation(
                phoneNumber: "123456789",
                email: "john@example.com",
                address: address
            );
        }

        private NextOfKinDetails CreateNextOfKin()
        {
            var contactInformation = CreateContactInformation();

            return NextOfKinDetails.CreateNextOfKinDetails(
                nokFirstName: "Jane",
                nokLastName: "Doe",
                relationship: "Sister",
                contactInformation: contactInformation
            );
        }

        [Fact]
        public void Should_ThrowException_When_StaffNo_IsNull()
        {
            string staffNo = null;

            var exception = Assert.Throws<ArgumentNullException>(() =>
                new Staff(staffNo, "John", "Doe", Gender.Male, DateTime.Now, "john@example.com", "123456789",
                    CreateContactInformation(),
                    CreateNextOfKin(),
                    new BankDetails("Bank", "1234567890", "Branch"), null
                )
            );

            Assert.Equal("Staff number cannot be empty. (Parameter 'staffNo')", exception.Message);
        }


        [Fact]
        public void Should_ThrowException_When_Firstname_IsNull()
        {
            string firstname = null;

            var exception = Assert.Throws<ArgumentNullException>(() =>
                new Staff("123", firstname, "Doe", Gender.Male, DateTime.Now, "john@example.com", "123456789",
                          CreateContactInformation(),
                          CreateNextOfKin(),
                          new BankDetails("Bank", "1234567890", "Branch"),null)
            );

            Assert.Equal("Firstname cannot be empty. (Parameter 'firstname')", exception.Message);
        }

        [Fact]
        public void Should_ThrowException_When_PrimaryDepartment_IsNull()
        {

            var exception = Assert.Throws<ArgumentNullException>(() =>
                new Staff("123", "John", "Doe", Gender.Male, DateTime.Now, "john@example.com", "123456789",
                          CreateContactInformation(),
                          CreateNextOfKin(),
                          new BankDetails("Bank", "1234567890", "Branch"),
                          null)
            );

            Assert.Equal("Primary department is required. (Parameter 'primaryDepartment')", exception.Message);
        }
    }
}



