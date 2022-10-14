using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRental.Infrastructure.Database.Internal.Entities.Abstraction;

namespace SmartRental.Infrastructure.Database.Internal.Configuration
{
    internal class DbEntityTypeConfiguration<TKey> : IEntityTypeConfiguration<DbEntity<TKey>>
        where TKey : IEquatable<TKey>
    {
        public void Configure(EntityTypeBuilder<DbEntity<TKey>> builder)
        {
            builder
                .HasKey(e => e.Id);
        }
    }
}
