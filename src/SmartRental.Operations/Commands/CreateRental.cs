using SmartRental.Infrastructure.Database.ComplexTypes;
using System.ComponentModel.DataAnnotations;

namespace SmartRental.Operations.Commands
{
    public class CreateRental
    {
        /// <summary>
        /// Rental car reference identifier
        /// </summary>
        [Required]
        public int CarId { get; set; }

        /// <summary>
        /// Rental customer reference identifier
        /// </summary>
        [Required]
        public int CustomerId { get; set; }

        /// <summary>
        /// Flag indicating price of the rental was already settled
        /// </summary>
        [Required]
        public bool IsPaid { get; set; }

        /// <summary>
        /// Driving licence number
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string LicenceNumber { get; set; }

        /// <summary>
        /// Pickup date and time
        /// </summary>
        [Required]
        public DateTime PickupDateTime { get; set; }

        /// <summary>
        /// Total price of the rental
        /// </summary>
        [Required]
        [Range(0, Int32.MaxValue)]
        public decimal Price { get; set; }

        /// <summary>
        /// Return date and time
        /// </summary>
        [Required] 
        public DateTime ReturnDateTime { get; set; }
    }
}
