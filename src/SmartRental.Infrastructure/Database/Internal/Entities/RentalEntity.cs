using SmartRental.Infrastructure.Database.Abstraction.Types;
using SmartRental.Infrastructure.Database.ComplexTypes;
using SmartRental.Infrastructure.Database.Internal.Entities.Abstraction;

namespace SmartRental.Infrastructure.Database.Internal.Entities
{
    /// <summary>
    /// Defines rental database entity
    /// </summary>
    internal class RentalEntity : DbEntity<int>, IRental
    {

        /// <summary>
        /// Rental car reference identifier
        /// </summary>
        public int CarId { get; set; }

        /// <summary>
        /// Rental customer reference identifier
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Flag indicating rental price was settled
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
        /// Personal identification document
        /// </summary>
        public PersonalIdentification PersonalDocument { get; set; }

        /// <summary>
        /// Pickup date and time
        /// </summary>
        public DateTime PickupDateTime { get; set; }

        /// <summary>
        /// Total price of the rental
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Return date and time
        /// </summary>
        public DateTime ReturnDateTime { get; set; }
    }
}
