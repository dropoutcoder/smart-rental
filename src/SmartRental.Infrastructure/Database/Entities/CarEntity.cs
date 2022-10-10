using SmartRental.Infrastructure.Database.Entities.Abstraction;

namespace SmartRental.Infrastructure.Database.Entities
{
    /// <summary>
    /// Car database entity
    /// </summary>
    public class CarEntity : DbEntity<int>
    {
        /// <summary>
        /// Car registration plate number
        /// </summary>
        public string RegistrationNumber { get; set; }

        /// <summary>
        /// Car name including version
        /// </summary>
        public string Name { get; set; }
    }
}
