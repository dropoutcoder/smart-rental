using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRental.Infrastructure.Database.Entities;
using SmartRental.Infrastructure.Database.Entities.Abstraction;

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

            builder.HasData(new CarEntity
            {
                Id = 1,
                Name = "Skoda Fabia",
                RegistrationNumber = "ABC1111"
            }, new CarEntity
            {
                Id = 2,
                Name = "Opel Corsa",
                RegistrationNumber = "CRS2222"
            });
        }
    }
}
