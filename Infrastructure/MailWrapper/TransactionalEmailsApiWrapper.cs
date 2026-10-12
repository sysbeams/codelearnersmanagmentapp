using sib_api_v3_sdk.Api;
using sib_api_v3_sdk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.MailWrapper
{
    public class TransactionalEmailsApiWrapper : ITransactionalEmailsApiWrapper
    {
        private readonly TransactionalEmailsApi _api = new TransactionalEmailsApi();
        public CreateSmtpEmail SendTransacEmail(SendSmtpEmail email)
        {
            return _api.SendTransacEmail(email);
        }
    }
}
