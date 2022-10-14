using SmartRental.Infrastructure.Database.Abstraction.Types;

namespace SmartRental.Infrastructure.Database.Abstraction
{
    public interface ICarStore
    {
        public IQueryable<ICar> Query { get; }

        public Task<ICar> AddCarAsync(
            string registrationNumber,
            string name);
    }
}
