using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRental.Infrastructure.Database.Internal.Configuration.Extensions;
using SmartRental.Infrastructure.Database.Internal.Entities;
using SmartRental.Infrastructure.Database.Internal.Entities.Abstraction;

namespace SmartRental.Infrastructure.Database.Internal.Configuration
{
    internal class CustomerEntityConfiguration : IEntityTypeConfiguration<CustomerEntity>
    {
        public void Configure(EntityTypeBuilder<CustomerEntity> builder)
        {
            builder
                .HasBaseType<DbEntity<int>>();

            builder
                .OwnsAddress(ce => ce.Address);

            builder
                .Property(ce => ce.DateOfBirth)
                .IsRequired();

            builder
                .Property(ce => ce.GivenName)
                .IsRequired();

            builder
                .Property(ce => ce.Surname)
                .IsRequired();
        }
    }
}
