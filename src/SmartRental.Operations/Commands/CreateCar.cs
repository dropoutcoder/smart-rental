using System.ComponentModel.DataAnnotations;

namespace SmartRental.Operations.Commands
{
    /// <summary>
    /// Defines add car operation command
    /// </summary>
    public class CreateCar
    {
        /// <summary>
        /// Car registration plate number
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string RegistrationNumber { get; set; }

        /// <summary>
        /// Car name including version
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
    }
}
