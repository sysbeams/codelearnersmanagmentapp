using Application.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MailSender
{
    public interface IEmailSender
    {
        void SendEmail(Email email);
    }
}
