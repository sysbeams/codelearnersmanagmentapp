using Application.Emails;
using Application.EmailSender;
using Domain.Aggreagtes.ResultAggregate;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using sib_api_v3_sdk.Api;
using sib_api_v3_sdk.Client;
using sib_api_v3_sdk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EmailService
{
    public class EmailSender : IEmailSender
    {
        private EmailSettings _emailSettings { get; }
        private readonly IConfiguration _configuration;
        private readonly ILogger<EmailSender> _logger;

        public EmailSender(IOptions<EmailSettings> emailSettings,
            IConfiguration configuration,
            ILogger<EmailSender> logger)
        {
            _emailSettings = emailSettings.Value;
            _configuration = configuration;
            _logger = logger;

            // Use the configuration to set the API key
            /*var apiKey = _configuration["BrevoApi:ApiKey"];*/
            if (string.IsNullOrEmpty(_emailSettings.ApiKey))
            {
                throw new ArgumentException("API key for Brevo is not configured");
            }
            Configuration.Default.ApiKey.Add("api-key", _emailSettings.ApiKey);
        }
        public void SendEmail(Email email)
        {
            var apiInstance = new TransactionalEmailsApi();

            SendSmtpEmailSender Sender = new SendSmtpEmailSender(_emailSettings.SenderName, _emailSettings.SenderEmailID);

            SendSmtpEmailTo receiver = new SendSmtpEmailTo(email.To);
            List<SendSmtpEmailTo> To = new List<SendSmtpEmailTo>();
            To.Add(receiver);

            string HtmlContent = null;
            /*string TextContent = message;*/


            try
            {
                var sendSmtpEmail = new SendSmtpEmail(Sender, To, null, null, HtmlContent, email.Body, email.Subject);
                CreateSmtpEmail result = apiInstance.SendTransacEmail(sendSmtpEmail);

                _logger.LogInformation("Brevo response" + result.ToJson());
                /*Console.WriteLine("Brevo response" + result.ToJson());*/
            }
            catch (Exception e)
            {

               /* Console.WriteLine("We have an exception" + e.Message);*/
                _logger.LogInformation("We have an exception" + e.Message);
            }
        }
    }
}
