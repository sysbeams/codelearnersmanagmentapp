using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureDbContext(this IServiceCollection services,
          IConfiguration configuration) =>
          services.AddDbContext<ApplicationContext>(opts =>
              opts.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
}
