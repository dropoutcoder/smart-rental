using System.ComponentModel.DataAnnotations;

namespace SmartRental.Operations.Commands
{
    public class CreateCustomer
    {
        /// <summary>
        /// Customer's single given name, or multiple given names separated by space character
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string GivenName { get; set; }

        /// <summary>
        /// Customer's surname, or multiple surnames separated by space character
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string Surname { get; set; }

        /// <summary>
        /// Billing street name
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string Street { get; set; }

        /// <summary>
        /// Billing City name
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string City { get; set; }

        /// <summary>
        /// Billing ZIP or postal code
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string PostalCode { get; set; }

        /// <summary>
        /// Customer's birthdate
        /// </summary>
        [Required]
        public DateTime DateOfBirth { get; set; }
    }
}
