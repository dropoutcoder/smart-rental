using SmartRental.Infrastructure;
using SmartRental.Infrastructure.Database.Abstraction;
using SmartRental.Infrastructure.Database.ComplexTypes;
using SmartRental.Infrastructure.Database.Internal.Entities;

namespace SmartRental.Services
{
    public class InitializeDatabaseHostingService : IHostedService
    {
        public InitializeDatabaseHostingService(IServiceProvider provider)
        {
            Provider = provider ?? throw new ArgumentNullException(nameof(provider));
        }

        public IServiceProvider Provider { get; }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using (var scope = Provider.CreateScope())
            {
                var store = scope.ServiceProvider.GetRequiredService<ICarStore>();
                await store.AddCarAsync("SKODA1", "Skoda Fabia");
            }

            using (var scope = Provider.CreateScope())
            {
                var store = scope.ServiceProvider.GetRequiredService<ICustomerStore>();
                await store.AddCustomerAsync("Petr", "Sramek", "Marsaskala", "MSK 4042", "Id-Dugh", DateTime.Now);

            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
