namespace SmartRental.Infrastructure.Database.Abstraction.Types
{
    public interface ICar
    {
        /// <summary>
        /// Car identifier
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Car registration plate number
        /// </summary>
        public string RegistrationNumber { get; }

        /// <summary>
        /// Car name including version
        /// </summary>
        public string Name { get; }
    }
}
