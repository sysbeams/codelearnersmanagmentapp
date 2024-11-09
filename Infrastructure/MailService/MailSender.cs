using Application.Mail;
using Application.Mail.Logging;
using Application.MailSender;
using Domain.Exceptions;
using Infrastructure.MailWrapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using sib_api_v3_sdk.Api;
using sib_api_v3_sdk.Client;
using sib_api_v3_sdk.Model;

namespace Infrastructure.MailService
{
    public class MailSender : IEmailSender
    {
        private EmailSettings _emailSettings { get; }
        private readonly ILoggerAdapter<MailSender> _logger;
        private readonly ITransactionalEmailsApiWrapper _transactionalEmailsApiWrapper;

        public MailSender(IOptions<EmailSettings> emailSettings,
            ILoggerAdapter<MailSender> logger, ITransactionalEmailsApiWrapper transactionalEmailsApiWrapper)
        {
            _emailSettings = emailSettings.Value;
            _logger = logger;
            _transactionalEmailsApiWrapper = transactionalEmailsApiWrapper;
            if (string.IsNullOrEmpty(_emailSettings.ApiKey))
            {
                throw new ArgumentNullOrEmptyException("API key for Brevo is not configured");
            }
            Configuration.Default.ApiKey.Add("api-key", _emailSettings.ApiKey);
        }

        public void SendEmail(Email email)
        {
           /* var apiInstance = new TransactionalEmailsApi();*/
            ValidateData(_emailSettings.SenderName, _emailSettings.SenderEmailID);
            SendSmtpEmailSender Sender = new SendSmtpEmailSender(_emailSettings.SenderName, _emailSettings.SenderEmailID);

            SendSmtpEmailTo receiver = new SendSmtpEmailTo(email.To);
            List<SendSmtpEmailTo> To = new List<SendSmtpEmailTo>();
            To.Add(receiver);

            string HtmlContent = null;
            /*string TextContent = message;*/

            try
            {
                var sendSmtpEmail = new SendSmtpEmail(Sender, To, null, null, HtmlContent, email.Body, email.Subject);
                CreateSmtpEmail result = /*apiInstance*/_transactionalEmailsApiWrapper.SendTransacEmail(sendSmtpEmail);

                _logger.LogInformation("Brevo response");
                /*Console.WriteLine("Brevo response" + result.ToJson());*/
            }
            catch (Exception e)
            {

                /* Console.WriteLine("We have an exception" + e.Message);*/
                _logger.LogError(e, "We have an exception");
            }
        }


        private void ValidateData(string senderName, string senderEmailId)
        {
            if (string.IsNullOrEmpty(senderName)) throw new ArgumentNullOrEmptyException("sender name is not configured");
            if (string.IsNullOrEmpty(senderEmailId)) throw new ArgumentNullOrEmptyException("email address is not configured");
        }
    }
}
