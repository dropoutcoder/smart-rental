using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SmartRental.Infrastructure.Database.Abstraction;
using SmartRental.Infrastructure.Database.Abstraction.Types;
using SmartRental.Infrastructure.Database.Internal.Entities;
using SmartRental.Infrastructure.Database.Internal.Services;
using SmartRental.Infrastructure.Database.Internal.Stores;

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

            services
                .AddScoped<IIdProvider<CarEntity>, IdProvider<CarEntity>>()
                .AddScoped<IIdProvider<CustomerEntity>, IdProvider<CustomerEntity>>()
                .AddScoped<IIdProvider<RentalEntity>, IdProvider<RentalEntity>>()
                .AddScoped<IQueryable<ICar>>(provider => provider.GetRequiredService<DatabaseContext>().Set<CarEntity>().Cast<ICar>())
                .AddScoped<IQueryable<ICustomer>>(provider => provider.GetRequiredService<DatabaseContext>().Set<CustomerEntity>().Cast<ICustomer>())
                .AddScoped<IQueryable<IRental>>(provider => provider.GetRequiredService<DatabaseContext>().Set<RentalEntity>().Cast<IRental>())
                .AddScoped<ICarStore, CarStore>()
                .AddScoped<ICustomerStore, CustomerStore>()
                .AddScoped<IRentalStore, RentalStore>()
                .AddDbContext<DatabaseContext>(options =>
                {
                    options.UseInMemoryDatabase(databaseName ?? "production");
                });

            return services;
        }
    }
}
