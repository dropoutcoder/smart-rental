namespace SmartRental.Infrastructure.Database.ComplexTypes
{
    /// <summary>
    /// Defines personal identification
    /// </summary>
    public class PersonalIdentification
    {
        public static PersonalIdentification Create(int number, IdentificationType type)
        {
            return new PersonalIdentification(number, type);
        }

        private PersonalIdentification(int number, IdentificationType type)
        {
            Number = number;
            Type = type;
        }

        /// <summary>
        /// Personal identification number
        /// </summary>
        public int Number { get; }

        /// <summary>
        /// Personal identification type
        /// </summary>
        public IdentificationType Type { get; }

        /// <summary>
        /// Personal identification type
        /// </summary>
        public enum IdentificationType
        {
            NationalId = 0,
            Passport = 1
        }
    }
}
