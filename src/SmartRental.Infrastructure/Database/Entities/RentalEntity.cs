using SmartRental.Infrastructure.Database.ComplexTypes;
using SmartRental.Infrastructure.Database.Entities.Abstraction;

namespace SmartRental.Infrastructure.Database.Entities
{
    /// <summary>
    /// Defines rental database entity
    /// </summary>
    public class RentalEntity : DbEntity<int>
    {

        /// <summary>
        /// Rental customer reference identifier
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Flag indicating price of the rental was already settled
        /// </summary>
        public bool IsPaid { get; set; }

        /// <summary>
        /// Flag indicating rental was cancelled
        /// </summary>
        public bool IsCancelled { get; set; }

        /// <summary>
        /// Driving licence number
        /// </summary>
        public string LicenceNumber { get; set; }

        /// <summary>
        /// Pickup date and time
        /// </summary>
        public DateTime PickupDateTime { get; set; }

        /// <summary>
        /// Pickup location
        /// </summary>
        public Location PickupLocation { get; set; }

        /// <summary>
        /// Total price of the rental
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Return date and time
        /// </summary>
        public DateTime ReturnDateTime { get; set; }

        /// <summary>
        /// Return location
        /// </summary>
        public Location ReturnLocation { get; set; }

        /// <summary>
        /// Rental car reference identifier
        /// </summary>
        public int VehicleId { get; set; }
    }
}
