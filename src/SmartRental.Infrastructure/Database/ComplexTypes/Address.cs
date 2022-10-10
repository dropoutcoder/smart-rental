namespace SmartRental.Infrastructure.Database.ComplexTypes
{
    /// <summary>
    /// Defining adddress by street, city and postal code
    /// </summary>
    public class Address : IEquatable<Address?>
    {
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

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            return Equals(obj as Address);
        }

        /// <inheritdoc/>
        public bool Equals(Address? other)
        {
            return other is not null &&
                   Street == other.Street &&
                   City == other.City &&
                   PostalCode == other.PostalCode;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return HashCode.Combine(Street, City, PostalCode);
        }

        /// <inheritdoc/>
        public static bool operator ==(Address? left, Address? right)
        {
            return EqualityComparer<Address>.Default.Equals(left, right);
        }

        /// <inheritdoc/>
        public static bool operator !=(Address? left, Address? right)
        {
            return !(left == right);
        }
    }
}