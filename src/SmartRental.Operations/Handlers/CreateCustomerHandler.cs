using Microsoft.EntityFrameworkCore;
using SmartRental.Infrastructure;
using SmartRental.Infrastructure.Database.ComplexTypes;
using SmartRental.Infrastructure.Database.Entities;
using SmartRental.Operations.Abstraction;
using SmartRental.Operations.Commands;
using System.Diagnostics;

namespace SmartRental.Operations.Handlers
{
    internal class CreateCustomerHandler : Handler<CreateCustomer, CustomerEntity>
    {
        public CreateCustomerHandler(DatabaseContext database)
            : base(database) { }

        protected override async Task<CustomerEntity> ExecuteCoreAsync(CreateCustomer command)
        {
            var entry = await Database
                .Set<CustomerEntity>()
                .AddAsync(new CustomerEntity
                {
                    BillingAddress = new Address
                    {
                        City = command.City,
                        PostalCode = command.PostalCode,
                        Street = command.Street
                    },
                    DateOfBirth = command.DateOfBirth,
                    GivenName = command.GivenName,
                    Surname = command.Surname
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

        protected override Task<bool> ValidateAsync(CreateCustomer command)
        {
            return Task.FromResult(true);
        }
    }
}
