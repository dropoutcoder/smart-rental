using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRental.Infrastructure.Database.ComplexTypes;
using System.Linq.Expressions;

namespace SmartRental.Infrastructure.Database.Internal.Configuration.Extensions
{
    public static class OwnedNavigationBuilderExtensions
    {
        public static OwnedNavigationBuilder<TEntity, Address> OwnsAddress<TEntity>(
            this EntityTypeBuilder<TEntity> parentBuilder
            , Expression<Func<TEntity, Address>> accessor)
            where TEntity : class
        {
            var builder = parentBuilder.OwnsOne(accessor!);

            builder
                .Property(a => a.City)
                .IsRequired();

            builder
                .Property(a => a.PostalCode)
                .IsRequired();

            builder
                .Property(a => a.Street)
                .IsRequired();

            return builder;
        }

        public static OwnedNavigationBuilder<TEntity, PersonalIdentification> OwnsPersonalDocument<TEntity>(
            this EntityTypeBuilder<TEntity> parentBuilder
            , Expression<Func<TEntity, PersonalIdentification>> accessor)
            where TEntity : class
        {
            var builder = parentBuilder.OwnsOne(accessor!);

            builder
                .Property(pd => pd.Number)
                .IsRequired();

            builder
                .Property(pd => pd.Type)
                .IsRequired();

            return builder;
        }
    }
}
