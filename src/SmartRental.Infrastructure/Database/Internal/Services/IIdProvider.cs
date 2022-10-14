namespace SmartRental.Infrastructure.Database.Internal.Services
{
    internal interface IIdProvider<TEntity>
    {
        Task<int> NextAsync();
    }
}