using SmartRental.Infrastructure.Database;
using SmartRental.Infrastructure.Database.Abstraction;
using SmartRental.Infrastructure.Database.Abstraction.Types;
using SmartRental.Operations.Abstraction;
using SmartRental.Operations.Commands;

namespace SmartRental.Operations.Internal.Handlers
{
    internal class CreateCustomerHandler : Handler<CreateCustomer, ICustomer>
    {
        public CreateCustomerHandler(ICustomerStore store)
        {
            Store = store ?? throw new ArgumentNullException(nameof(store));
        }

        public ICustomerStore Store { get; }

        protected override async Task<ICustomer> ExecuteCoreAsync(CreateCustomer command)
        {
            try
            {
                return await Store
                    .AddCustomerAsync(
                        command.GivenName,
                        command.Surname,
                        command.Street,
                        command.City,
                        command.PostalCode,
                        command.DateOfBirth);
            }
            catch (StoreException se)
            {
                // log execution context
                throw new OperationException(command, "We have encountered issue while trying to save customer to the database.", se);
            }
        }

        protected override Task<bool> ValidateAsync(CreateCustomer command)
        {
            return Task.FromResult(true);
        }
    }
}
