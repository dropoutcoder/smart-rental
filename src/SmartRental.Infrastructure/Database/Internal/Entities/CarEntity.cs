using SmartRental.Infrastructure.Database.Abstraction.Types;
using SmartRental.Infrastructure.Database.Internal.Entities.Abstraction;

namespace SmartRental.Infrastructure.Database.Internal.Entities
{
    /// <summary>
    /// Car database entity
    /// </summary>
    internal class CarEntity : DbEntity<int>, ICar
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
