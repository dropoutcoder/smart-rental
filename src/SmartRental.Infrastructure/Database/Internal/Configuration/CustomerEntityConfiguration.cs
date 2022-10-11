using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRental.Infrastructure.Database.Entities;
using SmartRental.Infrastructure.Database.Entities.Abstraction;
using SmartRental.Infrastructure.Database.Internal.Configuration.Extensions;

namespace SmartRental.Infrastructure.Database.Internal.Configuration
{
    internal class CustomerEntityConfiguration : IEntityTypeConfiguration<CustomerEntity>
    {
        public void Configure(EntityTypeBuilder<CustomerEntity> builder)
        {
            builder
                .HasBaseType<DbEntity<int>>();

            builder
                .OwnsAddress(ce => ce.BillingAddress);

            builder
                .Property(ce => ce.DateOfBirth)
                .IsRequired();

            builder
                .Property(ce => ce.GivenName)
                .IsRequired();

            builder
                .Property(ce => ce.Surname)
                .IsRequired();

            builder
                .HasData(new CustomerEntity
                {
                    BillingAddress = new ComplexTypes.Address
                    {
                        City = "Marsaskala",
                        PostalCode = "MSK 4070",
                        Street = "Triq Il-Btieti"
                    },
                    DateOfBirth = DateTime.UtcNow.Date.AddYears(40),
                    GivenName = "Petr",
                    Surname = "Sramek",
                    Id = 1
                });
        }
    }
}
