using Serilog;
using WebApi.Middlewares;

namespace WebApi.Extensions
{
    public static class ApplicationExtension
    {
        public static void UseExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandler>();
        }
        public static void ConfigureSerilog(this IHostBuilder hostBuilder)
        {
            Log.Logger = new LoggerConfiguration()
               .CreateLogger();

            hostBuilder.UseSerilog((context, loggerConfiguration) =>
            {
                loggerConfiguration.ReadFrom.Configuration(context.Configuration);
            });

        }
    }

}
