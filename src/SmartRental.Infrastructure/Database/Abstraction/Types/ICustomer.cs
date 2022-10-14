using SmartRental.Infrastructure.Database.ComplexTypes;

namespace SmartRental.Infrastructure.Database.Abstraction.Types
{
    public interface ICustomer
    {
        /// <summary>
        /// Customer identifier
        /// </summary>
        public int Id { get; }

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
