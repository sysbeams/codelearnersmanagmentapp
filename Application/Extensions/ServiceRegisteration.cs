using Application.Mail;
using Application.Mail.Logging;
using Application.MailSender;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extensions
{
    public static class ServiceRegisteration
    {
        public static IServiceCollection ConfigureInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient(typeof(ILoggerAdapter<>), typeof(LoggerAdapter<>));
         

            return services;
        }
    }
}
