using Domain.Aggreagtes.ApplicantAggregate;
using Domain.Aggreagtes.CourseAggregate;
using Domain.Enums;
using Domain.Exceptions;
using Domain.ValueObjects;
using System;


namespace XUnitTest.Domain.Aggregate.ApplicantAggregateTest.UnitTestApplicant
{
    public class ApplicantTest
    {
        private readonly Applicant applicant;
        Assessment assessment;
        NextOfKinDetails nextOfKin;
        public ApplicantTest()
        {
            var address = new Address(ApplicantData.streetNo, ApplicantData.streetName, ApplicantData.city, ApplicantData.state,
                ApplicantData.country);
            var contactInfo = new ContactInformation("0908786", "win@gmail.com", address);
            nextOfKin = new NextOfKinDetails("James", "jude", "single",contactInfo);

            applicant = new Applicant(ApplicantData.firstName, ApplicantData.lastName, ApplicantData.middleName, Gender.Male,
                ApplicantData.phonenumber, ApplicantData.emailAddress,
                ApplicantData.userId, ApplicantData.streetNo, ApplicantData.streetName, ApplicantData.city,
                ApplicantData.state, ApplicantData.country, nextOfKin);

                assessment = new Assessment(new DateTime(2025, 11, 10, 12, 0, 0), AssessmentStatus.New, AssessmentMode.Online, AssessmentType.Exam);
        }

        [Fact]

        public void AddNewApplicant_ConstructorShouldSetProperties_WhenValidParametersAreProvided()
        {
            //Arrange
            
            //Act 
            
            //Assert

            Assert.Equal(ApplicantData.firstName, applicant.FirstName, ignoreCase: true);
            Assert.Contains("Christy", applicant.Fullname);
            Assert.Contains("Patrick", applicant.Fullname);
            Assert.EndsWith("Noah", applicant.Fullname);
            Assert.Equal(ApplicantData.lastName, applicant.LastName);
            Assert.Equal(ApplicantData.phonenumber, applicant.PhoneNumber);
            Assert.Equal(ApplicantData.emailAddress, applicant.EmailAddress);
            Assert.Equal(ApplicantData.userId, applicant.UserId);
        }

        [Theory]
        [InlineData("firstName", null, "00000000-0000-0000-0000-000000000000", "First name cannot be null or start with an empty space")]
        [InlineData("lastName", " ", "00000000-0000-0000-0000-000000000000", "Last name cannot be null or start with an empty space")]
        [InlineData("middleName", " ", "00000000-0000-0000-0000-000000000000", "Middle name cannot be null or start with an empty space")]
        [InlineData("phoneNumber", null, "00000000-0000-0000-0000-000000000000", "Phonenumber cannot be null or start with an empty space")]
        [InlineData("emailAddress", null, "00000000-0000-0000-0000-000000000000", "Email address cannot be null or start with an empty space")]
        [InlineData("userId"," ", "00000000-0000-0000-0000-000000000000", "User id cannot be empty")]
        public void AddNewApplicant_ConstructorShouldThrowArgumentNullOrWhiteSpaceException_WhenAnyInputParameterIsNotProvided(string type,
            string value, string id, string expectedMessage)
        {
            //Arrange

            //Act 
            Guid userid = Guid.Parse(id);
            var exception = AssertThrowsArgumentNullOrWhitespaceException(type, value, userid);
            //Assert

            Assert.NotNull(exception);
            Assert.IsType<ArgumentNullOrWhiteSpaceException>(exception);
            Assert.Contains("empty", exception.Message);
            Assert.Equal(expectedMessage, exception.Message);
        }

        private ArgumentNullOrWhiteSpaceException AssertThrowsArgumentNullOrWhitespaceException(string type, string value, Guid userid)
        {
            return type switch
            {
                "firstName" => Assert.Throws<ArgumentNullOrWhiteSpaceException>(() =>
                    new Applicant(value, ApplicantData.lastName, ApplicantData.middleName, Gender.Male, ApplicantData.phonenumber,
                    ApplicantData.emailAddress, ApplicantData.userId, ApplicantData.streetNo, ApplicantData.streetName,
                    ApplicantData.city, ApplicantData.state, ApplicantData.country, nextOfKin)),

                "lastName" => Assert.Throws<ArgumentNullOrWhiteSpaceException>(() =>
                new Applicant(ApplicantData.lastName, value, ApplicantData.middleName, Gender.Male, ApplicantData.phonenumber,
                    ApplicantData.emailAddress, ApplicantData.userId, ApplicantData.streetNo, ApplicantData.streetName,
                    ApplicantData.city, ApplicantData.state, ApplicantData.country, nextOfKin)),

                "middleName" => Assert.Throws<ArgumentNullOrWhiteSpaceException>(() =>
                   new Applicant(ApplicantData.lastName, ApplicantData.lastName, value, Gender.Male, ApplicantData.phonenumber,
                    ApplicantData.emailAddress, ApplicantData.userId, ApplicantData.streetNo, ApplicantData.streetName,
                    ApplicantData.city, ApplicantData.state, ApplicantData.country, nextOfKin)),

                "phoneNumber" => Assert.Throws<ArgumentNullOrWhiteSpaceException>(() =>
                    new Applicant(ApplicantData.lastName, ApplicantData.lastName, ApplicantData.middleName, Gender.Male, value,
                    ApplicantData.emailAddress, ApplicantData.userId, ApplicantData.streetNo, ApplicantData.streetName,
                    ApplicantData.city, ApplicantData.state, ApplicantData.country, nextOfKin)),

                "emailAddress" => Assert.Throws<ArgumentNullOrWhiteSpaceException>(() =>
                    new Applicant(ApplicantData.lastName, ApplicantData.lastName, ApplicantData.middleName, Gender.Male, ApplicantData.phonenumber,
                    value, ApplicantData.userId, ApplicantData.streetNo, ApplicantData.streetName,
                    ApplicantData.city, ApplicantData.state, ApplicantData.country, nextOfKin)),

                "userId" => Assert.Throws<ArgumentNullOrWhiteSpaceException>(() =>
                    new Applicant(ApplicantData.lastName, ApplicantData.lastName, ApplicantData.middleName, Gender.Male, ApplicantData.phonenumber,
                    ApplicantData.emailAddress, userid, ApplicantData.streetNo, ApplicantData.streetName,
                    ApplicantData.city, ApplicantData.state, ApplicantData.country, nextOfKin)),

                _ => throw new ArgumentNullOrWhiteSpaceException("Invalid type specified")
            };
        }

        [Fact]

        public void AddAddress_ShouldThrowInvalidAddressUpdateException_WhenInvokeMoreThanOnes()
        {
            //Act 

            //Assert
            var exception = Assert.Throws<InvalidAddressUpdateException>(() =>
             applicant.AddAddress(ApplicantData.streetNo, ApplicantData.streetName,
                ApplicantData.city, ApplicantData.state, ApplicantData.country));

            Assert.NotNull(exception);
            Assert.IsType<InvalidAddressUpdateException>(exception);
            Assert.Equal($"The student {applicant.Fullname} has address. Try update", exception.Message);
        }

        [Fact]

        public void AddApplication_ShouldAddNewApplication_WhenInvokeWithProvidedParameter()
        {
            //Act 
            Guid batchId = Guid.NewGuid();
            Guid courseId = Guid.NewGuid();

            Applications application = new Applications(batchId, courseId, CourseMode.Physical, applicant, assessment);

            //Assert

            Assert.Equal(ApplicantData.firstName, applicant.FirstName, ignoreCase: true);
            Assert.Contains("Christy", applicant.Fullname);
            Assert.Contains("Patrick", applicant.Fullname);
            Assert.EndsWith("Noah", applicant.Fullname);
            Assert.Equal(batchId, application.BatchId);
            Assert.Equal(applicant , application.Applicant);
            Assert.Equal(CourseMode.Physical, application.CourseMode);
            Assert.Equal(AssessmentStatus.New, application.Assessment.AssessmentStatus);
        }
        [Fact]
        public void AddNewApplicant_ConstructorShouldThrowArgumentNullOrEmptyException_WhenApplicationObjectIsNull()
        {
            //Arrange

            //Act & Assert
            var exception = Assert.Throws<ArgumentNullOrEmptyException>(() =>
             applicant.AddApplication(null));

            Assert.NotNull(exception);
            Assert.IsType<ArgumentNullOrEmptyException>(exception);
            Assert.Contains("Application", exception.Message);
            Assert.Equal("Application cannot be null", exception.Message);
        }
        [Fact]
        public void SubmitAssessment_WhenAssessmentIsTaken_AssessmentSatusShouldBeMarkedTaken()
        {
            //Arrange
            Guid batchId = Guid.NewGuid();
            Guid courseId = Guid.NewGuid();

            //Act 

            Applications application = new Applications(batchId, courseId, CourseMode.Physical, applicant, assessment);

            applicant.SubmitAssessment(application.Id);
            //Assert

            Assert.Equal(AssessmentStatus.Taken , application.Assessment.AssessmentStatus);
            
        }

        [Fact]
        public void SubmitAssessment_ShouldThrowArgumentNullOrEmptyException_WhenApplicationObjectIsNull()
        {
            //Arrange
            Guid batchId = Guid.NewGuid();
            Guid courseId = Guid.NewGuid();
            //Act & Assert
            
            Applications application = new Applications(batchId, courseId, CourseMode.Physical, applicant, assessment);
            var exception = Assert.Throws<ArgumentNullOrEmptyException>(() =>
             applicant.SubmitAssessment(Guid.NewGuid()));

            Assert.NotNull(exception);
            Assert.IsType<ArgumentNullOrEmptyException>(exception);
            Assert.Contains("Application", exception.Message);
            Assert.Equal("Application not found.", exception.Message);
        }


        [Fact]
        public void ChangeStatus_ShouldThrowArgumentNullOrEmptyException_WhenAssessmentTakenCannotBeCancelled()
        {
            //Arrange
            Guid batchId = Guid.NewGuid();
            Guid courseId = Guid.NewGuid();
            //Act 
            Applications application = new Applications(batchId, courseId, CourseMode.Physical, applicant, assessment);
            applicant.SubmitAssessment(application.Id);
            // Assert
            var exception = Assert.Throws<ArgumentNullOrEmptyException>(() =>
             applicant.ChangeStatus(ApplicationStatus.Cancelled,application.Id));

            Assert.NotNull(exception);
            Assert.IsType<ArgumentNullOrEmptyException>(exception);
            Assert.Contains("assessment", exception.Message);
            Assert.Equal("An application with an assessment that has been taken cannot be cancelled.", exception.Message);
        }

        [Fact]
        public void SetResult_ShouldThrowArgumentNullOrEmptyException_ResultCannotBeStToPassOrFailBeforeTakenAssessment()
        {
            //Arrange
            Guid batchId = Guid.NewGuid();
            Guid courseId = Guid.NewGuid();
            //Act 
            Applications application = new Applications(batchId, courseId, CourseMode.Physical, applicant, assessment);
            // Assert
            var exception = Assert.Throws<ArgumentNullOrEmptyException>(() =>
             applicant.SetResult(application.Id, AssessmentResult.Pass));

            Assert.NotNull(exception);
            Assert.IsType<ArgumentNullOrEmptyException>(exception);
            Assert.Contains("assessment", exception.Message);
            Assert.Equal("Cannot set result to pass or fail before the assessment is taken.", exception.Message);
        }

        
        [Fact]
        public void SetResult_ShouldSetResultToPassOrFailBeforeTakenAssessment()
        {
            //Arrange
            Guid batchId = Guid.NewGuid();
            Guid courseId = Guid.NewGuid();
            //Act 
            Applications application = new Applications(batchId, courseId, CourseMode.Physical, applicant, assessment);
            applicant.SubmitAssessment(application.Id);
            applicant.SetResult(application.Id, AssessmentResult.Pass);

            // Assert
            Assert.Equal(AssessmentResult.Pass,application.Assessment.AssessmentResult);
        }
    }
}
