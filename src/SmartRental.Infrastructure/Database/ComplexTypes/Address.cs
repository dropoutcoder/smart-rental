namespace SmartRental.Infrastructure.Database.ComplexTypes
{
    /// <summary>
    /// Defining adddress by street, city and postal code
    /// </summary>
    public class Address
    {
        public static Address Create(string street, string city, string postalCode)
        {
            return new Address(street, city, postalCode);
        }

        private Address(string street, string city, string postalCode)
        {
            Street = street;
            City = city;
            PostalCode = postalCode;
        }

        /// <summary>
        /// Street name including identification schema
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// City name
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// ZIP or postal code
        /// </summary>
        public string PostalCode { get; set; }
    }
}