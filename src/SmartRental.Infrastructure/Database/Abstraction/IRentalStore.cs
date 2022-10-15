using SmartRental.Infrastructure.Database.Abstraction.Types;
using SmartRental.Infrastructure.Database.ComplexTypes;

namespace SmartRental.Infrastructure.Database.Abstraction
{
    public interface IRentalStore
    {
        public IQueryable<IRental> Query { get; }

        public Task<IRental> AddRentalAsync(
            int carId,
            int customerId,
            string licenceNumber,
            PersonalIdentification identificationDocument,
            DateTime pickupDate,
            DateTime returnDate,
            decimal price);

        public Task<bool> CancelRental(int rentalId);
    }
}
