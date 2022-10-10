namespace SmartRental.Infrastructure.Database.ComplexTypes
{
    /// <summary>
    /// Defines personal identification
    /// </summary>
    public class PersonalIdentification : IEquatable<PersonalIdentification?>
    {
        /// <summary>
        /// Personal identification number
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Personal identification type
        /// </summary>
        public Type PersonalIdentificationType { get; set; }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            return Equals(obj as PersonalIdentification);
        }

        /// <inheritdoc/>
        public bool Equals(PersonalIdentification? other)
        {
            return other is not null &&
                   Number == other.Number &&
                   PersonalIdentificationType == other.PersonalIdentificationType;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return HashCode.Combine(Number, PersonalIdentificationType);
        }

        /// <inheritdoc/>
        public static bool operator ==(PersonalIdentification? left, PersonalIdentification? right)
        {
            return EqualityComparer<PersonalIdentification>.Default.Equals(left, right);
        }

        /// <inheritdoc/>
        public static bool operator !=(PersonalIdentification? left, PersonalIdentification? right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Personal identification type
        /// </summary>
        public enum Type
        {
            IdCard = 0,
            Passport = 1
        }
    }
}
