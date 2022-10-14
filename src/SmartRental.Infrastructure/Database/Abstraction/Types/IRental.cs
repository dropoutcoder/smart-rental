using SmartRental.Infrastructure.Database.ComplexTypes;

namespace SmartRental.Infrastructure.Database.Abstraction.Types
{
    public interface IRental
    {
        /// <summary>
        /// Rental identifier
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Rental car reference identifier
        /// </summary>
        public int CarId { get; set; }

        /// <summary>
        /// Rental customer reference identifier
        /// </summary>
        public int CustomerId { get; set; }

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
