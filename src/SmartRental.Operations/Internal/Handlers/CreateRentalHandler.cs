using Microsoft.EntityFrameworkCore;
using SmartRental.Infrastructure;
using SmartRental.Infrastructure.Database;
using SmartRental.Infrastructure.Database.Abstraction;
using SmartRental.Infrastructure.Database.Abstraction.Types;
using SmartRental.Infrastructure.Database.ComplexTypes;
using SmartRental.Infrastructure.Database.Internal.Entities;
using SmartRental.Operations.Abstraction;
using SmartRental.Operations.Commands;
using System.Diagnostics;

namespace SmartRental.Operations.Internal.Handlers
{
    internal class CreateRentalHandler : Handler<CreateRental, IRental>
    {
        public CreateRentalHandler(IRentalStore store, IQueryable<ICar> cars, IQueryable<ICustomer> customers)
        {
            Store = store ?? throw new ArgumentNullException(nameof(store));
            Cars = cars ?? throw new ArgumentNullException(nameof(cars));
            Customers = customers ?? throw new ArgumentNullException(nameof(customers));
        }

        public IRentalStore Store { get; }
        public IQueryable<ICar> Cars { get; }
        public IQueryable<ICustomer> Customers { get; }

        protected override async Task<IRental> ExecuteCoreAsync(CreateRental command)
        {
            try
            {
                return await Store
                    .AddRentalAsync(
                        command.CarId,
                        command.CustomerId,
                        command.LicenceNumber,
                        PersonalIdentification.Create(command.PersonalDocumentNumber, command.PersonalDocumentType),
                        command.PickupDateTime,
                        command.ReturnDateTime,
                        command.Price
                        );
            }
            catch (StoreException se)
            {
                // log and rethrow
                throw new OperationException(command, "We have encountered issue while trying to save rental to the database.", se);
            }
        }

        protected override async Task<bool> ValidateAsync(CreateRental command)
        {
            if (command.PickupDateTime.AddDays(1).Date >= command.ReturnDateTime.Date)
            {
                return false;
            }

            var customerExists = await Customers
                .AnyAsync(c => c.Id == command.CustomerId);

            var carExists = await Cars
                .AnyAsync(c => c.Id == command.CarId);

            return customerExists && carExists;
        }
    }
}
