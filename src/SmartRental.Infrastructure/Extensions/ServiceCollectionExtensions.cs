using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SmartRental.Infrastructure.Database.Entities;

namespace SmartRental.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, string? databaseName = null)
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseInMemoryDatabase(databaseName ?? "production");
            });

            return services;
        }

        public static IServiceCollection AddQueries(this IServiceCollection services)
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services
                .AddScoped<IQueryable<CarEntity>>(provider => provider.GetRequiredService<DatabaseContext>().Set<CarEntity>())
                .AddScoped<IQueryable<CustomerEntity>>(provider => provider.GetRequiredService<DatabaseContext>().Set<CustomerEntity>())
                .AddScoped<IQueryable<RentalEntity>>(provider => provider.GetRequiredService<DatabaseContext>().Set<RentalEntity>());

            return services;
        }
    }
}
