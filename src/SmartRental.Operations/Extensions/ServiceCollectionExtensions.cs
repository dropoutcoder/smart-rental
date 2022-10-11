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
                .AddScoped<IHandler<CreateCar, CarEntity>, CreateCarHadler>()
                .AddScoped<IHandler<CreateCustomer, CustomerEntity> , CreateCustomerHandler >()
                .AddScoped<IHandler<CreateRental, RentalEntity>, CreateRentalHandler>()
                .AddScoped<IHandler<CancelRental, RentalEntity>, CancelRentalHandler>();

            return services;
        }
    }
}
