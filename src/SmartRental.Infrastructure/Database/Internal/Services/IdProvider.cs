using Microsoft.EntityFrameworkCore;
using SmartRental.Infrastructure.Database.Internal.Entities.Abstraction;

namespace SmartRental.Infrastructure.Database.Internal.Services
{
    internal class IdProvider<TEntity> : IIdProvider<TEntity>
        where TEntity : DbEntity<int>
    {
        public IdProvider(DatabaseContext dbContext)
        {
            if (dbContext is null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            Query = dbContext.Set<TEntity>();
        }

        public IQueryable<TEntity> Query { get; }

        public async Task<int> NextAsync()
        {
            var lastId = await Query
                .Select(c => c.Id)
                .OrderByDescending(id => id)
                .FirstOrDefaultAsync();

            return lastId + 1;
        }
    }
}
