using SmartRental.Infrastructure.Database.Abstraction.Types;
using SmartRental.Infrastructure.Database.ComplexTypes;
using SmartRental.Infrastructure.Database.Internal.Entities.Abstraction;

namespace SmartRental.Infrastructure.Database.Internal.Entities
{
    /// <summary>
    /// Customer database entity
    /// </summary>
    internal class CustomerEntity : DbEntity<int>, ICustomer
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
        /// Current customer's address
        /// </summary>
        public Address Address { get; set; }

        /// <summary>
        /// Customer's birthdate
        /// </summary>
        public DateTime DateOfBirth { get; set; }
    }
}
