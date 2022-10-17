using SmartRental.Infrastructure.Database.Abstraction.Types;

namespace SmartRental.Infrastructure.Database.Abstraction
{
    public interface ICustomerStore
    {
        public Task<ICustomer> AddCustomerAsync(
            string givenName,
            string surname,
            string street,
            string city,
            string postalCode,
            DateTime dateOfBirth);
    }
}
