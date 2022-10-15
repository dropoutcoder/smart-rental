using SmartRental.Infrastructure.Database.Abstraction;
using SmartRental.Infrastructure.Database.ComplexTypes;

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
                await store.AddCarAsync("SKODA2", "Skoda Superb");
            }

            using (var scope = Provider.CreateScope())
            {
                var store = scope.ServiceProvider.GetRequiredService<ICustomerStore>();
                await store.AddCustomerAsync("Petr", "Sramek", "Marsaskala", "MSK 4042", "Id-Dugh", DateTime.Now);

            }

            using (var scope = Provider.CreateScope())
            {
                var store = scope.ServiceProvider.GetRequiredService<IRentalStore>();
                await store.AddRentalAsync(1, 1, "123456",  PersonalIdentification.Create(123456, PersonalIdentification.IdentificationType.NationalId), DateTime.Now, DateTime.Now.AddDays(4), 120);

            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
