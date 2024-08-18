using Application.Emails;
using Application.EmailSender;
using Domain.Repositories;
using Infrastructure.EmailService;
using Infrastructure.Persistence.EfCoreRepository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class InfrastructureServiceRegisteration
    {
        public static IServiceCollection ConfigureInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("BrevoApi"));
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddScoped<ICourseAssessmentRepository, CourseAssessmentRepository>();
            return services;
        }
    }
}
