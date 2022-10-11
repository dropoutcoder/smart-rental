using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRental.Infrastructure.Database.Entities;
using SmartRental.Infrastructure.Database.Entities.Abstraction;
using SmartRental.Infrastructure.Database.Internal.Configuration.Extensions;

namespace SmartRental.Infrastructure.Database.Internal.Configuration
{
    internal class RentalEntityConfiguration : IEntityTypeConfiguration<RentalEntity>
    {
        public void Configure(EntityTypeBuilder<RentalEntity> builder)
        {
            builder
                .HasBaseType<DbEntity<int>>();

            builder
                .Property(re => re.CustomerId)
                .IsRequired();

            builder
                .Property(re => re.IsCancelled)
                .IsRequired();

            builder
                .Property(re => re.IsPaid)
                .IsRequired();

            builder
                .Property(re => re.LicenceNumber)
                .IsRequired();

            builder
                .OwnsPersonalDocument(re => re.PersonalDocument);

            builder
                .Property(re => re.PickupDateTime)
                .IsRequired();

            builder
                .Property(re => re.Price)
                .IsRequired();

            builder
                .Property(re => re.ReturnDateTime)
                .IsRequired();

            builder
                .Property(re => re.CarId)
                .IsRequired();

            builder
                .HasData(new RentalEntity
                {
                    CarId = 1,
                    CustomerId = 1,
                    Id = 1,
                    IsCancelled = false,
                    IsPaid = true,
                    LicenceNumber = "PS12345",
                    PickupDateTime = DateTime.UtcNow.AddDays(2),
                    Price = 100m,
                    ReturnDateTime = DateTime.UtcNow.AddDays(8)
                });
        }
    }
}
