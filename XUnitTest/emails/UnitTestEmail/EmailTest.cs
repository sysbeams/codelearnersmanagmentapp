using Application.Mail;
using Microsoft.Extensions.Logging;
using Moq;
using Infrastructure.MailService;
using Microsoft.Extensions.Options;
using Domain.Aggreagtes.CourseAggregate;
using Domain.Exceptions;
using Application.Mail.Logging;
using sib_api_v3_sdk.Api;
using sib_api_v3_sdk.Model;
using Infrastructure.MailWrapper;

namespace XUnitTest.emails.UnitTestEmail
{
    public class EmailTest
    {
        private readonly Mock<ILoggerAdapter<MailSender>> _mockLogger;
        private readonly Mock<IOptions<EmailSettings>> _mockEmailSettings;
        private readonly Mock<ITransactionalEmailsApiWrapper> _apiWrapperMock;
        private readonly Mock<IApiConfiguration> _apiConfiguration;

        MailSender _mailSender;
        Email email;
        public EmailTest()
        {
             _mockLogger = new Mock<ILoggerAdapter<MailSender>>();
             _mockEmailSettings = new Mock<IOptions<EmailSettings>>();
             _apiWrapperMock = new Mock<ITransactionalEmailsApiWrapper>();
             _apiConfiguration = new Mock<IApiConfiguration>();


            email = new Email
            {
                To = "patrick@gmail.com",
                Body = "Test body",
                Subject = "Test subject"
            };
        }
        [Fact]
        public void ConstructorShouldThrowArgumentNullOrEmptyException_WhenApiKeyIsNotConfigured()
        {

            //Arrange
            var mockLogger = new Mock<ILoggerAdapter<MailSender>>();
            var mockEmailSettings = new Mock<IOptions<EmailSettings>>();
            mockEmailSettings.Setup(x => x.Value)
               .Returns(new EmailSettings { ApiKey ="",
                   SenderEmailID = "trick@gmail.com", SenderName = "Christ" });
           

            //Act & Asset
            var exception = Assert.Throws<ArgumentNullOrEmptyException>(() =>
                   new MailSender(mockEmailSettings.Object, mockLogger.Object,
                   _apiWrapperMock.Object, _apiConfiguration.Object));

            Assert.NotNull(exception);
            Assert.IsType<ArgumentNullOrEmptyException>(exception);
            Assert.Equal("API key for Brevo is not configured", exception.Message);
            Assert.Contains("Brevo", exception.Message);
       
        }
        [Fact]

        public void MailSender_ShouldSendMail_SouldLogMessagesWhenInvokedWithValidInput_ApiKey_SenderEmail_SenderName()
        {
            _mockEmailSettings.Setup(x => x.Value)
                .Returns(new EmailSettings { ApiKey = "4a7-yJ6Ew81cSULzYKYh", 
                    SenderEmailID = "ogbodopatrick199@gmail.com", 
                    SenderName = "Christ" });
            _apiConfiguration.Setup(x => x.AddApiKey(It.IsAny<string>(), It.IsAny<string>()));
            _mailSender = new MailSender(_mockEmailSettings.Object, _mockLogger.Object, 
                _apiWrapperMock.Object, _apiConfiguration.Object);
            
            // Act
            _mailSender.SendEmail(email);

            // Assert

            _mockLogger.Verify(
             logger => logger.LogInformation(It.Is<string>(msg => msg.Contains("Brevo response"))),
             Times.Once
            );
            _apiConfiguration.Verify(x => x.AddApiKey("api-key", "4a7-yJ6Ew81cSULzYKYh"), Times.Once);

        }

        [Fact]

        public void MailSender_SouldLogErrorMessagesWhenInvokedWithValidInputAndNoInternetConnection_ApiKey_SenderEmail_SenderName()
        {
            _mockEmailSettings.Setup(x => x.Value)
                .Returns(new EmailSettings
                {
                    ApiKey = "4a7-yJ6Ew81cSULzYKYh",
                    SenderEmailID = "patrick@gmail.com",
                    SenderName = "Christ"
                });
           
             _apiWrapperMock.Setup(api => api.SendTransacEmail(It.IsAny<SendSmtpEmail>()))
             .Throws(new Exception("We have an exception"));
            _apiConfiguration.Setup(x => x.AddApiKey(It.IsAny<string>(), It.IsAny<string>()));
            _mailSender = new MailSender(_mockEmailSettings.Object, _mockLogger.Object, _apiWrapperMock.Object, _apiConfiguration.Object);
            // Mock the API instance to throw an exception
            
            // Act
            _mailSender.SendEmail(email);

            // Assert
            _mockLogger.Verify(
            logger => logger.LogError(
            It.Is<Exception>(ex => ex.Message.Contains("We have an exception")), // Verify exception is passed
            It.Is<string>(msg => msg.Contains("We have an exception"))
                ),
            Times.Once
                    );
            _apiConfiguration.Verify(x => x.AddApiKey("api-key", "4a7-yJ6Ew81cSULzYKYh"), Times.Once);

        }


        [Fact]
        public void MailSender_ShouldThrowArgumentNullOrEmptyException_WhenValidateDataIsInvokedWithInvalidSenderEmail()
        {
            
            // Provide email settings with dummy API key
            _mockEmailSettings.Setup(x => x.Value)
                .Returns(new EmailSettings { ApiKey = "4a7-yJ6Ew81cSULzYKYh", SenderEmailID= "",
                    SenderName="Christ" });
            var _apiWrapperMock = new Mock<ITransactionalEmailsApiWrapper>();
            _apiConfiguration.Setup(x => x.AddApiKey(It.IsAny<string>(), It.IsAny<string>()));

            _mailSender = new MailSender(_mockEmailSettings.Object, _mockLogger.Object, _apiWrapperMock.Object, _apiConfiguration.Object);

            //Act & Assert
            var exception = Assert.Throws<ArgumentNullOrEmptyException>(() =>
            _mailSender.SendEmail(email));
            
            Assert.NotNull(exception);
            Assert.IsType<ArgumentNullOrEmptyException>(exception);
            Assert.Equal("email address is not configured", exception.Message);
            Assert.Contains("email", exception.Message);
            _apiConfiguration.Verify(x => x.AddApiKey("api-key", "4a7-yJ6Ew81cSULzYKYh"), Times.Once);

        }

        [Fact]
        public void MailSender_ShouldThrowArgumentNullOrEmptyException_WhenValidateDataIsInvokedWithInvalidSenderName()
        {
            
            // Provide email settings with dummy API key
            _mockEmailSettings.Setup(x => x.Value)
                .Returns(new EmailSettings { ApiKey = "4a7-yJ6Ew81cSULzYKYh", SenderEmailID= "patrick@gmail.com",
                    SenderName="" });

            var _apiWrapperMock = new Mock<ITransactionalEmailsApiWrapper>();
            _apiConfiguration.Setup(x => x.AddApiKey(It.IsAny<string>(), It.IsAny<string>()));

            _mailSender = new MailSender(_mockEmailSettings.Object, _mockLogger.Object, _apiWrapperMock.Object, _apiConfiguration.Object);

            //Act & Assert
            var exception = Assert.Throws<ArgumentNullOrEmptyException>(() =>
            _mailSender.SendEmail(email));

            Assert.NotNull(exception);
            Assert.IsType<ArgumentNullOrEmptyException>(exception);
            Assert.Equal("sender name is not configured", exception.Message);
            Assert.Contains("name", exception.Message);
            _apiConfiguration.Verify(x => x.AddApiKey("api-key", "4a7-yJ6Ew81cSULzYKYh"), Times.Once);
        }

        
    }
}
