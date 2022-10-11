using Microsoft.Extensions.DependencyInjection;
using SmartRental.Infrastructure.Database.Entities;
using SmartRental.Operations.Abstraction;
using SmartRental.Operations.Commands;
using SmartRental.Operations.Handlers;

namespace SmartRental.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddOperations(this IServiceCollection services)
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services
                .AddScoped<IHandler<CreateCarHadler, IHandler<CreateCar, CarEntity>>>()
                .AddScoped<IHandler<CreateCustomerHandler, IHandler<CreateCustomer, CustomerEntity>>>()
                .AddScoped<IHandler<CreateRentalHandler, IHandler<CreateRental, RentalEntity>>>()
                .AddScoped<IHandler<CancelRentalHandler, IHandler<CancelRental, RentalEntity>>>();

            return services;
        }
    }
}
