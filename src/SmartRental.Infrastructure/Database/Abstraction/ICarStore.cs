using SmartRental.Infrastructure.Database.Abstraction.Types;

namespace SmartRental.Infrastructure.Database.Abstraction
{
    public interface ICarStore
    {
        public Task<ICar> AddCarAsync(
            string registrationNumber,
            string name);

        public Task<bool> RegistrationNumberExistsAsync(string registrationNumber);
    }
}
