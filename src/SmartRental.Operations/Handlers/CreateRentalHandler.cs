using Microsoft.EntityFrameworkCore;
using SmartRental.Infrastructure.Database.Entities;
using SmartRental.Operations.Abstraction;
using SmartRental.Operations.Commands;
using System.Diagnostics;

namespace SmartRental.Operations.Handlers
{
    internal class CreateRentalHandler : Handler<CreateRental, RentalEntity>
    {
        public CreateRentalHandler(DbContext database)
            : base(database) { }

        protected override async Task<RentalEntity> ExecuteCoreAsync(CreateRental command)
        {
            var entry = await Database
               .Set<RentalEntity>()
               .AddAsync(new RentalEntity
               {
                   CarId = command.CarId,
                   CustomerId = command.CustomerId,
                   IsCancelled = false,
                   IsPaid = command.IsPaid,
                   LicenceNumber = command.LicenceNumber,
                   PickupDateTime = command.PickupDateTime,
                   Price = command.Price,
                   ReturnDateTime = command.ReturnDateTime,
               });

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
                throw new OperationException(command, "We have encountered issue while trying to save customer to the database.", due);
            }
        }

        protected override async Task<bool> ValidateAsync(CreateRental command)
        {
            if(command.PickupDateTime.AddDays(1).Date <= command.ReturnDateTime.Date)
            {
                return false;
            }

            var customerExists = await Database
                .Set<CustomerEntity>()
                .AnyAsync(c => c.Id == command.CustomerId);

            var carExists = await Database
                .Set<CarEntity>()
                .AnyAsync(c => c.Id == command.CarId);

            return customerExists && carExists;
        }
    }
}
