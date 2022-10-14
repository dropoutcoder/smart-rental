using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRental.Infrastructure.Database.Internal.Entities;
using SmartRental.Infrastructure.Database.Internal.Entities.Abstraction;

namespace SmartRental.Infrastructure.Database.Internal.Configuration
{
    internal class CarEntityConfiguration : IEntityTypeConfiguration<CarEntity>
    {
        public void Configure(EntityTypeBuilder<CarEntity> builder)
        {
            builder
                .HasBaseType<DbEntity<int>>();

            builder
                .Property(ce => ce.Name)
                .IsRequired();

            builder
                .Property(ce => ce.RegistrationNumber)
                .IsRequired();
        }
    }
}
