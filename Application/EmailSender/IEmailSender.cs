using Application.Emails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.EmailSender
{
    public interface IEmailSender 
    {
        void SendEmail(Email email);
    }
}
