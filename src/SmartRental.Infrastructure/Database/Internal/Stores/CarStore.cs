using Microsoft.EntityFrameworkCore;
using SmartRental.Infrastructure.Database.Abstraction;
using SmartRental.Infrastructure.Database.Abstraction.Types;
using SmartRental.Infrastructure.Database.Internal.Entities;
using SmartRental.Infrastructure.Database.Internal.Services;
using System.Diagnostics;

namespace SmartRental.Infrastructure.Database.Internal.Stores
{
    internal class CarStore : ICarStore
    {
        public CarStore(IIdProvider<CarEntity> idProvider, DatabaseContext dbContext)
        {
            IdProvider = idProvider ?? throw new ArgumentNullException(nameof(idProvider));
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public IIdProvider<CarEntity> IdProvider { get; }

        public DatabaseContext DbContext { get; }

        public IQueryable<ICar> Query => DbContext
            .Set<CarEntity>()
            .Cast<ICar>();

        public async Task<ICar> AddCarAsync(string registrationNumber, string name)
        {
            var id = await IdProvider
                .NextAsync();

            var entry = await DbContext
            .Set<CarEntity>()
            .AddAsync(new CarEntity
            {
                Id = id,
                Name = name,
                RegistrationNumber = registrationNumber,
            });

            try
            {
                var result = await DbContext
                    .SaveChangesAsync();

                Debug.Assert(result == 1);

                return entry.Entity;
            }
            catch (DbUpdateException due)
            {
                // log execution context
                throw new StoreException("We have encountered issue while trying to save car to the database.", due);
            }
        }
    }
}
