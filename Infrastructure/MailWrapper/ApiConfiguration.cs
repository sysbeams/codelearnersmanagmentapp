using sib_api_v3_sdk.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.MailWrapper
{
    public class ApiConfiguration : IApiConfiguration
    {
        public void AddApiKey(string key, string value)
        {
            Configuration.Default.ApiKey.Add(key, value);
        }
    }
}
