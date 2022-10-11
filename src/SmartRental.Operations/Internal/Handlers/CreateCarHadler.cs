using Microsoft.EntityFrameworkCore;
using SmartRental.Infrastructure;
using SmartRental.Infrastructure.Database.Entities;
using SmartRental.Operations.Abstraction;
using SmartRental.Operations.Commands;
using System.Diagnostics;

namespace SmartRental.Operations.Handlers
{
    internal class CreateCarHadler : Handler<CreateCar, CarEntity>
    {
        public CreateCarHadler(DatabaseContext database)
            : base(database) { }

        protected override async Task<CarEntity> ExecuteCoreAsync(CreateCar command)
        {
            var entry = await Database
                .Set<CarEntity>()
                .AddAsync(new CarEntity
                {
                    Name = command.Name,
                    RegistrationNumber = command.RegistrationNumber,
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
                throw new OperationException(command, "We have encountered issue while trying to save car to the database.", due);
            }
        }

        protected override async Task<bool> ValidateAsync(CreateCar command)
        {
            var exists = await Database
                .Set<CarEntity>()
                .AnyAsync(c => c.RegistrationNumber == command.RegistrationNumber);

            return !exists;
        }
    }
}
