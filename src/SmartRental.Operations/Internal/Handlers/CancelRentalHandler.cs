using Microsoft.EntityFrameworkCore;
using SmartRental.Infrastructure.Database;
using SmartRental.Infrastructure.Database.Abstraction;
using SmartRental.Operations.Commands;

namespace SmartRental.Operations.Internal.Handlers
{
    internal class CancelRentalHandler : Handler<CancelRental, bool>
    {
        public CancelRentalHandler(IRentalStore store)
        {
            Store = store ?? throw new ArgumentNullException(nameof(store));
        }

        public IRentalStore Store { get; }

        protected override async Task<bool> ExecuteCoreAsync(CancelRental command)
        {
            try
            {
                return await Store
                    .CancelRental(command.RentalId);
            }
            catch (StoreException se)
            {
                // log execution context
                throw new OperationException(command, "We have encountered issue while trying to cancel rental.", se);
            }
        }

        protected override async Task<bool> ValidateAsync(CancelRental command)
        {
            var isCancelled = await Store
                .IsCancelled(command.RentalId);

            return !isCancelled;
        }
    }
}
