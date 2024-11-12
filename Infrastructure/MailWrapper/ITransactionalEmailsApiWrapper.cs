using sib_api_v3_sdk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.MailWrapper
{
    public interface ITransactionalEmailsApiWrapper
    {
        CreateSmtpEmail SendTransacEmail(SendSmtpEmail email);
    }
}
