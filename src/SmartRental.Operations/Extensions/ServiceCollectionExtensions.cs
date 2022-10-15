using Microsoft.Extensions.DependencyInjection;
using SmartRental.Infrastructure.Database.Abstraction.Types;
using SmartRental.Operations.Abstraction;
using SmartRental.Operations.Commands;
using SmartRental.Operations.Internal.Handlers;

namespace SmartRental.Operations.Extensions
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
                .AddScoped<IHandler<CreateCar, ICar>, CreateCarHadler>()
                .AddScoped<IHandler<CreateCustomer, ICustomer>, CreateCustomerHandler>()
                .AddScoped<IHandler<CreateRental, IRental>, CreateRentalHandler>()
                .AddScoped<IHandler<CancelRental, bool>, CancelRentalHandler>();

            return services;
        }
    }
}
