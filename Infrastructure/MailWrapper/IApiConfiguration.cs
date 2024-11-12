using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.MailWrapper
{
    public interface IApiConfiguration
    {
        void AddApiKey(string key, string value);
    }
}
