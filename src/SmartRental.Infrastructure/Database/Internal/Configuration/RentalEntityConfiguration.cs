using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRental.Infrastructure.Database.Entities;
using SmartRental.Infrastructure.Database.Entities.Abstraction;

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
        }
    }
}
