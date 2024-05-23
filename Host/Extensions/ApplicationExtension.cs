using WebApi.Middlewares;

namespace WebApi.Extensions
{
    public static class ApplicationExtension
    {
        public static void UseExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandler>();
        }
    }
}
