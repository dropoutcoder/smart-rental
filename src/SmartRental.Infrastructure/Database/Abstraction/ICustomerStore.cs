using SmartRental.Infrastructure.Database.Abstraction.Types;
using SmartRental.Infrastructure.Database.ComplexTypes;

namespace SmartRental.Infrastructure.Database.Abstraction
{
    public interface ICustomerStore
    {
        public IQueryable<ICustomer> Query { get; }

        public Task<ICustomer> AddCustomerAsync(
            string givenName,
            string surname,
            string street,
            string city,
            string postalCode,
            DateTime dateOfBirth);
    }
}
