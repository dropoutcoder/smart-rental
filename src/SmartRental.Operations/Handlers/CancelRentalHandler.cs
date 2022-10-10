using Microsoft.EntityFrameworkCore;
using SmartRental.Infrastructure.Database.Entities;
using SmartRental.Operations.Abstraction;
using SmartRental.Operations.Commands;
using System.Diagnostics;

namespace SmartRental.Operations.Handlers
{
    internal class CancelRentalHandler : Handler<CancelRental, RentalEntity>
    {
        public CancelRentalHandler(DbContext database)
            : base(database) { }

        protected override async Task<RentalEntity> ExecuteCoreAsync(CancelRental command)
        {
            var entry = Database
                .Set<RentalEntity>()
                .Attach(new RentalEntity
                {
                    Id = command.RentalId
                });

            entry.Entity.IsCancelled = true;

            try
            {
                var result = await Database
                    .SaveChangesAsync();

                Debug.Assert(result == 1);

                return entry.Entity;
            }
            catch (DbUpdateException due)
            {
                // log execution context
                throw new OperationException(command, "We have encountered issue while trying to cancel rental.", due);
            }
        }

        protected override async Task<bool> ValidateAsync(CancelRental command)
        {
            var exists = await Database
                .Set<RentalEntity>()
                .AnyAsync(c => c.Id == command.RentalId && !c.IsCancelled);

            return exists;
        }
    }
}
