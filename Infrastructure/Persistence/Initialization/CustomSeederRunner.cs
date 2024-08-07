using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence.Initialization;

public class CustomSeederRunner
{
    private readonly ICustomSeeder[] _seeders;

    public CustomSeederRunner(IServiceProvider serviceProvider) =>
        _seeders = serviceProvider.GetServices<ICustomSeeder>().ToArray();

    public async Task RunSeedersAsync()
    {
        foreach (var seeder in _seeders)
        {
            await seeder.InitializeAsync();
        }
    }
}

