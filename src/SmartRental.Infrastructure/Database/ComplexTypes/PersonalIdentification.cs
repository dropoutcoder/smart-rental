namespace SmartRental.Infrastructure.Database.ComplexTypes
{
    /// <summary>
    /// Defines personal identification
    /// </summary>
    public class PersonalIdentification
    {
        /// <summary>
        /// Personal identification number
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Personal identification type
        /// </summary>
        public Type PersonalIdentificationType { get; set; }

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
