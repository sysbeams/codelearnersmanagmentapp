using Application.Mail;
using Application.MailSender;
using Infrastructure.MailService;
using Infrastructure.MailWrapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Infrastructure.InfrastructureExtensions
{
    public static class ServiceRegisteration
    {
        public static IServiceCollection ConfigureInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("BrevoApi"));
            services.AddTransient<IEmailSender, MailSender>();
            services.AddScoped<ITransactionalEmailsApiWrapper, TransactionalEmailsApiWrapper>();
            return services;
        }
    }
}
