namespace SmartRental.Infrastructure.Database.ComplexTypes
{
    /// <summary>
    /// Defining location by name and address
    /// </summary>
    /// <seealso cref="ComplexTypes.Address"/>
    public class Location : IEquatable<Location?>
    {
        /// <summary>
        /// Name of the location
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Physical address of the location
        /// </summary>
        public Address Address { get; set; }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            return Equals(obj as Location);
        }

        /// <inheritdoc/>
        public bool Equals(Location? other)
        {
            return other is not null &&
                   Name == other.Name &&
                   EqualityComparer<Address>.Default.Equals(Address, other.Address);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Address);
        }

        /// <inheritdoc/>
        public static bool operator ==(Location? left, Location? right)
        {
            return EqualityComparer<Location>.Default.Equals(left, right);
        }

        /// <inheritdoc/>
        public static bool operator !=(Location? left, Location? right)
        {
            return !(left == right);
        }
    }
}
