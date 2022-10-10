using SmartRental.Infrastructure.Database.ComplexTypes;
using SmartRental.Infrastructure.Database.Entities.Abstraction;

namespace SmartRental.Infrastructure.Database.Entities
{
    /// <summary>
    /// Customer database entity
    /// </summary>
    public class CustomerEntity : DbEntity<int>
    {
        /// <summary>
        /// Customer's single given name, or multiple given names separated by space character
        /// </summary>
        public string GivenName { get; set; }

        /// <summary>
        /// Customer's surname, or multiple surnames separated by space character
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Current customer's billing address
        /// </summary>
        public Address BillingAddress { get; set; }

        /// <summary>
        /// Customer's birthdate
        /// </summary>
        public DateTime DateOfBirth { get; set; }
    }
}
