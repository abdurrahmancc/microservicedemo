
using Catalog.API.Context;

namespace Catalog.API.HostingService
{
    public class AppHostedService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public AppHostedService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            // Create scope to access scoped services
            using (var scope = _serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<CatalogDbContext>();
                CatalogDbContextSeed.SeedAsync(context);
            }

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
